using CourseApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers{
    public class StudentController : Controller{

        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model){
            _context.Students.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }

            var std = await _context.Students.FindAsync(id);

            if(std == null){
                return NotFound();
            }

            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student model){
            if(id != model.studentID){
                return NotFound();
            }

            if(ModelState.IsValid){
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Students.Any(o => o.studentID == model.studentID)){
                        return NotFound();
                    }

                    else{
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            if(id == null){
                return NotFound();
            }

            var std = await _context.Students.FindAsync(id);

            if(std == null){
                return NotFound();
            }

            return View(std);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var std = await _context.Students.FindAsync(id);
            if(std == null){
                return NotFound();     
            }
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    
    
    }
}