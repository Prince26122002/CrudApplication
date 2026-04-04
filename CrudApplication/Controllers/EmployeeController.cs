using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeeDbContext _dbContext;

        public EmployeeController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> GetEmployee()
        {
            return View();
        }

        public async Task<IActionResult> Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(obj);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var employeeFromDb = await _dbContext.Employees.FindAsync(id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Update(obj);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _dbContext.Employees.FindAsync(id);
            if (obj != null)
            {
                _dbContext.Employees.Remove(obj);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Employee deleted successfully";

            }
            else
            {
                TempData["ErrorMessage"] = "Employee not found";
                
            }

                return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
           var employeeFromDb =  _dbContext.Employees.FirstOrDefault(e => e.Id == id);
              if (employeeFromDb == null)
              {
                return NotFound();
              }
                return View(employeeFromDb);
        }
    }
}
