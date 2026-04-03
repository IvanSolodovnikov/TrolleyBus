using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class RepairService : IRepairService
    {
        public async Task Repair(Trolleybus t)
        {
            await Task.Delay(5000);
            t.Fix();
        }
    }
}