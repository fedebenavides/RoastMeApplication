using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.Entities
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
        public int ParticipantId { get; set; }
        public int PictureId { get; set; }

        /*
         * *navigation props
         * */
        public Participant Participant { get; set; }
        public Picture Picture { get; set; }

        public ICollection<Vote> Votes { get; set; }
        public ICollection<Comment> Replies { get; set; } // if it has replies

        /*
         * *methods
         * */
        ////METHODS WILL GO IN MANAGERS
        //public void DeleteComment(int commentId)
        //{
        //    //only admin can do this
        //}

        //public void SortComments(int option)
        //{
        //    //define switch-case
        //}

        //public void FlagComment(int pictureId)
        //{

        //}
    }
}