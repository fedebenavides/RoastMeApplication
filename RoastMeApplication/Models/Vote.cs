using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models
{
    public class Vote
    {
        /*
         * *Atributes
         * */
        public int id { get; set; }
        public bool isLike { get; set; }

        /*
         * *foreign keys
         * */
        public int UserId { get; set; }
        public int CommentId { get; set; }

        /*
         * *navigation props
         * */
        public User User { get; set; }
        public Comment Comment { get; set; }

        /*
         * *methods
         * */
        public void ChangeVote(bool isLike)
        {

        }

    }
}