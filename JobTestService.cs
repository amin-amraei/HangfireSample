using System.Runtime.CompilerServices;

namespace HangfireSample
{
    public class JobTestService : IJobTestService
    {
        public async Task RunFireandForgetA()
        {
            await Task.Delay(10000);

            Console.WriteLine("Fire-and-forgetA!");
        }

        public async Task RunFireandForgetB()
        {
            await Task.Delay(20000);
            Console.WriteLine("Fire-and-forgetB!");
        }

        public async Task RunFireandForgetC()
        {
            await Task.Delay(30000);
            Console.WriteLine("Fire-and-forgetC!");
        }
        public void RunSchedule() => Console.WriteLine("Delayed!");
        public async Task RunRecurringJobA()
        {
            await Task.Delay(10000);
            Console.WriteLine("RecurringA!");
        }
        public async Task RunRecurringJobB()
        {
            await Task.Delay(20000);
            Console.WriteLine("RecurringB!");
        }
        public async Task RunRecurringJobC()
        {
            await Task.Delay(30000);
            Console.WriteLine("RecurringC!");
        }

    }
}
