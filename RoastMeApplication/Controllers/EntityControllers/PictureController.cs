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
        public ActionResult PictureDetail(int id)
        {
            ViewBag.picture = PictureManager.GetPictureById(id);
            if (Session["participantID"] != null)
            {
                ViewBag.Participant = ParticipantManager.GetById(Convert.ToInt32(Session["participantID"]));
            }
            return View();
        }
        [HttpPost]
        public ActionResult SubmitComment(String message, String pic_id,String par_id)
        {
            Comment comment = new Comment();
            comment.Message = message;
            comment.IsFlagged = false;
            comment.PictureId = Convert.ToInt32(pic_id);
            comment.Time = DateTime.Now;
            comment.VoteScore = 0;
            comment.ParticipantId = Convert.ToInt32(par_id);
            CommentsManage.AddComment(comment);

            return RedirectToAction("PictureDetail", Convert.ToInt32(pic_id));
        }

        public ActionResult SubmitPicture()
        {
            if (Session["participantID"] != null) {
                ViewBag.ParticipantID = Session["participantID"];
            }
                       
            return View();
        }
        
        [HttpPost]
        public ActionResult SubmitPicture(Picture img, HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (!(file.FileName.Contains("jpg") || file.FileName.Contains("png") || file.FileName.Contains("gif") || file.FileName.Contains("jpeg")))
                {
                    ModelState.AddModelError("Path", "Our image just use jpg,png,gif and jpeg");
                    TempData["error"] = "Our image just use jpg,png,gif and jpeg";
                }
            }
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                   
                   file.SaveAs(Server.MapPath("~/Content/Images/" + file.FileName));

                   img.ImagePath = file.FileName;
                   img.Time = DateTime.Now;
                   img.ParticipantId = img.ParticipantId;
                   img.IsFlagged = false;       
                   img.Caption = img.Caption;
                   PictureManager.AddPicture(img);
                }
                //img is true
                return Content("Success");
            }else
            {
                // If img is error 
                return Content("Error");
            }
            
        }
    }
}