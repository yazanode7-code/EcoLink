using EcoLink.Models;
using EcoLink.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcoLink.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Login(string? returnUrl = null)
    {
        // إذا داخل أصلاً، ما في داعي يشوف صفحة الدخول
        if (User.Identity?.IsAuthenticated == true)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
                return await RedirectToDashboard(currentUser);
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (!ModelState.IsValid)
            return View(model);

        var result = await _signInManager.PasswordSignInAsync(
            model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

        if (result.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "Your account is locked. Please try again later.");
            return View(model);
        }

        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(model);
        }

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return LocalRedirect(returnUrl);

        var user = await _userManager.FindByEmailAsync(model.Email);
        return await RedirectToDashboard(user!);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

    private async Task<IActionResult> RedirectToDashboard(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        if (roles.Contains("Admin")) return RedirectToAction("Admin", "Dashboard");
        if (roles.Contains("BranchEmployee")) return RedirectToAction("Employee", "Dashboard");
        if (roles.Contains("Factory")) return RedirectToAction("Factory", "Dashboard");
        if (roles.Contains("Driver")) return RedirectToAction("Driver", "Dashboard");

        // مستخدم بدون دور: ما إله مكان بالنظام
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
}