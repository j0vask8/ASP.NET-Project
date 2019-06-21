using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TopicsController : Controller
    {
        private readonly IGetTopicsCommand _getCommand;
        private readonly IGetTopicCommand _getOneCommand;
        private readonly IAddTopicCommand _addCommand;
        private readonly IUpdateTopicCommand _editCommand;
        private readonly IDeleteTopicCommand _deleteCommand;

        public TopicsController(IGetTopicsCommand getCommand, IGetTopicCommand getOneCommand, IAddTopicCommand addCommand, IUpdateTopicCommand editCommand, IDeleteTopicCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }

        // GET: Topics
        public ActionResult Index(TopicSearch search)
        {
            var result = _getCommand.Execute(search);
            return View(result);
        }

        // GET: Topics/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getOneCommand.Execute(id);
                return View(dto);
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "This Topic doesnt exist";
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Topics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTopicDto dto)
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
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "with the same name already exists";
            }
            catch (Exception)
            {
                TempData["error"] = "An error occured";
            }
            return View();
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var category = _getOneCommand.Execute(id);
                return View(category);
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "This Topic doesnt exist";
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
        }

        // POST: Topics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TopicDto dto)
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
                TempData["error"] = "This Topic doesnt exist";
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Topic already exists";
                return View(dto);
            }
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topics/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TopicDto dto)
        {
            try
            {
                _deleteCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityDeleted)
            {
                TempData["error"] = "This Topic is already deleted";
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}