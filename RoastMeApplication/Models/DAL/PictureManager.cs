using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.DAL
{
    public class PictureManager
    {
        public static List<Picture> GetAll()
        {
            List<Picture> allPics = null;

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                allPics = ctx.Pictures.ToList();
            }

            return allPics;
        }

        public static List<Picture> GetAllByParticipantId(int participantId)
        {
            Participant part = null;

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                part = ctx.Participants.Include("Pictures").Where(p => p.Id == participantId).FirstOrDefault();
            }

            return part.Pictures.ToList();
        }
    }
}