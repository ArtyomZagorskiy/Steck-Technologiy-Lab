using Microsoft.AspNetCore.Mvc;
using Lab_5_ASP_NET.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Lab_5_ASP_NET.Controllers
{
    public class CookbookController : Controller
    {
        CookbookContext _db;
        public CookbookController(CookbookContext ctx)
        {
            _db = ctx;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _db.recipes.Include(r => r.Components).ThenInclude(c => c.Product).ToListAsync();
            return View(posts);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                
                var preparationTimeInput = recipe.PreparationTime.ToString();

                if (!string.IsNullOrEmpty(preparationTimeInput))
                {
                    TimeSpan parsedTime;
                    if (TimeSpan.TryParse(preparationTimeInput, out parsedTime))
                    {
                        
                        recipe.PreparationTime = parsedTime;
                    }
                    else
                    {
                        ModelState.AddModelError("PreparationTime", "Invalid time format. Please use 'hh:mm' format.");
                        return View(recipe);
                    }
                }

                _db.Add(recipe);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        
            return View(recipe);
        }

     
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _db.recipes.Include(r => r.Components)
                                          .ThenInclude(c => c.Product)
                                          .FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(recipe);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.recipes.Any(e => e.Id == recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _db.recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);  
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _db.recipes.FindAsync(id);
            if (recipe != null)
            {
                _db.recipes.Remove(recipe); 
                await _db.SaveChangesAsync();  
            }

            return RedirectToAction(nameof(Index)); 
        }
    }
}
