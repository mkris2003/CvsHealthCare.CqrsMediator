using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CvsHealthCare.CqrsMediator.Application.Interfaces;
using CvsHealthCare.CqrsMediator.Application.Notifications.Models;
using MediatR;

namespace CvsHealthCare.CqrsMediator.Application.Employees.Commands.CreateEmployee
{
   public class EmployeeCreated : INotification
    {
        public int EmpNo { get; set; }

        public class EmployeeCreatedHandler : INotificationHandler<EmployeeCreated>
        {
            private readonly INotificationService _notification;

            public EmployeeCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(EmployeeCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
