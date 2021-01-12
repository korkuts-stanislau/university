using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputerShop.WebUI.Data;
using ComputerShop.WebUI.Models;
using ComputerShop.WebUI.ViewModels.Manufacturer;

namespace ComputerShop.WebUI.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly int _pageSize;
        private readonly ComputerShopContext _context;

        public ManufacturersController(ComputerShopContext context)
        {
            _pageSize = 5;
            _context = context;
        }

        // GET: Manufacturers
        public async Task<IActionResult> Index(string selectedManufacturerName, int? page, SortState? sortOrder)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            GetSetCookieValuesOrSetDefault(ref selectedManufacturerName, ref page, ref sortOrder);

            var manufacturers = _context.Manufacturers.AsQueryable();

            manufacturers = Filter(manufacturers, selectedManufacturerName);

            manufacturers = Sort(manufacturers, (SortState)sortOrder);

            var count = await manufacturers.CountAsync();

            manufacturers = Paging(ref page, manufacturers, count);

            IndexManufacturerViewModel model = new IndexManufacturerViewModel
            {
                Manufacturers = await manufacturers.ToListAsync(),
                FilterManufacturerViewModel = new FilterManufacturerViewModel(selectedManufacturerName),
                SortManufacturerViewModel = new SortManufacturerViewModel((SortState)sortOrder),
                PageViewModel = new ViewModels.PageViewModel(count, (int)page, _pageSize)
            };

            return View(model);
        }

        private IQueryable<Manufacturer> Paging(ref int? page, IQueryable<Manufacturer> manufacturers, int count)
        {
            /*
             * Если мы меняем фильтр и находимся на странице, значение которой превышает максимальное количество страниц новых записей,
             * то необходимо перейти на максимальную страницу для записей с текущей фильтрацией
             */
            var pageModel = new ViewModels.PageViewModel(count, 1, _pageSize);
            if (page > pageModel.TotalPages)
            {
                page = pageModel.TotalPages > 0 ? pageModel.TotalPages : 1;
                Response.Cookies.Append(User.Identity.Name + "manufacturerPage", page.ToString());
            }
            return manufacturers.Skip(((int)page - 1) * _pageSize).Take(_pageSize);
        }

        private IQueryable<Manufacturer> Sort(IQueryable<Manufacturer> manufacturers, SortState sortOrder)
        {
            switch (sortOrder)
            {
                case SortState.ManufacturerNameAsc:
                    manufacturers = manufacturers.OrderBy(c => c.Name);
                    break;
                case SortState.ManufacturerNameDesc:
                    manufacturers = manufacturers.OrderByDescending(c => c.Name);
                    break;
            }
            return manufacturers;
        }

        private IQueryable<Manufacturer> Filter(IQueryable<Manufacturer> manufacturers, string selectedManufacturerName)
        {
            if (!string.IsNullOrEmpty(selectedManufacturerName))
            {
                manufacturers = manufacturers.Where(c => c.Name.Contains(selectedManufacturerName));
            }
            return manufacturers;
        }

        private void GetSetCookieValuesOrSetDefault(ref string selectedManufacturerName, ref int? page, ref SortState? sortOrder)
        {
            if (string.IsNullOrEmpty(selectedManufacturerName))
            {
                /*
                 * Если пользователь обращается из формы фильтрации, то тогда даже если передаётся пустая строка, значит он ввёл пустую строку
                 * и все компоненты необходимо фильтровать по пустому полю модели
                 */
                if (HttpContext.Request.Query["isFromFilter"] == "true")
                {
                    selectedManufacturerName = "";
                    Response.Cookies.Append(User.Identity.Name + "manufacturerSelectedName", "");
                }
                else
                {
                    Request.Cookies.TryGetValue(User.Identity.Name + "manufacturerSelectedName", out selectedManufacturerName);
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "manufacturerSelectedName", selectedManufacturerName);
            }
            if (page == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "manufacturerPage", out string pageStr))
                {
                    int pg;
                    if (int.TryParse(pageStr, out pg))
                    {
                        page = pg;
                    }
                    else
                    {
                        page = 1;
                    }
                }
                else
                {
                    page = 1;
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "manufacturerPage", page.ToString());
            }
            if (sortOrder == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "manufacturerSortState", out string sortStateStr))
                {
                    sortOrder = (SortState)Enum.Parse(typeof(SortState), sortStateStr);
                }
                else
                {
                    sortOrder = SortState.ManufacturerNameAsc;
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "manufacturerSortState", sortOrder.ToString());
            }
        }

        // GET: Manufacturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public IActionResult Create()
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Manufacturer manufacturer)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                _context.Add(manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Manufacturer manufacturer)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.Id))
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
            return View(manufacturer);
        }

        // GET: Manufacturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }
    }
}
