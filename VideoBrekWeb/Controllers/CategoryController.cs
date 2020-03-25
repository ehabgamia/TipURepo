using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoBrek.Core.Domain.Category;
using VideoBrek.Data;
using VideoBrekWeb.Models;
using VideoBrekWeb.Services.Category;
using VideoBrekWeb.ViewModel;

namespace VideoBrekWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
           this. _categoryServices = categoryServices;
        }

        // GET: Category
        public ActionResult Index()
        {
            ViewBag.FormName = "Index";
            var mediaCategoryListViewModel = new MediaCategoryListViewModel();
            var mediaCategoryListData = _categoryServices.GetAllCategory();
            var _mediaCategoryList = mediaCategoryListData.Select(a =>
            new MediaCategoryModel
            {
                CreateDtTm = a.CreateDtTm,
                IsActive = a.IsActive,
                CategoryName = a.CategoryName,
                CategoryCode = a.CategoryCode,
             
            }).ToList();
            mediaCategoryListViewModel.mediaCategoryModelList = _mediaCategoryList;
            return View(mediaCategoryListViewModel);

        }

        // GET: Category/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MediaCategory mediaCategoryModel = db.MediaCategory.Find(id);
        //    if (mediaCategoryModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mediaCategoryModel);
        //}

        // GET: Category/Create
        public ActionResult Create()
        {
            var _mediaCategoryListModel = new MediaCategoryListViewModel();
            return View(_mediaCategoryListModel);
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(MediaCategoryListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var _mediaCategoryModel = new MediaCategory();
                _mediaCategoryModel.CategoryName = model.mediaCategoryModel.CategoryName;
                _mediaCategoryModel.CategoryCode = model.mediaCategoryModel.CategoryCode;
                _mediaCategoryModel.CreateDtTm = DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt");
                _categoryServices.InsertCategory(_mediaCategoryModel);
               
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Category/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MediaCategory mediaCategoryListModel = db.MediaCategory.Find(id);
        //    if (mediaCategoryListModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mediaCategoryListModel);
        //}

        //// POST: Category/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id")] MediaCategory mediaCategoryModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(mediaCategoryModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(mediaCategoryModel);
        //}

        //// GET: Category/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MediaCategory mediaCategoryModel = db.MediaCategory.Find(id);
        //    if (mediaCategoryModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mediaCategoryModel);
        //}

        //// POST: Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MediaCategory mediaCategoryListModel = db.MediaCategory.Find(id);
        //    db.MediaCategory.Remove(mediaCategoryListModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

     
    }
}