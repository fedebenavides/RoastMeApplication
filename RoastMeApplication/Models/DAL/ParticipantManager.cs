using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.DAL
{
    public class ParticipantManager
    {
        /*
         * *methods for Participant
         * */
        public static void Add(Participant participant)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Participants.Add(participant);
                ctx.SaveChanges();
            }
        }

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
        //}

    }
}