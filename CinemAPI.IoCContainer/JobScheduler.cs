using CinemAPI.Data.Implementation;
using Quartz;
using Quartz.Impl;
using System;

namespace CinemAPI.IoCContainer
{
    public class JobScheduler
    {
        public async void Start()

        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder
                .Create<ReservationRepository>()
                .Build();

            ITrigger trigger = TriggerBuilder.Create()

                .WithIdentity("ReservationRepository")

                .WithCronSchedule("0 0/1 * 1/1 * ? *")

                .StartAt(DateTime.UtcNow)

                .WithPriority(1)

                .Build();

            await scheduler.ScheduleJob(job, trigger);

        }
    }
}
