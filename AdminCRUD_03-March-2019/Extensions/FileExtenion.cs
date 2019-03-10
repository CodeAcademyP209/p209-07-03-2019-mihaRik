using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace AdminCRUD_03_March_2019.Extensions
{
    public static class FileExtenion
    {
        public static bool IsImage(this HttpPostedFileBase file)
        {
            return file.ContentType == "image/jpg" ||
                   file.ContentType == "image/jpeg" ||
                   file.ContentType == "image/png" ||
                   file.ContentType == "image/gif";
        }

        public static string Save(this HttpPostedFileBase image, string path)
        {
            var fileName = Path.Combine(path, Guid.NewGuid() + Path.GetFileName(image.FileName));

            var fileFullPath = HttpContext.Current.Server.MapPath("~/Public/images/") + fileName;

            WebImage photo = new WebImage(image.InputStream);

            photo.Resize(800, 500, true);

            photo.Save(fileFullPath);

            return fileName;
        }
    }
}