using Intermediate.MVC.Models;
using Intermediate.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.MVC.Controllers;

public class ResidentsController : Controller
{
     private readonly IResidentService _residentService;

     public ResidentsController(IResidentService ResidentService)
     {
          _residentService = ResidentService;
     }

     #region Site Sakinlerinin Sadece İsimlerini Getir

     [HttpGet]
     public async Task<IActionResult> GetResidentNames() => View(await _residentService.GetResidentNamesAsync());

     #endregion


     #region Hepsini Getir

     [HttpGet]
     public async Task<IActionResult> GetResidents() => View(await _residentService.GetResidentsAsync());

     #endregion


     #region Yeni Ekle

     public async Task<IActionResult> CreateResident() => View();

     [HttpPost]
     public async Task<IActionResult> CreateResident(CreateResidentCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               var responseMessage = await _residentService.CreateResident(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetResidents", "Residents");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
               //return View(request);
          }
          else
          {
               ModelState.AddModelError("ErrorKey", "ErrorValue");
               return BadRequest(new ValidationProblemDetails(this.ModelState));
          }
          return View(request);
     }

     #endregion


     #region Güncelle

     public async Task<IActionResult> UpdateResident(int id) => View(await _residentService.GetViewForUpdateResident(id));

     [HttpPost]
     public async Task<IActionResult> UpdateResident(UpdateResidentCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               var responseMessage = await _residentService.UpdateResident(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetResidents", "Residents");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          return View(request);
     }

     #endregion


     #region Sil

     public async Task<IActionResult> RemoveResident(int id)
     {
          await _residentService.RemoveResident(id);
          return RedirectToAction("GetResidents", "Residents");
     }

     #endregion
}
