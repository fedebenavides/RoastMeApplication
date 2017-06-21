using RoastMeApplication.Models.DAL;
using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoastMeApplication.Controllers
{
    public class CommentController : Controller
    {

        // GET: Comment
        public ActionResult Index()
        {
            if (Session["participantID"] != null)
            {
                ViewBag.ParticipantID = Session["participantID"];
            }
            return View();
        }

        public ActionResult SubmitComment()
        {
            if (Session["participantID"] != null)
            {
                ViewBag.ParticipantID = Session["participantID"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult SubmitComment(String message, String pic_id)
        {
            Comment comment = new Comment();
            comment.Message = message;
            comment.IsFlagged = false;
            comment.PictureId = Convert.ToInt32(pic_id);
            comment.Time = DateTime.Now;
            comment.VoteScore = 0;
            comment.ParticipantId = 1;
            CommentsManage.AddComment(comment);
            
            return RedirectToAction("Index");
        }
    }
}