using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputerShop.WebUI.Data;
using ComputerShop.WebUI.Models;
using ComputerShop.WebUI.ViewModels.Country;

namespace ComputerShop.WebUI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ComputerShopContext _context;
        private readonly int _pageSize;

        public CountriesController(ComputerShopContext context)
        {
            _context = context;
            _pageSize = 5;
        }

        // GET: Countries
        public async Task<IActionResult> Index(string selectedCountryName, int? page, SortState? sortOrder)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            GetSetCookieValuesOrSetDefault(ref selectedCountryName, ref page, ref sortOrder);

            var countries = _context.Countries.AsQueryable();

            countries = Filter(countries, selectedCountryName);

            countries = Sort(countries, (SortState)sortOrder);

            var count = await countries.CountAsync();

            countries = Paging(ref page, countries, count);

            IndexCountryViewModel model = new IndexCountryViewModel
            {
                Countries = await countries.ToListAsync(),
                FilterCountryViewModel = new FilterCountryViewModel(selectedCountryName),
                SortCountryViewModel = new SortCountryViewModel((SortState)sortOrder),
                PageViewModel = new ViewModels.PageViewModel(count, (int)page, _pageSize)
            };

            return View(model);
        }

        private IQueryable<Country> Paging(ref int? page, IQueryable<Country> countries, int count)
        {
            /*
             * Если мы меняем фильтр и находимся на странице, значение которой превышает максимальное количество страниц новых записей,
             * то необходимо перейти на максимальную страницу для записей с текущей фильтрацией
             */
            var pageModel = new ViewModels.PageViewModel(count, 1, _pageSize);
            if (page > pageModel.TotalPages)
            {
                page = pageModel.TotalPages > 0 ? pageModel.TotalPages : 1;
                Response.Cookies.Append(User.Identity.Name + "countryPage", page.ToString());
            }
            return countries.Skip(((int)page - 1) * _pageSize).Take(_pageSize);
        }

        private IQueryable<Country> Sort(IQueryable<Country> countries, SortState sortOrder)
        {
            switch(sortOrder)
            {
                case SortState.CountryNameAsc:
                    countries = countries.OrderBy(c => c.Name);
                    break;
                case SortState.CountryNameDesc:
                    countries = countries.OrderByDescending(c => c.Name);
                    break;
            }
            return countries;
        }

        private IQueryable<Country> Filter(IQueryable<Country> countries, string selectedCountryName)
        {
            if(!string.IsNullOrEmpty(selectedCountryName))
            {
                countries = countries.Where(c => c.Name.Contains(selectedCountryName));
            }
            return countries;
        }

        private void GetSetCookieValuesOrSetDefault(ref string selectedCountryName, ref int? page, ref SortState? sortOrder)
        {
            if (string.IsNullOrEmpty(selectedCountryName))
            {
                /*
                 * Если пользователь обращается из формы фильтрации, то тогда даже если передаётся пустая строка, значит он ввёл пустую строку
                 * и все компоненты необходимо фильтровать по пустому полю модели
                 */
                if (HttpContext.Request.Query["isFromFilter"] == "true")
                {
                    selectedCountryName = "";
                    Response.Cookies.Append(User.Identity.Name + "countrySelectedName", "");
                }
                else
                {
                    Request.Cookies.TryGetValue(User.Identity.Name + "countrySelectedName", out selectedCountryName);
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "countrySelectedName", selectedCountryName);
            }
            if (page == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "countryPage", out string pageStr))
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
                Response.Cookies.Append(User.Identity.Name + "countryPage", page.ToString());
            }
            if (sortOrder == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "countrySortState", out string sortStateStr))
                {
                    sortOrder = (SortState)Enum.Parse(typeof(SortState), sortStateStr);
                }
                else
                {
                    sortOrder = SortState.CountryNameAsc;
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "countrySortState", sortOrder.ToString());
            }
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? countryId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (countryId == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == countryId);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Country country)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? countryId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (countryId == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(countryId);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int countryId, [Bind("Id,Name")] Country country)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (countryId != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
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
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? countryId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (countryId == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == countryId);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int countryId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            var country = await _context.Countries.FindAsync(countryId);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
