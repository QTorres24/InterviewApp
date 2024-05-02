using InterviewApp.Data;
using InterviewApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace InterviewApp.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LibraryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lobby()
        {
            var library = await dbContext.Library.ToListAsync();

            return View(library);
        }

        [HttpPost]
        public async Task<IActionResult> Borrow()
        {
            var library = await dbContext.Library.FirstAsync();
            
            if (library.HasBooks)
            {
                library.Books--;

                if (library.Books == 0)
                {
                    library.HasBooks = false;
                }

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Lobby", "Library");
        }
    }
}
