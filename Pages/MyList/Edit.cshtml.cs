using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Pages.MyList
{
    public class EditModel : PageModel
    {
        private readonly ToDoWebApp.Data.ToDoWebAppContext _context;

        public EditModel(ToDoWebApp.Data.ToDoWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ListItem ListItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ListItem == null)
            {
                return NotFound();
            }

            var listitem =  await _context.ListItem.FirstOrDefaultAsync(m => m.Id == id);
            if (listitem == null)
            {
                return NotFound();
            }
            ListItem = listitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ListItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListItemExists(ListItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ListItemExists(int id)
        {
          return (_context.ListItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
