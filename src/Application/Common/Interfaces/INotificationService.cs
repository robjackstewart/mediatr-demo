using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(string message);
    }
}
