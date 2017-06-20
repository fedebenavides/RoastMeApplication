﻿using RoastMeApplication.Models.Entities;
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

        public static void AddPicture(Picture picture)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Pictures.Add(picture);
                ctx.SaveChanges();
            }
        }

        public static void EditPictureFlagged(Picture new_picture)
        {
            Picture picture = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                picture = ctx.Pictures.Where(p => p.Id == new_picture.Id).FirstOrDefault();
                if (picture != null)
                {
                    picture.IsFlagged = new_picture.IsFlagged;
                }
                ctx.SaveChanges();
            }
        }

        public static List<Picture> GetPictureByCaption(String searchInfo)
        {
            List<Picture> Pics = null;

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Pics = ctx.Pictures.Where(p=>p.Caption== searchInfo).ToList();
            }

            return Pics;
        }

        public static List<Picture> GetPictureByParticipantName(String searchInfo)
        {
            List<Picture> Pics = null;

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Pics = ctx.Pictures.Include("Participant").Where(p=>p.Participant.Username.Contains(searchInfo)).ToList();
            }

            return Pics;
        }
    }
}