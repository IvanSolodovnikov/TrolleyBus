using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public interface IRepairService
    {
        Task Repair(Trolleybus t);
    }
}