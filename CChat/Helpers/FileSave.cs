using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace CChat.Helpers
{
    public static class FileSave
    {
        public static string SaveFile(out string fileName, IFormFile file, string localPath)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" , ".pdf"};
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine(localPath, DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveEmpAttachment(out string fileName, IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine("EmpAttachment", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveImage(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine("EmpImages", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }
    }
}
