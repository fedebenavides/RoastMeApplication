using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public static List<Participant> GetAll()
        {
            List<Participant> allParts = null;

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                allParts = ctx.Participants.ToList();
            }

            return allParts;
        }

        public static Participant GetById(int id)
        {
            Participant part = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                //eager loading of the navigation property Program
                part = ctx.Participants.Where(s => s.Id == id).FirstOrDefault();

            }

            return part;
        }

        //public void Manage()
        //{
        //    //to be further defined
        //}


        //(Roles = "Admin")
        public static void Delete(int participantId)
        {
            //using (ApplicationDbContext ctx = new ApplicationDbContext())
            //{
            //    ctx.Participants.Add(participant);
            //    ctx.SaveChanges();
            //}
        }

    }
}