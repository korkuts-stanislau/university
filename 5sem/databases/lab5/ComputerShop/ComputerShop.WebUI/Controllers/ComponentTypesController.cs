using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputerShop.WebUI.Data;
using ComputerShop.WebUI.Models;
using ComputerShop.WebUI.ViewModels.ComponentType;

namespace ComputerShop.WebUI.Controllers
{
    public class ComponentTypesController : Controller
    {
        private readonly int _pageSize;
        private readonly ComputerShopContext _context;

        public ComponentTypesController(ComputerShopContext context)
        {
            _pageSize = 5;
            _context = context;
        }

        // GET: ComponentTypes
        public async Task<IActionResult> Index(string selectedComponentTypeName, int? page, SortState? sortOrder)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            GetSetCookieValuesOrSetDefault(ref selectedComponentTypeName, ref page, ref sortOrder);

            var componentTypes = _context.ComponentTypes.AsQueryable();

            componentTypes = Filter(componentTypes, selectedComponentTypeName);

            componentTypes = Sort(componentTypes, (SortState)sortOrder);

            var count = await componentTypes.CountAsync();

            componentTypes = Paging(ref page, componentTypes, count);

            IndexComponentTypeViewModel model = new IndexComponentTypeViewModel
            {
                ComponentTypes = await componentTypes.ToListAsync(),
                FilterComponentTypeViewModel = new FilterComponentTypeViewModel(selectedComponentTypeName),
                SortComponentTypeViewModel = new SortComponentTypeViewModel((SortState)sortOrder),
                PageViewModel = new ViewModels.PageViewModel(count, (int)page, _pageSize)
            };

            return View(model);
        }

        private IQueryable<ComponentType> Paging(ref int? page, IQueryable<ComponentType> componentTypes, int count)
        {
            /*
             * Если мы меняем фильтр и находимся на странице, значение которой превышает максимальное количество страниц новых записей,
             * то необходимо перейти на максимальную страницу для записей с текущей фильтрацией
             */
            var pageModel = new ViewModels.PageViewModel(count, 1, _pageSize);
            if (page > pageModel.TotalPages)
            {
                page = pageModel.TotalPages > 0 ? pageModel.TotalPages : 1;
                Response.Cookies.Append(User.Identity.Name + "componentTypePage", page.ToString());
            }
            return componentTypes.Skip(((int)page - 1) * _pageSize).Take(_pageSize);
        }

        private IQueryable<ComponentType> Sort(IQueryable<ComponentType> componentTypes, SortState sortOrder)
        {
            switch (sortOrder)
            {
                case SortState.ComponentTypeNameAsc:
                    componentTypes = componentTypes.OrderBy(c => c.Name);
                    break;
                case SortState.ComponentTypeNameDesc:
                    componentTypes = componentTypes.OrderByDescending(c => c.Name);
                    break;
            }
            return componentTypes;
        }

        private IQueryable<ComponentType> Filter(IQueryable<ComponentType> componentTypes, string selectedCountryName)
        {
            if (!string.IsNullOrEmpty(selectedCountryName))
            {
                componentTypes = componentTypes.Where(c => c.Name.Contains(selectedCountryName));
            }
            return componentTypes;
        }

        private void GetSetCookieValuesOrSetDefault(ref string selectedComponentTypeName, ref int? page, ref SortState? sortOrder)
        {
            if (string.IsNullOrEmpty(selectedComponentTypeName))
            {
                /*
                 * Если пользователь обращается из формы фильтрации, то тогда даже если передаётся пустая строка, значит он ввёл пустую строку
                 * и все компоненты необходимо фильтровать по пустому полю модели
                 */
                if (HttpContext.Request.Query["isFromFilter"] == "true")
                {
                    selectedComponentTypeName = "";
                    Response.Cookies.Append(User.Identity.Name + "componentTypeSelectedName", "");
                }
                else
                {
                    Request.Cookies.TryGetValue(User.Identity.Name + "componentTypeSelectedName", out selectedComponentTypeName);
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "componentTypeSelectedName", selectedComponentTypeName);
            }
            if (page == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "componentTypePage", out string pageStr))
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
                Response.Cookies.Append(User.Identity.Name + "componentTypePage", page.ToString());
            }
            if (sortOrder == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "componentTypeSortState", out string sortStateStr))
                {
                    sortOrder = (SortState)Enum.Parse(typeof(SortState), sortStateStr);
                }
                else
                {
                    sortOrder = SortState.ComponentTypeNameAsc;
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "componentTypeSortState", sortOrder.ToString());
            }
        }

        // GET: ComponentTypes/Details/5
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

            var componentType = await _context.ComponentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (componentType == null)
            {
                return NotFound();
            }

            return View(componentType);
        }

        // GET: ComponentTypes/Create
        public IActionResult Create()
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: ComponentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ComponentType componentType)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                _context.Add(componentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(componentType);
        }

        // GET: ComponentTypes/Edit/5
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

            var componentType = await _context.ComponentTypes.FindAsync(id);
            if (componentType == null)
            {
                return NotFound();
            }
            return View(componentType);
        }

        // POST: ComponentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ComponentType componentType)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id != componentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentTypeExists(componentType.Id))
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
            return View(componentType);
        }

        // GET: ComponentTypes/Delete/5
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

            var componentType = await _context.ComponentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (componentType == null)
            {
                return NotFound();
            }

            return View(componentType);
        }

        // POST: ComponentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            var componentType = await _context.ComponentTypes.FindAsync(id);
            _context.ComponentTypes.Remove(componentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentTypeExists(int id)
        {
            return _context.ComponentTypes.Any(e => e.Id == id);
        }
    }
}
