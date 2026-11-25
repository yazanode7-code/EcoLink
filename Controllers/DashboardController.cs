using EcoLink.Constants;
using EcoLink.Models;
using EcoLink.Models.Enums;
using EcoLink.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoLink.Controllers;

[Authorize]
public class DashboardController : Controller
{
    public IUnitOfWork _uow { get; }

    public DashboardController(IUnitOfWork uow)
    {
        _uow = uow;
    }




    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> Admin()
    {
        ViewBag.BranchesCount = await _uow.Branches.CountAsync();
        ViewBag.BinsCount = await _uow.Bins.CountAsync();
        ViewBag.PendingCount = await _uow.PickupRequests
            .CountAsync(p => p.Status == PickupStatus.Pending);

        var branches = await _uow.Branches.GetAllAsync();
        return View(branches);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> AddTestBranch(string name, string? address)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            await _uow.Branches.AddAsync(new Branch { Name = name, Address = address });
            await _uow.CompleteAsync();
        }
        return RedirectToAction(nameof(Admin));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> DeleteTestBranch(int id)
    {
        var branch = await _uow.Branches.GetByIdAsync(id);
        if (branch != null)
        {
            _uow.Branches.Remove(branch);
            await _uow.CompleteAsync();
        }
        return RedirectToAction(nameof(Admin));
    }



















    //[Authorize(Roles = AppRoles.Admin)]
    //public IActionResult Admin()
    //{
    //    return View();
    //}

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