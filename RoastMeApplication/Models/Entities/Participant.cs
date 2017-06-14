using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.Entities
{
    public class Participant
    {
        /*
         * *Atributes
         * */
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        /*
         * *foreign keys
         * */
        public string ApplicationUserId { get; set; }

        /*
         * *navigation props
         * */
        public ApplicationUser ApplicationUser;

        public ICollection<Vote> Votes { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Comment> Comments { get; set; }

        /*
         * *methods
         * */
        //METHODS WILL GO IN MANAGERS
        //public Participant(string username, string password, string email)
        //{
        //    this.username = username;
        //    this.password = password;
        //    this.email = email;
        //}

        //public bool Login(string username, string pwd)
        //{
        //    //if login successful, return true
        //    return true;
        //}

        //public void Manage()
        //{
        //    //to be further defined
        //}

        //public bool DeleteAccount(int participantId)
        //{
        //    //if delete successful, return true
        //    return true;
        }
      
    }
}