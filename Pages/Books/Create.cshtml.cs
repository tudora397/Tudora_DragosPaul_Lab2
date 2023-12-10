﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tudora_Dragos_Lab2.Data;
using Tudora_Dragos_Lab2.Models;

namespace Tudora_Dragos_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Tudora_Dragos_Lab2.Data.Tudora_Dragos_Lab2Context _context;
        public CreateModel(Tudora_Dragos_Lab2.Data.Tudora_Dragos_Lab2Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            /* var authorList = _context.Author.Select(x => new
            {
            x.ID,
            FullName = x.LastName + " " + x.FirstName
            });
            */
            // daca am adaugat o proprietate FullName in clasa Author
            ViewData["AuthorID"] = new SelectList("ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID",
            "PublisherName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
