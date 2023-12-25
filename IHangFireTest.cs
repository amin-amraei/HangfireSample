namespace HangfireSample
{
    public interface IHangFireTest
    {
        void FireandForgetA();
        void FireandForgetB();
        void FireandForgetC();
        void Schedule();
        void RecurringJobA();
        void RecurringJobB();
        void RecurringJobC();
        void RecurringJobTrigger();
        void BatchJobMethod();
    }
}
