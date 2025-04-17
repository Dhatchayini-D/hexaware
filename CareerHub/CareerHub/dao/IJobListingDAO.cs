using CareerHub.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.dao
{
    public interface IJobListingDAO
    {
        void AddJob(JobListing job);
        void UpdateJob(JobListing job);
        void DeleteJob(int jobId);
        JobListing GetJobById(int jobId);
        List<JobListing> GetAllJobs();
        List<JobListing> SearchJobs(string keyword);
    }
}
