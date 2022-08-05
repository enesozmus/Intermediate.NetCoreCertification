using Intermediate.MVC.Models;
using Intermediate.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.MVC.Controllers;

public class ApartmentTypesController : Controller
{
     private readonly IApartmentTypeService _apartmentTypeService;

     public ApartmentTypesController(IApartmentTypeService ApartmentTypeService)
     {
          _apartmentTypeService = ApartmentTypeService;
     }

     #region Hepsini Getir

     [HttpGet]
     public async Task<IActionResult> GetApartmentTypes() => View(await _apartmentTypeService.GetApartmentTypesAsync());

     #endregion


     #region Yeni Ekle

     public IActionResult CreateApartmentType() => View();

     [HttpPost]
     public async Task<IActionResult> CreateApartmentType(CreateApartmentTypeCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               var responseMessage = await _apartmentTypeService.CreateApartmentType(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetApartmentTypes", "ApartmentTypes");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
               //return View(request);
          }
          return View(request);
     }

     #endregion


     #region Güncelle

     public async Task<IActionResult> UpdateApartmentType(int id) => View(await _apartmentTypeService.GetViewForUpdateApartmentType(id));

     [HttpPost]
     public async Task<IActionResult> UpdateApartmentType(UpdateApartmentTypeCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               var responseMessage = await _apartmentTypeService.UpdateApartmentType(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetApartmentTypes", "ApartmentTypes");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          return View(request);
     }

     #endregion


     #region Sil

     public async Task<IActionResult> RemoveApartmentType(int id)
     {
          await _apartmentTypeService.RemoveApartmentType(id);
          return RedirectToAction("GetApartmentTypes", "ApartmentTypes");
     }

     #endregion
}
