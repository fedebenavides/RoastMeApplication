using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoastMeApplication.Controllers.EntityControllers
{
    public class PictureController : Controller
    {
        // GET: Picture
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add() {
            return PartialView("SubmitRoastPartial");
        }

        [HttpPost]
        public ActionResult New(Picture pictureModel)
        {

            string fileName = Path.GetFileNameWithoutExtension(pictureModel.ImageFile.FileName);
            string extension = Path.GetExtension(pictureModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            pictureModel.ImagePath = "~/Image/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            pictureModel.ImageFile.SaveAs(fileName);           

            return Content("Image Uploaded");
        }

        public ActionResult Cancel() {
            return RedirectToAction("Index");
        }

    }
}