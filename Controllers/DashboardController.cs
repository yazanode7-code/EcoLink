using EcoLink.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoLink.Controllers;

[Authorize]
public class DashboardController : Controller
{
    [Authorize(Roles = AppRoles.Admin)]
    public IActionResult Admin()
    {
        return View();
    }

    [Authorize(Roles = AppRoles.BranchEmployee)]
    public IActionResult Employee()
    {
        return View();
    }

    [Authorize(Roles = AppRoles.Factory)]
    public IActionResult Factory()
    {
        return View();
    }

    [Authorize(Roles = AppRoles.Driver)]
    public IActionResult Driver()
    {
        return View();
    }
}