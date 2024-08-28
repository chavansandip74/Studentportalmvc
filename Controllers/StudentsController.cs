﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentportal.Data;
using Studentportal.Models;
using Studentportal.Models.Entities;

namespace Studentportal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
       [HttpPost]
public async Task<IActionResult> Add(AddStudentViewModel viewModel)
{
    var student = new Student
    {
        Name = viewModel.Name,
        Email = viewModel.Email,
        Phone = viewModel.Phone,
        Subscribed = viewModel.Subscribed
    };
    await dbContext.Students.AddAsync(student);
    await dbContext.SaveChangesAsync();
    
    return RedirectToAction("List"); // Redirect to the List action
}

        [HttpGet]
        public async Task<IActionResult>List()
        {
            var students=await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult>Edit(Guid Id)
        {
            var student= await dbContext.Students.FindAsync(Id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
                return RedirectToAction("List","Students");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var student = await dbContext.Students.FindAsync(Id);
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

    }
}
