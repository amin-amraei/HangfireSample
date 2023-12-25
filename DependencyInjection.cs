using Hangfire;
using Hangfire.SqlServer;

namespace HangfireSample
{
    public static class DependencyInjection
    {
        public static void AddHangFirSamaple(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(conf =>
            {
                conf
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()                
                .UseSqlServerStorage(configuration.GetConnectionString("DBConnection"),
                new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true,

                });
            });
            
            services.AddHangfireServer();

            services.AddTransient<IJobTestService, JobTestService>();
            services.AddTransient<IHangFireTest, HangFireTest>();

            var sp = services.BuildServiceProvider();
            var hangFireTest = sp.GetRequiredService<IHangFireTest>();
            //hangFireTest.FireandForgetA();
            //hangFireTest.FireandForgetB();
            //hangFireTest.FireandForgetC();
            //hangFireTest.Schedule();
            //hangFireTest.RecurringJob();
            //hangFireTest.RecurringJobTrigger();
            //hangFireTest.BatchJobMethod();

            var t1 = Task.Run(() => hangFireTest.RecurringJobA());
            var t2 = Task.Run(() => hangFireTest.RecurringJobB());
            var t3 = Task.Run(() => hangFireTest.RecurringJobC());

            Task.WhenAll(t1,t2,t3);


        }
    }
}