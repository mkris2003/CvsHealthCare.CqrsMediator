﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CvsHealthCare.CqrsMediator.Application.Notifications.Models
{
    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
