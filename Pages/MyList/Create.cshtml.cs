using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Pages.MyList
{
    public class CreateModel : PageModel
    {
        private readonly ToDoWebApp.Data.ToDoWebAppContext _context;

        public CreateModel(ToDoWebApp.Data.ToDoWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ListItem ListItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ListItem == null || ListItem == null)
            {
                return Page();
            }

            _context.ListItem.Add(ListItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
