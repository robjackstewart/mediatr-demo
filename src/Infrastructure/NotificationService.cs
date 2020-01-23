using System;
using System.Threading.Tasks;
using Application.Common.Interfaces;

namespace Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(string message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}
