using Sdl.Desktop.IntegrationApi.Jobs;
using System;

namespace Sdl.PackagesOperations.Sample
{
    /// <summary>
    /// 
    /// </summary>
    public class SampleJob : IExternalJobWithProgress
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobData"></param>
        public SampleJob()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public object JobData { get; set; }

        public string JobName { get; set; }

        public event EventHandler<JobProgressArgs> ProgressReported;

        public void JobCanceled(object sender, EventArgs e)
        {
            JobData = "Job was canceled";
        }

        public void Execute()
        {
            ProgressReported?.Invoke(this, new JobProgressArgs()
            {
                PercentComplete = 0,
                StatusMessage = "Sample Job Started for package at location: " + JobData
            });
            System.Threading.Thread.Sleep(1000);
            ProgressReported?.Invoke(this, new JobProgressArgs()
            {
                PercentComplete = 50,
                StatusMessage = "Sample Job Processing for package at location: " + JobData
            });
            System.Threading.Thread.Sleep(1000);
            ProgressReported?.Invoke(this, new JobProgressArgs()
            {
                PercentComplete = 100,
                StatusMessage = "Sample Job Completed for package at location: " + JobData
            });
        }
    }
}
