using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace UtilizationTrackerApp.Utility
{
    public class Global_Component
    {

        public static List<SelectListItem> FillDropdownList(List<SelectListItem> MyList, string FirstValue)
        {

            MyList = MyList.OrderBy(var => var.Value).OrderBy(var => var.Text).ToList();

            SelectListItem MyFirstItem = new SelectListItem { Value = "", Text = FirstValue };
            MyList.Insert(0, MyFirstItem);
            return MyList;
        }
        public static List<SelectListItem> FillDropdownList_Default(List<SelectListItem> MyList, string FirstValue)
        {

            MyList = MyList.OrderBy(var => var.Value).OrderBy(var => var.Text).ToList();

            SelectListItem MyFirstItem = new SelectListItem { Value = "0", Text = FirstValue };
            MyList.Insert(0, MyFirstItem);
            return MyList;
        }
        public static string GenerateFileName(string filename)
        {

            string sFile = "~/Blob_Storage/User_Images/" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 18) + filename;

            return sFile;
        }


        public static string SendMail(EmailModel model)
        {
            string Result = "";
            model.To = "DeepakRanaInbox@outlook.com";
            model.Subject = "Test Mail";
            model.Body = "This is Testing";

            model.Email = ConfigurationManager.AppSettings["SenderEmail"].ToString();
            model.Password = ConfigurationManager.AppSettings["Password"].ToString();

            try
            {
                using (MailMessage mm = new MailMessage(model.Email, model.To))
                {
                    mm.Subject = model.Subject;
                    mm.Body = model.Body;
                    if (model.Attachment != null && model.Attachment.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(model.Attachment.FileName);
                        mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
                    }
                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
                        smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                        NetworkCredential NetworkCred = new NetworkCredential(model.Email, model.Password);
                        smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
                        smtp.Credentials = NetworkCred;
                        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                        smtp.Send(mm);
                        Result = "Email sent successfully!";
                    }
                }
            }
            catch(Exception EXC)
            {
                Result = "Email not sent! , "+ EXC.Message;
            }

            return Result;
        }

        public static List<SelectListItem> FillDropdownList_Default_WOO(List<SelectListItem> MyList, string FirstValue)
        {

            //MyList = .OrderBy(var => var.Value).OrderBy(var => var.Text).ToList();

            SelectListItem MyFirstItem = new SelectListItem { Value = "0", Text = FirstValue };
            MyList.Insert(0, MyFirstItem);
            return MyList;
        }
    }

   
}