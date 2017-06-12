using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models
{
    public class Comment
    {
        /*
         * *Atributes
         * */
        public int id { get; set; }
        public string message { get; set; }
        public int voteScore { get; set; }
        public bool isFlagged { get; set; }

        /*
         * *foreign keys
         * */
        public int UserId { get; set; }
        public int PictureId { get; set; }
        public int CommentId { get; set; } //if comment is a reply of another comment

        /*
         * *navigation props
         * */
        public User User { get; set; }
        public Picture Picture { get; set; }
        public Comment CommentReplied { get; set; } //if comment is a reply of another comment

        public ICollection<Vote> Votes { get; set; }
        public ICollection<Vote> Comments { get; set; } //if comment has replies

        /*
         * *methods
         * */

        public void DeleteComment(int commentId)
        {
            //only admin can do this
        }

        public void SortComments(int option)
        {
            //define switch-case
        }

        public void FlagComment(int pictureId)
        {

        }
    }
}