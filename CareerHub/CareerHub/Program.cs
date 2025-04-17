using CareerHub.entity;

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Create an instance of the DatabaseManager
//        DatabaseManager dbManager = new DatabaseManager();
//        bool running = true;

//        while (running)
//        {
//            Console.WriteLine("\n--- CareerHub System ---");
//            Console.WriteLine("1. Initialize Database");
//            Console.WriteLine("2. Add Company");
//            Console.WriteLine("3. Add Applicant");
//            Console.WriteLine("4. Post Job Listing");
//            Console.WriteLine("5. Apply for Job");
//            Console.WriteLine("6. View Job Listings");
//            Console.WriteLine("7. View Applicants for Job");
//            Console.WriteLine("8. View Job Listings in Salary Range");
//            Console.WriteLine("9. Exit");

//            Console.Write("Select an option: ");
//            int choice = Convert.ToInt32(Console.ReadLine());

//            switch (choice)
//            {
//                case 1:
//                    dbManager.InitializeDatabase();
//                    break;

//                case 2:
//                    Console.WriteLine("Enter company name:");
//                    string companyName = Console.ReadLine();
//                    Console.WriteLine("Enter company location:");
//                    string location = Console.ReadLine();
//                    Company company = new Company { CompanyID = 1, CompanyName = companyName, Location = location };
//                    dbManager.InsertCompany(company);
//                    break;

//                case 3:
//                    Console.WriteLine("Enter applicant first name:");
//                    string firstName = Console.ReadLine();
//                    Console.WriteLine("Enter applicant last name:");
//                    string lastName = Console.ReadLine();
//                    Console.WriteLine("Enter applicant email:");
//                    string email = Console.ReadLine();
//                    Console.WriteLine("Enter applicant phone:");
//                    string phone = Console.ReadLine();
//                    Console.WriteLine("Enter applicant resume file name:");
//                    string resume = Console.ReadLine();
//                    Applicant applicant = new Applicant { ApplicantID = 1, FirstName = firstName, LastName = lastName, Email = email, Phone = phone, Resume = resume };
//                    dbManager.InsertApplicant(applicant);
//                    break;

//                case 4:
//                    Console.WriteLine("Enter job title:");
//                    string jobTitle = Console.ReadLine();
//                    Console.WriteLine("Enter job description:");
//                    string jobDescription = Console.ReadLine();
//                    Console.WriteLine("Enter job location:");
//                    string jobLocation = Console.ReadLine();
//                    Console.WriteLine("Enter salary:");
//                    decimal salary = Convert.ToDecimal(Console.ReadLine());
//                    Console.WriteLine("Enter job type (e.g., Full-time):");
//                    string jobType = Console.ReadLine();
//                    JobListing job = new JobListing { JobID = 1, CompanyID = 1, JobTitle = jobTitle, JobDescription = jobDescription, JobLocation = jobLocation, Salary = salary, JobType = jobType, PostedDate = DateTime.Now };
//                    dbManager.InsertJobListing(job);
//                    break;

//                case 5:
//                    Console.WriteLine("Enter job ID to apply for:");
//                    int jobID = Convert.ToInt32(Console.ReadLine());
//                    Console.WriteLine("Enter applicant ID:");
//                    int applicantID = Convert.ToInt32(Console.ReadLine());
//                    Console.WriteLine("Enter cover letter:");
//                    string coverLetter = Console.ReadLine();
//                    JobApplication application = new JobApplication { ApplicationID = 1, JobID = jobID, ApplicantID = applicantID, ApplicationDate = DateTime.Now, CoverLetter = coverLetter };
//                    dbManager.InsertJobApplication(application);
//                    break;

//                case 6:
//                    Console.WriteLine("Available Job Listings:");
//                    List<JobListing> jobListings = dbManager.GetJobListings();
//                    foreach (var jobListing in jobListings)
//                    {
//                        Console.WriteLine($"Job Title: {jobListing.JobTitle}, Salary: {jobListing.Salary}");
//                    }
//                    break;

//                case 7:
//                    Console.WriteLine("Enter job ID to view applicants:");
//                    int jobIDForApplicants = Convert.ToInt32(Console.ReadLine());
//                    List<JobApplication> applicationsForJob = dbManager.GetApplicationsForJob(jobIDForApplicants);
//                    foreach (var app in applicationsForJob)
//                    {
//                        Console.WriteLine($"Applicant ID: {app.ApplicantID}, Cover Letter: {app.CoverLetter}");
//                    }
//                    break;

//                case 8:
//                    Console.WriteLine("Enter minimum salary:");
//                    decimal minSalary = Convert.ToDecimal(Console.ReadLine());
//                    Console.WriteLine("Enter maximum salary:");
//                    decimal maxSalary = Convert.ToDecimal(Console.ReadLine());
//                    List<JobListing> jobsInRange = dbManager.GetJobListingsInSalaryRange(minSalary, maxSalary);
//                    foreach (var jobInRange in jobsInRange)
//                    {
//                        Console.WriteLine($"Job Title: {jobInRange.JobTitle}, Salary: {jobInRange.Salary}");
//                    }
//                    break;

//                case 9:
//                    running = false;
//                    Console.WriteLine("Exiting...");
//                    break;

//                default:
//                    Console.WriteLine("Invalid option. Please try again.");
//                    break;
//            }
//        }
//    }
//}












//using CareerHub.Entity;
//using CareerHub.Service;

//namespace CareerHub
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            bool exitProgram = false;

//            while (!exitProgram)
//            {
//                // Display the main menu
//                Console.Clear();
//                Console.WriteLine("********** CareerHub Menu **********");
//                Console.WriteLine("1. Post a Job");
//                Console.WriteLine("2. Apply for a Job");
//                Console.WriteLine("3. View Available Jobs");
//                Console.WriteLine("4. Exit");
//                Console.WriteLine("************************************");
//                Console.Write("Please enter your choice (1-4): ");

