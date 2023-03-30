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
    public class IndexModel : PageModel
    {
        private readonly ToDoWebApp.Data.ToDoWebAppContext _context;

        public IndexModel(ToDoWebApp.Data.ToDoWebAppContext context)
        {
            _context = context;
        }

        public IList<ListItem> ListItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ListItem != null)
            {
                ListItem = await _context.ListItem.ToListAsync();
            }
        }
    }
}
