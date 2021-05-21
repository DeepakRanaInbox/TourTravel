using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilizationTrackerApp.Utility
{
    public class GenericModel
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public string Paraent { get; set; }
        public string Value { get; set; }
        public string selectedValue { get; set; }
        public string PrimeryPlantID { get; set; }
        public int ID { get; set; }
    }

    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}