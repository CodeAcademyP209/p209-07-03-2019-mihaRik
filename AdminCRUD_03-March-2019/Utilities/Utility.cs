using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AdminCRUD_03_March_2019.Utilities
{
    public static class Utility
    {
        public static void Remove(string image)
        {
            var fileFullPath = HttpContext.Current.Server.MapPath("~/Public/images/") + image;

            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }
        }
    }
}