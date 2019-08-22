using System;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Notifications.Models;

namespace CvsHealthCare.CqrsMediator.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
