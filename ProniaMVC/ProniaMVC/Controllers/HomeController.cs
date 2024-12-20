﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;
using ProniaMVC.Models;
using ProniaMVC.ViewModels;
using System.Linq;

namespace ProniaMVC.Controllers
{

    //DI Dependency Injection
    //IOC/ DIP  Inverse of control  / Dependency Inversion Principle
    //IOC Container / DI Container

    public class HomeController:Controller
    {
        private readonly AppDbContext _context;


        public HomeController(AppDbContext context)
        {
            _context = context;
       
        }
        public async Task<IActionResult> Index()
        {

            HomeVM homeVM = new HomeVM {
            Slides=await _context.Slides
            .OrderBy(s => s.Order)
            .Take(2)
            .ToListAsync(),

            NewProducts=await _context.Products
            .OrderByDescending(p=>p.CreatedAt)
            .Take(8)
            .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
            .ToListAsync(),

            };

            return View(homeVM);
        }
        //public IActionResult Test()
        //{
        //    Response.Cookies.Append("name", "Satoro Gojo", new CookieOptions { MaxAge = TimeSpan.FromSeconds(60) });

        //    HttpContext.Session.SetString("name2","emanuel");
            

        //    return Ok();
        //}

        //public IActionResult GetCookie()
        //{
            
        //    return Content(Request.Cookies["name"]+" "+ HttpContext.Session.GetString("name2"));
        //}
    }
}
