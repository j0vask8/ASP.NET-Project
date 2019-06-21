using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IGetCategoriesCommand _getCommand;
        private readonly IGetCategoryCommand _getOneCommand;
        private readonly IAddCategoryCommand _addCommand;
        private readonly IUpdateCategoryCommand _editCommand;
        private readonly IDeleteCategoryCommand _deleteCommand;

        public CategoriesController(IGetCategoriesCommand getCommand, IGetCategoryCommand getOneCommand, IAddCategoryCommand addCommand, IUpdateCategoryCommand editCommand, IDeleteCategoryCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }

        // GET: Categories
        public ActionResult Index(CategorySearch search)
        {
            var result = _getCommand.Execute(search);
            return View(result);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getOneCommand.Execute(id);
                return View(dto);
            }
            catch(EntityNotFoundException) {
                TempData["error"] = "This category doesnt exist";
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _addCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(EntityAlreadyExistsException) {
                TempData["error"] = "Category with the same name already exists"; 
            }
            catch(Exception)
            {
                TempData["error"] = "An error occured";
            }
            return View();
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var category = _getOneCommand.Execute(id);
                return View(category);
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "This category doesnt exist";
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _editCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "This category doesnt exist";
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Category already exists";
                return View(dto);
            }
        }

        // GET: test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoryDto dto)
        {
            try
            {
                _deleteCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityDeleted) {
                TempData["error"] = "This category is already deleted";
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}