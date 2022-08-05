using Intermediate.MVC.Models;
using Intermediate.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intermediate.MVC.Controllers;

public class ApartmentsController : Controller
{
     private readonly IApartmentService _apartmentService;
     private readonly IResidentService _residentService;
     private readonly IBlockService _blockService;
     private readonly IApartmentTypeService _apartmentTypeService;

     public ApartmentsController(IApartmentService apartmentService, IResidentService residentService,
          IBlockService blockService, IApartmentTypeService apartmentTypeService)
     {
          _apartmentService = apartmentService;
          _residentService = residentService;
          _blockService = blockService;
          _apartmentTypeService = apartmentTypeService;
     }

     #region Hepsini Getir

     [HttpGet]
     public async Task<IActionResult> GetApartments() => View(await _apartmentService.GetApartmentsAsync());

     #endregion


     #region Yeni Ekle

     public async Task<IActionResult> CreateApartment()
     {
          await CreateDropDown();
          return View(new CreateApartmentCommandRequest());
     }

     [HttpPost]
     public async Task<IActionResult> CreateApartment(CreateApartmentCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               await CreateDropDown();
               var responseMessage = await _apartmentService.CreateApartment(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetApartments", "Apartments");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          await CreateDropDown();
          return View(request);
     }

     #endregion


     #region Güncelle

     public async Task<IActionResult> UpdateApartment(int id)
     {
          await CreateDropDown();
          return View(await _apartmentService.GetViewForUpdateApartment(id));
     }

     [HttpPost]
     public async Task<IActionResult> UpdateApartment(UpdateApartmentCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               await CreateDropDown();
               var responseMessage = await _apartmentService.UpdateApartment(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetApartments", "Apartments");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          await CreateDropDown();
          return View(request);
     }

     #endregion


     #region Sil

     public async Task<IActionResult> RemoveApartment(int id)
     {
          await _apartmentService.RemoveApartment(id);
          return RedirectToAction("GetApartments", "Apartments");
     }

     #endregion

     #region DropDown

     private async Task CreateDropDown()
     {
          var names = await _residentService.GetResidentNamesAsync();
          ViewBag.Residents = new SelectList(names, "Id", "FirstName");

          var blocks = await _blockService.GetBlocksAsync();
          ViewBag.Blocks = new SelectList(blocks, "Id", "BlockName");

          var apartmentTypes = await _apartmentTypeService.GetApartmentTypesAsync();
          ViewBag.ApartmentTypes = new SelectList(apartmentTypes, "Id", "Type");
     }

     #endregion
}
