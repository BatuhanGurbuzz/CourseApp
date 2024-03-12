using System.Data;
using CourseApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CourseApp.Controllers{
    public class CourseController:Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            _context.Courses.Add(model);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }

            var cour = await _context.Courses.FindAsync(id);

            if(cour == null){
                return NotFound();
            }

            return View(cour);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course model){
            if(id != model.courseID){
                return NotFound();
            }

            if(ModelState.IsValid){
                try{
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException){
                    if(!_context.Courses.Any(o => o.courseID == model.courseID)){
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

            var cour = await _context.Courses.FindAsync(id);

            if(cour == null){
                return NotFound();
            }

            return View(cour);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id){

            var cour = await _context.Courses.FindAsync(id);
            if(cour == null){
                return NotFound();
            }

            _context.Courses.Remove(cour);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}