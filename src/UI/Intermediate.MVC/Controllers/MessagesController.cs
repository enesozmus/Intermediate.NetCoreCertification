using Intermediate.MVC.Models;
using Intermediate.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intermediate.MVC.Controllers;

public class MessagesController : Controller
{
     private readonly IMessageService _messageService;
     private readonly IResidentService _residentService;

     public MessagesController(IMessageService messageService, IResidentService residentService)
     {
          _messageService = messageService;
          _residentService = residentService;
     }

     #region Gönderilen ve Gelen Mesajları Getir

     [HttpGet]
     public async Task<IActionResult> GetSentMessages() => View(await _messageService.GetSentMessagesAsync());

     [HttpGet]
     public async Task<IActionResult> GetIncomingMessages() => View(await _messageService.GetIncomingMessagesAsync());

     #endregion


     #region Yeni Ekle

     public async Task<IActionResult> SendMessage()
     {
          await CreateDropDown();
          return View(new SendMessageCommandRequest());
     }

     [HttpPost]
     public async Task<IActionResult> SendMessage(SendMessageCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               await CreateDropDown();
               var responseMessage = await _messageService.CreateMessage(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetSentMessages", "Messages");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          await CreateDropDown();
          return View(request);
     }

     #endregion


     #region Güncelle

     public async Task<IActionResult> UpdateMessage(int id)
     {
          await CreateDropDown();
          return View(await _messageService.GetViewForUpdateMessage(id));
     }

     [HttpPost]
     public async Task<IActionResult> UpdateMessage(UpdateMessageCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               await CreateDropDown();
               var responseMessage = await _messageService.UpdateMessage(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetSentMessages", "Messages");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          await CreateDropDown();
          return View(request);
     }

     #endregion


     #region Sil

     public async Task<IActionResult> RemoveMessage(int id)
     {
          await _messageService.RemoveMessage(id);
          return RedirectToAction("GetSentMessages", "Messages");
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
