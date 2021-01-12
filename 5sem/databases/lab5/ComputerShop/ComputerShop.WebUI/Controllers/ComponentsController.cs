using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.WebUI.Models;
using ComputerShop.WebUI.ViewModels.Component;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.WebUI.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly int _pageSize;
        private readonly Data.ComputerShopContext _db;
        Services.CachingService _cachingService;
        public ComponentsController(Data.ComputerShopContext db, Services.CachingService cachingService)
        {
            _pageSize = 5;
            _db = db;
            _cachingService = cachingService;
        }
        // GET: ComponentsController
        public async Task<ActionResult> Index(int? selectedCountryId, int? selectedManufacturerId, int? selectedComponentTypeId, string selectedModelName,
            int? page, SortState? sortOrder)
        {
            if (!User.IsInRole(Areas.Identity.Roles.User))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (_cachingService.TryGetValue($"components-{selectedCountryId}-{selectedManufacturerId}-{selectedComponentTypeId}-{selectedModelName}" +
                $"-{page}-{sortOrder}", out IndexComponentViewModel cachedModel))
            {
                return View(cachedModel);
            }
            else
            {
                GetSetCookieValuesOrSetDefault(ref selectedCountryId, ref selectedManufacturerId, ref selectedComponentTypeId, ref selectedModelName, ref page, ref sortOrder);

                IQueryable<Component> components = _db.Components
                    .Include(c => c.ComponentType)
                    .Include(c => c.Manufacturer)
                    .Include(c => c.Country);

                components = Filter(components, selectedCountryId, selectedManufacturerId, selectedComponentTypeId, selectedModelName);

                components = Sort(components, (SortState)sortOrder);

                var count = await components.CountAsync();

                components = Paging(ref page, components, count);

                var countries = _db.Countries;
                var manufacturers = _db.Manufacturers;
                var componentTypes = _db.ComponentTypes;

                IndexComponentViewModel model = new IndexComponentViewModel
                {
                    Components = await components.ToListAsync(),
                    FilterComponentViewModel = new FilterComponentViewModel(await componentTypes.ToListAsync(), await manufacturers.ToListAsync(), await countries.ToListAsync(),
                                  selectedComponentTypeId, selectedManufacturerId, selectedCountryId, selectedModelName),
                    SortComponentViewModel = new SortComponentViewModel((SortState)sortOrder),
                    PageViewModel = new ViewModels.PageViewModel(count, (int)page, _pageSize)
                };

                _cachingService.Set($"components-{selectedCountryId}-{selectedManufacturerId}-{selectedComponentTypeId}-{selectedModelName}" +
                $"-{page}-{sortOrder}", model);

                return View(model);
            }
        }

        private IQueryable<Component> Paging(ref int? page, IQueryable<Component> components, int count)
        {
            /*
             * Если мы меняем фильтр и находимся на странице, значение которой превышает максимальное количество страниц новых записей,
             * то необходимо перейти на максимальную страницу для записей с текущей фильтрацией
             */
            var pageModel = new ViewModels.PageViewModel(count, 1, _pageSize);
            if (page > pageModel.TotalPages)
            {
                page = pageModel.TotalPages > 0 ? pageModel.TotalPages : 1;
                Response.Cookies.Append(User.Identity.Name + "componentPage", page.ToString());
            }
            return components.Skip(((int)page - 1) * _pageSize).Take(_pageSize);
        }

        private void GetSetCookieValuesOrSetDefault(ref int? selectedCountryId, ref int? selectedManufacturerId, ref int? selectedComponentTypeId, ref string selectedModelName, ref int? page, ref SortState? sortOrder)
        {
            if (selectedCountryId == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "componentSelectedCountryId", out string selectedCountryIdStr))
                {
                    selectedCountryId = int.Parse(selectedCountryIdStr);
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "componentSelectedCountryId", selectedCountryId.ToString());
            }
            if (selectedManufacturerId == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "componentSelectedManufacturerId", out string selectedManufacturerIdStr))
                {
                    selectedManufacturerId = int.Parse(selectedManufacturerIdStr);
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "componentSelectedManufacturerId", selectedManufacturerId.ToString());
            }
            if (selectedComponentTypeId == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "componentSelectedComponentTypeId", out string selectedComponentTypeIdStr))
                {
                    selectedComponentTypeId = int.Parse(selectedComponentTypeIdStr);
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "componentSelectedComponentTypeId", selectedComponentTypeId.ToString());
            }
            if (string.IsNullOrEmpty(selectedModelName))
            {
                /*
                 * Если пользователь обращается из формы фильтрации, то тогда даже если передаётся пустая строка, значит он ввёл пустую строку
                 * и все компоненты необходимо фильтровать по пустому полю модели
                 */
                if (HttpContext.Request.Query["isFromFilter"] == "true")
                {
                    selectedModelName = "";
                    Response.Cookies.Append(User.Identity.Name + "componentSelectedModelName", "");
                }
                else
                {
                    Request.Cookies.TryGetValue(User.Identity.Name + "componentSelectedModelName", out selectedModelName);
                }
            }
            else
            {
                Response.Cookies.Append(User.Identity.Name + "componentSelectedModelName", selectedModelName);
            }
            if (page == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "componentPage", out string pageStr))
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
                Response.Cookies.Append(User.Identity.Name + "componentPage", page.ToString());
            }
            if (sortOrder == null)
            {
                if (Request.Cookies.TryGetValue(User.Identity.Name + "componentSortState", out string sortStateStr))
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
                Response.Cookies.Append(User.Identity.Name + "componentSortState", sortOrder.ToString());
            }
        }

        private IQueryable<Component> Filter(IQueryable<Component> components,
            int? selectedCountryId, int? selectedManufacturerId, int? selectedComponentTypeId, string selectedModelName)
        {
            if (selectedCountryId != null && selectedCountryId != 0)
            {
                components = components.Where(component => component.CountryId == selectedCountryId);
            }
            if (selectedManufacturerId != null && selectedManufacturerId != 0)
            {
                components = components.Where(component => component.ManufacturerId == selectedManufacturerId);
            }
            if (selectedComponentTypeId != null && selectedComponentTypeId != 0)
            {
                components = components.Where(component => component.ComponentTypeId == selectedComponentTypeId);
            }
            if (!string.IsNullOrEmpty(selectedModelName))
            {
                components = components.Where(component => component.Model.Contains(selectedModelName));
            }
            return components;
        }

        private IQueryable<Component> Sort(IQueryable<Component> components, SortState sortOrder)
        {
            switch (sortOrder)
            {
                case SortState.ComponentTypeNameAsc:
                    components = components.OrderBy(c => c.ComponentType.Name);
                    break;
                case SortState.ComponenTypeNameDesc:
                    components = components.OrderByDescending(c => c.ComponentType.Name);
                    break;
                case SortState.ModelAsc:
                    components = components.OrderBy(c => c.Model);
                    break;
                case SortState.ModelDesc:
                    components = components.OrderByDescending(c => c.Model);
                    break;
                case SortState.ManufacturerNameAsc:
                    components = components.OrderBy(c => c.Manufacturer.Name);
                    break;
                case SortState.ManufacturerNameDesc:
                    components = components.OrderByDescending(c => c.Manufacturer.Name);
                    break;
                case SortState.CountryNameAsc:
                    components = components.OrderBy(c => c.Country.Name);
                    break;
                case SortState.CountryNameDesc:
                    components = components.OrderByDescending(c => c.Country.Name);
                    break;
                case SortState.ReleaseDateAsc:
                    components = components.OrderBy(c => c.ReleaseDate);
                    break;
                case SortState.ReleaseDateDesc:
                    components = components.OrderByDescending(c => c.ReleaseDate);
                    break;
                case SortState.CharacteristicsAsc:
                    components = components.OrderBy(c => c.Characteristics);
                    break;
                case SortState.CharacteristicsDesc:
                    components = components.OrderByDescending(c => c.Characteristics);
                    break;
                case SortState.WarrantyInMonthsAsc:
                    components = components.OrderBy(c => c.WarrantyInMonths);
                    break;
                case SortState.WarrantyInMonthsDesc:
                    components = components.OrderByDescending(c => c.WarrantyInMonths);
                    break;
                case SortState.DescriptionAsc:
                    components = components.OrderBy(c => c.Description);
                    break;
                case SortState.DescriptionDesc:
                    components = components.OrderByDescending(c => c.Description);
                    break;
                case SortState.PriceAsc:
                    components = components.OrderBy(c => c.Price);
                    break;
                case SortState.PriceDesc:
                    components = components.OrderByDescending(c => c.Price);
                    break;
            }
            return components;
        }

        // GET: ComponentsController/Create
        public async Task<ActionResult> Create()
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Components");
            }
            ViewBag.ComponentTypes = new SelectList(await _db.ComponentTypes.ToListAsync(), "Id", "Name");
            ViewBag.Countries = new SelectList(await _db.Countries.ToListAsync(), "Id", "Name");
            ViewBag.Manufacturers = new SelectList(await _db.Manufacturers.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: ComponentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Component component)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Components");
            }
            try
            {
                if (component.ReleaseDate < new DateTime(1980, 1, 1))
                {
                    ModelState.AddModelError("ReleaseDate", "Date must be later than 01.01.1980");
                }
                else if (component.ReleaseDate > DateTime.Now)
                {
                    ModelState.AddModelError("ReleaseDate", "Date must be earlier than now");
                }
                if (ModelState.IsValid)
                {
                    await _db.Components.AddAsync(component);
                    await _db.SaveChangesAsync();
                    _cachingService.Clean();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("Model state is not valid. Redirect back");
                }
            }
            catch
            {
                ViewBag.ComponentTypes = new SelectList(await _db.ComponentTypes.ToListAsync(), "Id", "Name");
                ViewBag.Countries = new SelectList(await _db.Countries.ToListAsync(), "Id", "Name");
                ViewBag.Manufacturers = new SelectList(await _db.Manufacturers.ToListAsync(), "Id", "Name");
                return View();
            }
        }

        // GET: ComponentsController/Details/5
        public async Task<ActionResult> Details(int componentId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.User))
            {
                return Redirect("~/Identity/Account/Login");
            }
            return View(await _db.Components
                .Include(c => c.Manufacturer)
                .Include(c => c.ComponentType)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == componentId));
        }

        // GET: ComponentsController/Edit/5
        public async Task<ActionResult> Edit(int componentId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Components");
            }
            ViewBag.ComponentTypes = new SelectList(await _db.ComponentTypes.ToListAsync(), "Id", "Name");
            ViewBag.Countries = new SelectList(await _db.Countries.ToListAsync(), "Id", "Name");
            ViewBag.Manufacturers = new SelectList(await _db.Manufacturers.ToListAsync(), "Id", "Name");
            return View(await _db.Components
                .Include(c => c.ComponentType)
                .Include(c => c.Manufacturer)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == componentId));
        }

        // POST: ComponentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Component component)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Components");
            }
            try
            {
                if (component.ReleaseDate < new DateTime(1980, 1, 1))
                {
                    ModelState.AddModelError("ReleaseDate", "Date must be later than 01.01.1980");
                }
                else if (component.ReleaseDate > DateTime.Now)
                {
                    ModelState.AddModelError("ReleaseDate", "Date must be earlier than now");
                }
                if (ModelState.IsValid)
                {
                    _db.Components.Update(component);
                    await _db.SaveChangesAsync();
                    _cachingService.Clean();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("Model state is not valid. Redirect back");
                }
            }
            catch
            {
                ViewBag.ComponentTypes = new SelectList(await _db.ComponentTypes.ToListAsync(), "Id", "Name");
                ViewBag.Countries = new SelectList(await _db.Countries.ToListAsync(), "Id", "Name");
                ViewBag.Manufacturers = new SelectList(await _db.Manufacturers.ToListAsync(), "Id", "Name");
                return View(await _db.Components
                    .Include(c => c.ComponentType)
                    .Include(c => c.Manufacturer)
                    .Include(c => c.Country)
                    .FirstOrDefaultAsync(c => c.Id == component.Id));
            }
        }

        // GET: ComponentsController/Delete/5
        public async Task<ActionResult> Delete(int componentId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Components");
            }
            return View(await _db.Components
                .Include(c => c.Manufacturer)
                .Include(c => c.ComponentType)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == componentId));
        }

        // POST: ComponentsController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> PostDelete(int componentId)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Components");
            }
            try
            {
                var component = await _db.Components.FirstOrDefaultAsync(c => c.Id == componentId);
                _db.Components.Remove(component);
                await _db.SaveChangesAsync();
                _cachingService.Clean();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _db.Components
                    .Include(c => c.Manufacturer)
                    .Include(c => c.ComponentType)
                    .Include(c => c.Country)
                    .FirstOrDefaultAsync(c => c.Id == componentId));
            }
        }
    }
}
