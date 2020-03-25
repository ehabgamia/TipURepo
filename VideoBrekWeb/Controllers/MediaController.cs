using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoBrek.Core.Domain.Media;
using VideoBrek.Services.Media;
using VideoBrekWeb.Models;
using VideoBrekWeb.ViewModel;

namespace VideoBrekWeb.Controllers
{
    public class MediaController : Controller
    {
        private readonly IMediaServices _mediaServices;

        public MediaController(IMediaServices mediaServices)
        {
            this._mediaServices = mediaServices;
        }
        // GET: Media
        
        public ActionResult Index()
        {
            ViewBag.FormName = "Index";
            var mediaListViewModel = new MediaListViewModel();
            var mediaListData = _mediaServices.GetAllMedia();
            var _mediaCategoryList = mediaListData.Select(a =>
            new MediaModel
            {
                CreateDtTm = a.CreateDtTm,
                IsActive = a.IsActive,
                Title = a.Title,
                Thumbnail = a.Thumbnail,
                CloudMediaUrl = a.CloudMediaUrl,


            }).ToList();
            mediaListViewModel.mediaList = _mediaCategoryList;
            return View(mediaListViewModel);
        }

        // GET: Media/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        [HttpPost]
        public ActionResult Create(MediaListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _media = new Media();
                    _media.Title = model.mediaModel.Title;
                    _media.CloudMediaUrl = model.mediaModel.CloudMediaUrl;
                    _media.Thumbnail = model.mediaModel.Thumbnail;
                    _media.CreateDtTm = DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt");
                    _media.FileSizeMb = model.mediaModel.FileSizeMb;
                    _media.Duration = model.mediaModel.Duration;
                    _media.SearchTags = model.mediaModel.SearchTags;
                    _media.MediaTypeId = 1;
                    _media.IsActive = true;
                    _media.CreatedBy = 0;
                    _mediaServices.InsertMedia(_media);
                  

                    return RedirectToAction("Index");
                }

                return View(model);

            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Media/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Media/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
