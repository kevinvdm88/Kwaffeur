using Kwaffeur.Application.Common.Interfaces;
using Kwaffeur.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Kwaffeur.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
