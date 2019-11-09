﻿using IntroductionToNetCore.Models;
using IntroductionToNetCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntroductionToNetCore.Controllers
{
    //[Route("[controller]")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public IHostingEnvironment HostingEnvironment { get; }

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            HostingEnvironment = hostingEnvironment;
        }

        //[Route("")]
        //[Route("[action]")] // [action] will be replaced by Index 
        //[Route("~/")] // don't combines hierarchical attribute.
        [AllowAnonymous]
        public ViewResult Index()
        {
            var AllEmployeeFromModel = _employeeRepository.GetAllEmployee();
            return View(AllEmployeeFromModel);
        }

        //[Route("[action]/{Id?}")]
        [AllowAnonymous]
        public ViewResult Details(int? Id)
        {
            //throw new Exception("Error in Details view");

            Employee employee = _employeeRepository.GetEmployee(Id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                employee = employee,
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);

            //Employee EmployeeFromModel = _employeeRepository.GetEmployee(1);
            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "Employee Details";
            //return View();

            //ViewBag.Employee = EmployeeFromModel;
            //ViewBag.PageTitle = "Employee Details";
            //return View(EmployeeFromModel);


            /*
            //return View(model);
            //return View("Test");
            //return View("MyViews/Test.cshtml"); // completely different path.
            //return View("../Test/Update");
            return View("../../MyViews/Test");
            */
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(HostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                _employeeRepository.Update(employee);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Create ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);

                return RedirectToAction("Details", new { id = newEmployee.Id });
            }

            return View();
        }


        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
