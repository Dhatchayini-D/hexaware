using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using CareerHub.entity;


public class DatabaseManager
{
    string connectionString = "Server=DHATCHAYINI;Database=CareerHub;Integrated Security=True;";


    // Insert a JobListing into the database
    public void InsertJobListing(JobListing job)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO JobListings (JobID, JobTitle, CompanyName, Salary) VALUES (@JobID, @JobTitle, @CompanyName, @Salary)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@JobID", job.JobID);
            command.Parameters.AddWithValue("@JobTitle", job.JobTitle);
            command.Parameters.AddWithValue("@CompanyName", job.CompanyName);
            command.Parameters.AddWithValue("@Salary", job.Salary);
            command.ExecuteNonQuery();
            Console.WriteLine($"Job listing '{job.JobTitle}' inserted into the database.");
        }
    }

    // Insert an Applicant into the database
    public void InsertApplicant(Applicant applicant)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Applicants (ApplicantID, Name, Email) VALUES (@ApplicantID, @Name, @Email)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantID", applicant.ApplicantID);
            command.Parameters.AddWithValue("@Name", applicant.Name);
            command.Parameters.AddWithValue("@Email", applicant.Email);
            
            Console.WriteLine($"Applicant '{applicant.Name}' inserted into the database.");
        }
    }

    // Insert a JobApplication into the database
    public void InsertJobApplication(JobApplication jobApplication)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO JobApplications (JobID, ApplicantID, CoverLetter) VALUES (@JobID, @ApplicantID, @CoverLetter)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@JobID", jobApplication.JobID);
            command.Parameters.AddWithValue("@ApplicantID", jobApplication.ApplicantID);
            command.Parameters.AddWithValue("@CoverLetter", jobApplication.CoverLetter);
            command.ExecuteNonQuery();
            Console.WriteLine($"Job application for Job {jobApplication.JobID} by Applicant {jobApplication.ApplicantID} inserted into the database.");
        }
    }

    // Fetch all JobListings from the database
    public List<JobListing> GetJobListings()
    {
        List<JobListing> jobListings = new List<JobListing>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM JobListings";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                JobListing job = new JobListing
                {
                    JobID = Convert.ToInt32(reader["JobID"]),
                    JobTitle = reader["JobTitle"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),
                    Salary = Convert.ToDecimal(reader["Salary"])
                };
                jobListings.Add(job);
            }
        }

        return jobListings;
    }

    // Fetch all Applicants from the database
    public List<Applicant> GetApplicants()
    {
        List<Applicant> applicants = new List<Applicant>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Applicants";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Applicant applicant = new Applicant
                {
                    ApplicantID = Convert.ToInt32(reader["ApplicantID"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                };
                applicants.Add(applicant);
            }
        }

        return applicants;
    }

    // Fetch all JobApplications from the database
    public List<JobApplication> GetJobApplications()
    {
        List<JobApplication> jobApplications = new List<JobApplication>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM JobApplications";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                JobApplication jobApplication = new JobApplication
                {
                    JobID = Convert.ToInt32(reader["JobID"]),
                    ApplicantID = Convert.ToInt32(reader["ApplicantID"]),
                    CoverLetter = reader["CoverLetter"].ToString()
                };
                jobApplications.Add(jobApplication);
            }
        }

        return jobApplications;
    }

    internal void InitializeDatabase()
    {
        
    }

    internal void InsertCompany(Company company)
    {
        
    }

    internal List<JobListing> GetJobListingsInSalaryRange(decimal minSalary, decimal maxSalary)
    {
        throw new NotImplementedException();
    }

    internal List<JobApplication> GetApplicationsForJob(int jobIDForApplicants)
    {
        throw new NotImplementedException();
    }
}


