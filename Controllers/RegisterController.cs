using Lab01.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Lab01.Controllers
{
    public class RegisterController : Controller
    {
        private IHostingEnvironment hosting;
        public RegisterController(IHostingEnvironment _hosting)
        {
            hosting = _hosting;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult XuLy(PersonViewModel m, IFormFile FHinh)
        {
            // kiem tra xem co upload hinh khong
            if (FHinh != null)
            {
                // lay ten hinh
                string FileName = Path.GetFileName(FHinh.FileName);
                // lay duong dan luu hinh
                string UploadPath = Path.Combine(hosting.WebRootPath, "images");
                // luu hinh vao duong dan
                string FilePath = Path.Combine(UploadPath, FileName);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    FHinh.CopyTo(stream);
                }
                m.Picture = FileName;
            }
            //if(Validator(m.FullName, m.BirthDay))
            //{
            //    return BadRequest();
            //}
            return PartialView("_Xuly", m);
        }
        //private bool Validator(string fullName, DateTime? birthDay)
        //{
        //    if (string.IsNullOrWhiteSpace(fullName))
        //    {
        //        Response.StatusCode = 400;
        //        return false;
                
        //    }

        //    if (birthDay > DateTime.Now)
        //    {
        //        Response.StatusCode = 400;
        //        return false;
        //    }

        //    if (birthDay < DateTime.Now.AddYears(-100))
        //    {
        //        Response.StatusCode = 400;
        //        return false;
        //    }
        //    return true;
        //}

    }
}
