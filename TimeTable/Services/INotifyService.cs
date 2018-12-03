using System.Threading.Tasks;

namespace TrainTimeTable.Services
{
    public interface INotifyService
    {
       Task SendNotificationAsync(string message);
    }
}
