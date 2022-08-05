using Intermediate.MVC.Models;
using Intermediate.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intermediate.MVC.Controllers;

public class BillsController : Controller
{
     private readonly IBillService _billService;
     private readonly IResidentService _residentService;

     public BillsController(IBillService BillService, IResidentService residentService)
     {
          _billService = BillService;
          _residentService = residentService;
     }

     #region Hepsini Getir

     [HttpGet]
     public async Task<IActionResult> GetBills() => View(await _billService.GetBillsAsync());

     #endregion


     #region Yeni Ekle

     public async Task<IActionResult> CreateBill()
     {
          await CreateDropDown();
          return View(new CreateBillCommandRequest());
     }

     [HttpPost]
     public async Task<IActionResult> CreateBill(CreateBillCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               await CreateDropDown();
               var responseMessage = await _billService.CreateBill(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetBills", "Bills");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          await CreateDropDown();
          return View(request);
     }

     #endregion


     #region Güncelle

     public async Task<IActionResult> UpdateBill(int id)
     {
          await CreateDropDown();
          return View(await _billService.GetViewForUpdateBill(id));
     }

     [HttpPost]
     public async Task<IActionResult> UpdateBill(UpdateBillCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               await CreateDropDown();
               var responseMessage = await _billService.UpdateBill(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetBills", "Bills");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          await CreateDropDown();
          return View(request);
     }

     #endregion

     #region Ödeme Yap

     public async Task<IActionResult> UpdateBillForIsPaid(int id)
     {
          var responseMessage = await _billService.IsPaid(id);

          if (responseMessage.IsSuccessStatusCode)
               return RedirectToAction("GetUserBills", "Profiles");
          else
               TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          return RedirectToAction("GetBills", "Bills");
     }
     #endregion

     #region Sil

     public async Task<IActionResult> RemoveBill(int id)
     {
          await _billService.RemoveBill(id);
          return RedirectToAction("GetBills", "Bills");
     }

     #endregion

     #region DropDown

     private async Task CreateDropDown()
     {
          var names = await _residentService.GetResidentNamesAsync();
          ViewBag.Residents = new SelectList(names, "Id", "FirstName");
     }

     #endregion
}
