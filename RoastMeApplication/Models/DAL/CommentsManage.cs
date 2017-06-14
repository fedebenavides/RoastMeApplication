using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.DAL
{
    public class CommentsManage
    {
        public static List<Comment> GetCommentByPictureId(int picture_id)
        {
            List<Comment> comment = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                comment = db.Comments.Where(c=>c.PictureId == picture_id).OrderBy( c =>c.time).ToList();
                
            }
            return comment;
        }

        public static void AddComment(Comment comment)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Comments.Add(comment);
                db.SaveChanges();

            }
        }

        public static List<Comment> EditCommentInfo(Comment comment)
        {
            List<Comment> comments = null;
   
            return comments;
        }
    }
}