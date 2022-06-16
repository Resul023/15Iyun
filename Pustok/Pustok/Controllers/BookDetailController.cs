using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class BookDetailController : Controller
    {
        private readonly AppDbContext _context;

        public BookDetailController(AppDbContext context)
        {
            this._context = context;
        }
        public IActionResult GetBookModal(int id)
        {
            Books book = _context.Book.Include(x => x.Author).Include(x => x.Genre).Include(x => x.BookImages).FirstOrDefault(x=>x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return PartialView("_BookModalPartial",book);
        }
    }
}
