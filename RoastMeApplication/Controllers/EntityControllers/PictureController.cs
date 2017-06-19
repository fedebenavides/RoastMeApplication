using RoastMeApplication.Models.DAL;
using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public ActionResult SubmitPicture(Picture img, HttpPostedFileBase file)
        {
            if (!(file.FileName.Contains("jpg") || file.FileName.Contains("png") || file.FileName.Contains("gif") || file.FileName.Contains("jpeg")))
            {
                ModelState.AddModelError("Path", "Our image just use jpg,png,gif and jpeg");
                TempData["error"] = "Our image just use jpg,png,gif and jpeg";
            }

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (PictureManager.CheckImgByPath(file.FileName))
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Content/ProfilePicture/")//This is your img path.
                                                              + file.FileName);

                        img.ImagePath = file.FileName;
                        img.Time = DateTime.Now;
                        img.ParticipantId = 11;
                        img.IsFlagged = false;
                        img.Caption = "";
                        PictureManager.AddPicture(img);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}