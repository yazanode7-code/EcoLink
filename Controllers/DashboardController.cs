using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoLink.Controllers;

[Authorize]
public class DashboardController : Controller
{
    [Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        return View();
    }

    [Authorize(Roles = "BranchEmployee")]
    public IActionResult Employee()
    {
        return View();
    }

    [Authorize(Roles = "Factory")]
    public IActionResult Factory()
    {
        return View();
    }

    [Authorize(Roles = "Driver")]
    public IActionResult Driver()
    {
        return View();
    }
}