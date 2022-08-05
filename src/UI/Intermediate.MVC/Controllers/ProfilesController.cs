using Intermediate.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.MVC.Controllers;

public class ProfilesController : Controller
{
     private readonly IProfileService _profileService;

     public ProfilesController(IProfileService profileService)
     {
          _profileService = profileService;
     }

     #region Profil Bilgilerini Getir

     [HttpGet]
     public async Task<IActionResult> GetUser() => View(await _profileService.GetUserAsync());

     #endregion

     #region Kullanıcıya Ait Faturaları Getir

     [HttpGet]
     public async Task<IActionResult> GetUserBills() => View(await _profileService.GetUserBillsAsync());

     #endregion

     #region Kullanıcıya Ait Daireleri Getir

     [HttpGet]
     public async Task<IActionResult> GetUserApartments() => View(await _profileService.GetUserApartmentsAsync());

     #endregion
}
