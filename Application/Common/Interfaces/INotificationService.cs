using Kwaffeur.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Kwaffeur.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
