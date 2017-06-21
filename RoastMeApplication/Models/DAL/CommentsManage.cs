using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.DAL
{
    public class CommentsManage
    {
        //Get Comment By Picture Id
        public static List<Comment> GetCommentByPictureId(int picture_id)
        {
            List<Comment> comment = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                comment = ctx.Comments.Include("Participant").Where(c=>c.PictureId == picture_id).OrderBy( c =>c.Time).ToList();
                
            }
            return comment;
        }

        //Add Comment
        public static void AddComment(Comment comment)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(comment);
                ctx.SaveChanges();

            }
        }

        //Edit Flagged
        public static void EditCommentFlagged(Comment new_comment)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Comment comment = ctx.Comments.Where(c => c.Id == new_comment.Id).FirstOrDefault();

                if (comment != null)
                {
                    comment.IsFlagged = new_comment.IsFlagged;
                    
                }
                ctx.SaveChanges();
            }


        }

        public static List<Comment> GetCommentByFlagged(int picture_id)
        {
            List<Comment> comment = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                comment = ctx.Comments.Where(c => c.PictureId == picture_id).OrderBy(c => c.Time).ToList();

            }
            return comment;
        }

        //Edit VotedScore
        public static void EditCommentVotedScore(int comment_id,int score)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Comment comment = ctx.Comments.Where(c => c.Id == comment_id).FirstOrDefault();

                if (comment != null)
                {
                    comment.VoteScore = score;
                }
                ctx.SaveChanges();
            }

        }

        //Delete Comment
        public static void DeleteComment(Comment new_comment)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Comment comment = ctx.Comments.Where(c => c.Id == new_comment.Id).FirstOrDefault();

                if (comment != null)
                {
                    //delete
                    ctx.Comments.Remove(comment);
                }
                //save changes
                ctx.SaveChanges();
            }

        }
    }
}