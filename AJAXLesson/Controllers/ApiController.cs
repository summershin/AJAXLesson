using AJAXLesson.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXLesson.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _hostenvironment;
        public ApiController(DemoContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _hostenvironment = environment;
        }

        public IActionResult Index(User user)
        {
            //System.Threading.Thread.Sleep(5000);
            if (String.IsNullOrEmpty(user.name))
            {
                user.name = "Ajax";
            }
            //return Content("Hello World!!");
            //return Content("<h2>Hello World!!</h2>");   
            //return Content("<h2>Hello World!!</h2>","text/html");  讓瀏覽器能編譯html標籤
            //return Content("<h2>Hello World!! 你好!</h2>", "text/html");   
            //return Content("<h2>Hello World!! 你好!</h2>", "text/html",System.Text.Encoding.UTF8);   //讓瀏覽器能編譯中文
            return Content($"{user.name}你好,你的年齡是{user.age}!!", "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult checkUsername(string name)
        {
            //Debug.WriteLine(1);
            string Name = name;

            var q = _context.Members.FirstOrDefault(n => n.Name == name);
            if (q == null)
            {
                return Content(Name + "可使用此暱稱");
            }
            return Content(Name + "暱稱已被使用");
        }
        public IActionResult Register(Member member, IFormFile file)
        {
            string path = Path.Combine(_hostenvironment.WebRootPath, "images", file.FileName);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(filestream);
            }

            Byte[] bytes = null;
            using (var memorystream = new MemoryStream())
            {
                file.CopyTo(memorystream);
                bytes = memorystream.ToArray();
            }
            member.FileName = file.FileName;
            member.FileData = bytes;

            _context.Members.Add(member);
            _context.SaveChanges();
            string info = $"{file.FileName} - {file.ContentType} - {file.Length}";
            return Content(info, "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult City()
        {
            var citys = _context.Addresses.Select(n => n.City).Distinct();
            return Json(citys);
        }
        public IActionResult Distincts(string city)
        {
            var distincts = _context.Addresses.Where(c => c.City == city).Select(n => n.SiteId).Distinct();
            return Json(distincts);
        }
        public IActionResult Roads(string distinct)
        {
            var roads = _context.Addresses.Where(d => d.SiteId == distinct).Select(n => n.Road);
            return Json(roads);
        }
        public IActionResult getImageBytes(int id = 1)
        {
            Member member = _context.Members.Find(id);
            byte[] img = member.FileData;
            return File(img, "image/jpeg");
        }
    }
}
