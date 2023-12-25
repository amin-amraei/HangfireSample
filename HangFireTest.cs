using Hangfire;

namespace HangfireSample
{
    public class HangFireTest : IHangFireTest
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;           
        private readonly IJobTestService _jobTestService;
        public HangFireTest(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IJobTestService jobTestService)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _jobTestService = jobTestService;

        }

        public void FireandForgetA()
        {
            var jobId = _backgroundJobClient.Enqueue(() => _jobTestService.RunFireandForgetA());            
        }

        public void FireandForgetB()
        {
            var jobId = _backgroundJobClient.Enqueue(() => _jobTestService.RunFireandForgetB());
            
        }

        public void FireandForgetC()
        {
            var jobId = _backgroundJobClient.Enqueue(() => _jobTestService.RunFireandForgetC());
            
        }

        public void Schedule()
        {
            var jobId = BackgroundJob.Schedule(() => _jobTestService.RunSchedule(), TimeSpan.FromMinutes(1));
        }        

        public void RecurringJobA()
        {
            _recurringJobManager.AddOrUpdate("myrecurringjobA", () => _jobTestService.RunRecurringJobA(), "*/1 * * * *");
        }

        public void RecurringJobB()
        {
            _recurringJobManager.AddOrUpdate("myrecurringjobB", () => _jobTestService.RunRecurringJobB(), "*/1 * * * *");
        }

        public void RecurringJobC()
        {
            _recurringJobManager.AddOrUpdate("myrecurringjobC", () => _jobTestService.RunRecurringJobC(), "*/1 * * * *");
        }

        public void RecurringJobTrigger()
        {
            var parentJobId = _backgroundJobClient.Enqueue(() => _jobTestService.RunFireandForgetA());            
            _recurringJobManager.Trigger(parentJobId);
        }

        public void BatchJobMethod()
        {
            var batchId = BatchJob.StartNew(x =>
            {
                x.Enqueue(() => Console.WriteLine("Job 1"));
                x.Enqueue(() => Console.WriteLine("Job 2"));
            });
        }
    }
}
