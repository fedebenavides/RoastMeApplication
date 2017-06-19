using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.Entities
{
    public class Picture
    {
        /*
         * *Atributes
         * */
        public int Id { get; set; }
        public string Caption { get; set; }
        public string ImagePath { get; set; }
        public DateTime Time { get; set; }
        public bool IsFlagged { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

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
         //METHODS WILL GO IN MANAGERS
        //public void ManagePicture(int pictureId)
        //{
        //    //to be further defined
        //}

        //public void SortPictures(int option)
        //{
        //    //define switch-case
        //}

        //public void FlagPicture(int pictureId)
        //{
            
        //}

        //public void SearchPicture(params string[] keywords)
        //{

        //}
    }
}