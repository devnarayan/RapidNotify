using System;

namespace RapidNotify.Models
{
    public class Item : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
        DateTime notifyDate = new DateTime();
        public DateTime NotifycationDate
        {
            get { return notifyDate; }
            set { SetProperty(ref notifyDate, value); }
        }
    }
}
