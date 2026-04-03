using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class Driver
    {
        public async Task FixPoles(Trolleybus t)
        {
            await Task.Delay(3000);
            t.Fix();
        }
    }
}