//                // Read user input
//                string userChoice = Console.ReadLine();

//                // Switch-case structure for dynamic menu options
//                switch (userChoice)
//                {
//                    case "1":
//                        PostJob();
//                        break;

//                    case "2":
//                        ApplyForJob();
//                        break;

//                    case "3":
//                        ViewAvailableJobs();
//                        break;

//                    case "4":
//                        exitProgram = true;
//                        Console.WriteLine("Exiting the program...");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice. Please select a valid option (1-4).");
//                        break;
//                }

//                // Wait for user to press a key before continuing
//                if (!exitProgram)
//                {
//                    Console.WriteLine("\nPress any key to continue...");
//                    Console.ReadKey();
//                }
//            }
//        }

//        // Method to post a job
//        static void PostJob()
//        {
//            Console.Clear();
//            Console.WriteLine("Enter Job Details:");

//            // Get job details from user
//            Console.Write("Job Title: ");
//            string title = Console.ReadLine();

//            Console.Write("Job Description: ");
//            string description = Console.ReadLine();

//            Console.Write("Salary: ");
//            decimal salary;
//            while (!decimal.TryParse(Console.ReadLine(), out salary))
//            {
//                Console.WriteLine("Invalid input. Please enter a valid salary.");
//            }

//            // Call the service to post the job
//            JobService.CreateJob(title, description, salary);
//            Console.WriteLine("Job posted successfully!");
//        }

//        // Method to apply for a job
//        static void ApplyForJob()
//        {
//            Console.Clear();
//            Console.WriteLine("Enter Applicant Details:");

//            // Get applicant details from user
//            Console.Write("Applicant Name: ");
//            string name = Console.ReadLine();

//            Console.Write("Applicant Email: ");
//            string email = Console.ReadLine();

//            Console.Write("Resume (file path or URL): ");
//            string resume = Console.ReadLine();

//            // Assuming there is a job to apply for, you'll need to implement job application logic
//            Console.WriteLine("Enter the Job ID you want to apply for:");
//            int jobId;
//            while (!int.TryParse(Console.ReadLine(), out jobId))
//            {
//                Console.WriteLine("Invalid Job ID. Please enter a valid ID.");
//            }

//            // Create an applicant object and apply for the job (this logic can be extended)
//            var applicant = new Applicant
//            {
//                Name = name,
//                Email = email,
//                Resume = resume
//            };

//            Console.WriteLine($"Applicant {applicant.Name} has applied for Job ID {jobId}.");
//            // For now, we're not implementing the actual application logic in the DAO layer, but you could extend it.
//        }

//        // Method to view available jobs (example for a simple job listing)
//        static void ViewAvailableJobs()
//        {
//            Console.Clear();
//            Console.WriteLine("Available Jobs:");

//            // This method can retrieve jobs from the database. For now, we'll simulate job listings.
//            Console.WriteLine("1. Software Engineer | Description: Develop web apps | Salary: $60000");
//            Console.WriteLine("2. Data Scientist | Description: Analyze big data | Salary: $75000");
//            Console.WriteLine("3. Frontend Developer | Description: Build user interfaces | Salary: $65000");

//            // In a real-world scenario, you would query the database to get a list of jobs.
//            Console.WriteLine("\nPress any key to continue...");
//            Console.ReadKey();
//        }
//    }
//}






namespace CareerHub
{
    class Program
    {
         static JobService jobService = new JobService(); // instance-based

        static void Main(string[] args)
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("********** CareerHub Menu **********");
                Console.WriteLine("1. Post a Job");
                Console.WriteLine("2. Apply for a Job");
                Console.WriteLine("3. View Available Jobs");
                Console.WriteLine("4. Exit");
                Console.WriteLine("************************************");
                Console.Write("Please enter your choice (1-4): ");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        PostJob();
                        break;
                    case "2":
                        ApplyForJob();
                        break;
                    case "3":
                        ViewAvailableJobs();
                        break;
                    case "4":
                        exitProgram = true;
                        Console.WriteLine("Exiting the program...");
                        break;
                }

                if (!exitProgram)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void PostJob()
        {
            Console.Clear();
            Console.WriteLine("Enter Job Details:");

            Console.Write("Job Title: ");
            string title = Console.ReadLine();

            Console.Write("Job Description: ");
            string description = Console.ReadLine();

            Console.Write("Salary: ");
            decimal salary;
            while (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid input. Please enter a valid salary.");
            }

            jobService.CreateJob(title, description, salary); // use instance here

            Console.WriteLine("Job posted successfully!");
        }

        static void ApplyForJob()
        {
            Console.Clear();
            Console.WriteLine("Enter Applicant Details:");

            Console.Write("Applicant Name: ");
            string name = Console.ReadLine();

            Console.Write("Applicant Email: ");
            string email = Console.ReadLine();

            Console.Write("Resume (file path or URL): ");
            string resume = Console.ReadLine();

            Console.WriteLine("Enter the Job ID you want to apply for:");
            int jobId;
            while (!int.TryParse(Console.ReadLine(), out jobId))
            {
                Console.WriteLine("Invalid Job ID. Please enter a valid ID.");
            }

            var applicant = new Applicant
            {
                ApplicantName = name,
                Email = email,
                Resume = resume
            };

            Console.WriteLine($"Applicant {applicant.ApplicantName} has applied for Job ID {jobId}.");
        }

        static void ViewAvailableJobs()
        {
            Console.Clear();
            Console.WriteLine("Available Jobs:");
            
        }
    }
}

