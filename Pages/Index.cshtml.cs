using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.Models;

namespace TodoListApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoListApp.Data.ApplicationDbContext _context;

        public IndexModel(TodoListApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TodoItem = await _context.TodoItems.ToListAsync();
        }
        public async Task<IActionResult> OnPostUpdateStatusAsync(int itemId, bool isComplete)
        {
            
            var item = await _context.TodoItems.FindAsync(itemId);
            if (item != null)
            {
                item.IsComplete = isComplete;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }


    }
}
