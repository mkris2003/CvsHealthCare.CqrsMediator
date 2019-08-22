using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using CvsHealthCare.CqrsMediator.Application.Notifications.Models;

namespace CvsHealthCare.CqrsMediator.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
