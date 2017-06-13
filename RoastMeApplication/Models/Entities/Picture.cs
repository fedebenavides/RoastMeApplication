using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.Entities
{
    public class Picture
    {
        /*
         * *Atributes
         * */
        public int id { get; set; }
        public string caption { get; set; }
        public string imagePath { get; set; }
        public DateTime time { get; set; }
        public bool isFlagged { get; set; }

        /*
         * *foreign keys
         * */
        public int ParticipantId { get; set; }

        /*
         * *navigation props
         * */
        public Participant Participant { get; set; }

        public ICollection<Vote> Votes { get; set; }
        public ICollection<Comment> Comments { get; set; }

        /*
         * *methods
         * */

        public void ManagePicture(int pictureId)
        {
            //to be further defined
        }

        public void SortPictures(int option)
        {
            //define switch-case
        }

        public void FlagPicture(int pictureId)
        {
            
        }

        public void SearchPicture(params string[] keywords)
        {

        }
    }
}