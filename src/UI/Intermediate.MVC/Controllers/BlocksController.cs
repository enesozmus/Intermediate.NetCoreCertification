using Intermediate.MVC.Models;
using Intermediate.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intermediate.MVC.Controllers;

public class BlocksController : Controller
{
     private readonly IBlockService _blockService;

     public BlocksController(IBlockService blockService)
     {
          _blockService = blockService;
     }

     #region Hepsini Getir

     [HttpGet]
     public async Task<IActionResult> GetBlocks() => View(await _blockService.GetBlocksAsync());

     #endregion


     #region Yeni Ekle

     public async Task<IActionResult> CreateBlock() => View();

     [HttpPost]
     public async Task<IActionResult> CreateBlock(CreateBlockCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               var responseMessage = await _blockService.CreateBlock(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetBlocks", "Blocks");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
               //return View(request);
          }
          return View(request);
     }

     #endregion


     #region Güncelle

     public async Task<IActionResult> UpdateBlock(int id) => View(await _blockService.GetViewForUpdateBlock(id));

     [HttpPost]
     public async Task<IActionResult> UpdateBlock(UpdateBlockCommandRequest request)
     {
          if (ModelState.IsValid)
          {
               var responseMessage = await _blockService.UpdateBlock(request);

               if (responseMessage.IsSuccessStatusCode)
                    return RedirectToAction("GetBlocks", "Blocks");
               else
                    TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {responseMessage.StatusCode}";
          }
          return View(request);
     }

     #endregion


     #region Sil

     public async Task<IActionResult> RemoveBlock(int id)
     {
          await _blockService.RemoveBlock(id);
          return RedirectToAction("GetBlocks", "Blocks");
     }

     #endregion
}
