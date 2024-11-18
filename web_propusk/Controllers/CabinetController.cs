using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_propusk.Models;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using System.IO;
using System;

namespace web_propusk.Controllers
{
    public class CabinetController : Controller
    {
        

        // GET: CabinetController
        public ActionResult Auth()
        {   

            return View();
        }
        public ActionResult reg()
        {

            return View();
        }
        public ActionResult select()
        {

            return View();
        }
        public ActionResult lichno()
        {
            
            HttpClient http1 = new HttpClient();
            var temp1 = http1.GetFromJsonAsync("http://127.0.0.1:5150/Types/", typeof(Typ[]));
            var typ = (Typ[])temp1.Result;
            ViewBag.typ = typ;
            Global_vars.typs.AddRange(typ);
            HttpClient http = new HttpClient();
            var temp = http.GetFromJsonAsync("http://127.0.0.1:5150/Employe/", typeof(Employer[]));
            var emp = (Employer[])temp.Result;
            ViewBag.emp = emp;
            foreach(var k in emp)
            {
                Global_vars.emps.Add(k);
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> lichno(Zai_Per data)
        {
            HttpClient http = new HttpClient();
            var k = await http.PostAsJsonAsync("http://127.0.0.1:5150/Clients",data.person);
            int? t = await k.Content.ReadFromJsonAsync<int>();
            data.zaivki.People = t;
            
            data.zaivki.Where = Global_vars.emps.Where(prtr=>prtr.Where == data.Where).FirstOrDefault().Id;
            data.zaivki.Type = Global_vars.typs.Where(prtr => prtr.Type == data.Type).FirstOrDefault().Id;
            data.zaivki.Date = DateTime.Now;
            var memoryStream = new MemoryStream();
            if (data.Photo != null)
            {

                data.Photo.CopyTo(memoryStream);
                data.zaivki.Photo = memoryStream.ToArray();
            }
            k = await http.PostAsJsonAsync("http://127.0.0.1:5150/Zaivki", data.zaivki);
            
            
            return Redirect("/");
        }

            public ActionResult cabinet(string Name)
        {

            
            try
            {
                HttpClient http = new HttpClient();
            var temp = http.GetFromJsonAsync("http://127.0.0.1:5150/Clients/email/" + Name, typeof(Person));
                Person baze = (Person)temp.Result;

                HttpClient http3 = new HttpClient();
                temp = http.GetFromJsonAsync("http://127.0.0.1:5150/Zaivki/People/" + baze.Id, typeof(Zaivki[]));
                Zaivki[] baze1 = (Zaivki[])temp.Result;
                ViewBag.baze = baze1;
            }
            catch
            {
                ViewBag.baze = null;
            }
                HttpClient http1 = new HttpClient();
                var temp1 = http1.GetFromJsonAsync("http://127.0.0.1:5150/Types/", typeof(Typ[]));

                Typ[] typ = (Typ[])temp1.Result;
                HttpClient http2 = new HttpClient();
                var temp3 = http2.GetFromJsonAsync("http://127.0.0.1:5150/Employe/", typeof(Employer[]));

                Employer[] Wher = (Employer[])temp3.Result;
                ViewBag.Wher = Wher;
                ViewBag.typ = typ;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> reg(User user)
        {
            
            user.Password = GetHash(user.Password);
            HttpClient http = new HttpClient();
            http.PostAsJsonAsync("http://127.0.0.1:5150/users/reg/",user);
            return Redirect("/Cabinet/Auth/");
        }

        [HttpPost]
       
        public async Task<IActionResult> Auth(User user)
        {
                
                user.Password = GetHash(user.Password);
                HttpClient http = new HttpClient();
                var temp = http.GetFromJsonAsync("http://127.0.0.1:5150/users/reg/"+user.Login+"/"+user.Password, typeof(User));
                if (!(temp.Result == null))
                {
                var Usver = (User)temp.Result;
                    Console.WriteLine("Accept");
                    //await Authenticate(user.Login);
                    
                    return Redirect("/Cabinet/cabinet/?Name="+Usver.Email);

                }
                else
                {
                    Console.WriteLine("Fail");
                    ViewBag.Mess = "Некорректные логин и(или) пароль";
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            return View(user);
            
        }
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "Cookies");
           
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


    }
}
