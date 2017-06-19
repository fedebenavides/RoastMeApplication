using RoastMeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoastMeApplication.Models.DAL
{
    public class PictureManagerz
    {
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

        public static bool CheckImgByPath(string path)
        {
            Picture img = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                img = ctx.Pictures.Where(c => c.ImagePath == path).FirstOrDefault();
            }
            if (img == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}