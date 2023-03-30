using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Pages.MyList
{
    public class DetailsModel : PageModel
    {
        private readonly ToDoWebApp.Data.ToDoWebAppContext _context;

        public DetailsModel(ToDoWebApp.Data.ToDoWebAppContext context)
        {
            _context = context;
        }

      public ListItem ListItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ListItem == null)
            {
                return NotFound();
            }

            var listitem = await _context.ListItem.FirstOrDefaultAsync(m => m.Id == id);
            if (listitem == null)
            {
                return NotFound();
            }
            else 
            {
                ListItem = listitem;
            }
            return Page();
        }
    }
}
