using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.entity
{
    public class JobListing
    {
        internal object Title;

        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public decimal Salary { get; set; }
        public string JobType { get; set; }
        public DateTime PostedDate { get; set; }
        public object Description { get; internal set; }
        public object Location { get; internal set; }
        public object CompanyId { get; internal set; }
        public object JobId { get; internal set; }
        public string? CompanyName { get; internal set; }

        public JobListing() { }

        public JobListing(int jobID, int companyID, string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, DateTime postedDate)
        {
            JobID = jobID;
            CompanyID = companyID;
            JobTitle = jobTitle;
            JobDescription = jobDescription;
            JobLocation = jobLocation;
            Salary = salary;
            JobType = jobType;
            PostedDate = postedDate;
        }
    }
}
