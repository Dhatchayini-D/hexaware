using CareerHub.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.dao
{
    public interface IJobApplicationDAO
    {
        void ApplyForJob(JobApplication application);
        void UpdateApplication(JobApplication application);
        void DeleteApplication(int applicationId);
        JobApplication GetApplicationById(int applicationId);
        List<JobApplication> GetAllApplications();
        List<JobApplication> GetApplicationsByApplicant(int applicantId);
        List<JobApplication> GetApplicationsByJob(int jobId);
    }
}
