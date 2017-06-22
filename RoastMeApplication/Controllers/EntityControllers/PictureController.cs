using Newtonsoft.Json.Linq;
using RoastMeApplication.Models.DAL;
using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoastMeApplication.Controllers.EntityControllers
{
    [Authorize]
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
        [HttpGet]
        public JsonResult LikeVote(string JsonResult)
        {
            string result = JsonResult;
            Vote vote = null;
            JObject jobj = JObject.Parse(JsonResult);
            vote = VoteManager.getVotedByComment_idAndParticipantId(Convert.ToInt32(jobj["CommentId"]), Convert.ToInt32(jobj["ParticipantId"]));
            if (vote == null)
            {
                vote.CommentId = Convert.ToInt32(jobj["CommentId"]);
                vote.ParticipantId = Convert.ToInt32(jobj["ParticipantId"]);
                int ck = Convert.ToInt32(jobj["isLike"]);
                vote.IsLike = null;
                if (ck == -1)
                {
                    vote.IsLike = null;
                }
                else if (ck == 0)
                {
                    vote.IsLike = false;
                }
                else if (ck == 1)
                {
                    vote.IsLike = true;
                }
                VoteManager.AddVoted(vote);
                VoteManager.SumVotedScore(Convert.ToInt32(jobj["CommentId"]));
            }else
            {
                int ck = Convert.ToInt32(jobj["isLike"]);
                vote.IsLike = null;
                if (ck ==-1)
                {
                    vote.IsLike = null;
                }
                else if(ck == 0)
                {
                    vote.IsLike = false;
                }
                else if(ck == 1)
                {
                    vote.IsLike = true;
                }
                VoteManager.EditVotedIslike(vote);
                VoteManager.SumVotedScore(Convert.ToInt32(jobj["CommentId"]));
            }
            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubmitComment(Comment comment)
        {
            comment.IsFlagged = false;
            DateTime t = DateTime.Now;
            comment.IsFlagged = false;
            comment.Time = t;
            comment.VoteScore = 0;
            CommentsManage.AddComment(comment);
            //comment = CommentsManage.GetCommentByDateTime(t);
            //comment = CommentsManage.GetCommentById(comment.Id);

            //Vote vote = new Vote();
            //vote.CommentId = comment.Id;
            //vote.ParticipantId = comment.;
            //vote.IsLike = null;
            //VoteManager.AddVoted(vote);

            return RedirectToAction("PictureDetail", new { id = comment.PictureId });
        }


        public ActionResult SubmitPicture()
        {
            if (Session["participantID"] != null)
            {
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
            }
            else
            {
                // If img is error 
                return Content("Error");
            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageFlags()
        {
            ViewBag.FlaggedPics = PictureManager.GetFlagged();
            ViewBag.FlaggedComments = CommentsManage.GetFlagged();
            return View();
        }
    }
}