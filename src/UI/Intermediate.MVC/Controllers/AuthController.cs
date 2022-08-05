using Intermediate.MVC.Extensions;
using Intermediate.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Intermediate.MVC.Controllers;

public class AuthController : Controller
{
     private readonly IHttpClientFactory _httpClientFactory;

     public AuthController(IHttpClientFactory httpClientFactory)
     {
          _httpClientFactory = httpClientFactory;
     }

     #region Giriş Yap

     [HttpGet]
     public IActionResult Login()
     {
          if (HttpContext.HasCookie("Authorization"))
          {
               //Kullanıcı daha önce giriş yapmış ise yapılacak işlemler
               return RedirectToAction("Index", "Home");
          }

          return View();
     }

     [HttpPost]
     public async Task<IActionResult> Login(LoginCommandRequest loginModel)
     {
          using(var httpClient = new HttpClient())
          {
               StringContent content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
               var response = await httpClient.PostAsync("http://localhost:5166/api/Auth/login", content);

               if (response.IsSuccessStatusCode)
               {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var loginResponse = System.Text.Json.JsonSerializer.Deserialize<LoginCommandResponse>(jsonData, new JsonSerializerOptions
                    {
                         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    });
                    JwtSecurityTokenHandler handler = new();
                    var token = handler.ReadJwtToken(loginResponse?.Token);
                    if (token != null)
                    {
                         var claims = token.Claims.ToList();
                         claims.Add(new Claim("accessToken", loginResponse?.Token == null ? "" : loginResponse.Token));
                         var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                         var authProps = new AuthenticationProperties
                         {
                              AllowRefresh = false,
                              //ExpiresUtc = loginResponse?.ExpireDate,
                              IsPersistent = true
                         };
                         await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProps);
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                         return View(loginModel);
                    }
               }

          }
          //string url = $"/api/Auth/LogIn?email={user.Email}&password={user.Password}";
          return BadRequest();
     }

     #endregion

     #region Çıkış Yap

     public IActionResult Logout()
     {
          HttpContext.DeleteCookie("IntermediateCertificate");
          return RedirectToAction("Login");
     }

     #endregion
}
