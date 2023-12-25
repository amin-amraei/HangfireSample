namespace HangfireSample
{
    public interface IJobTestService
    {
        Task RunFireandForgetA();
        Task RunFireandForgetB();
        Task RunFireandForgetC();
        void RunSchedule();
        Task RunRecurringJobA();
        Task RunRecurringJobB();
        Task RunRecurringJobC();
    }
}
