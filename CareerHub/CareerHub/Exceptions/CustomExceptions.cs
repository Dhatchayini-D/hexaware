
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Custom Exception Classes for Job Board Application

//public class CustomExceptions
//{
//    // Exception for Invalid Email Format
//    public class InvalidEmailException : Exception
//    {
//        public InvalidEmailException(string message) : base(message) { }
//    }

//    // Exception for Invalid Salary Values (negative or invalid)
//    public class InvalidSalaryException : Exception
//    {
//        public InvalidSalaryException(string message) : base(message) { }
//    }

//    // Exception for File Upload Issues (e.g., file not found, unsupported format)
//    public class FileUploadException : Exception
//    {
//        public FileUploadException(string message) : base(message) { }
//    }

//    // Exception for Application Deadline Exceeding
//    public class DeadlineExceededException : Exception
//    {
//        public DeadlineExceededException(string message) : base(message) { }
//    }

//    // Exception for Database Connectivity Issues
//    public class DatabaseConnectionException : Exception
//    {
//        public DatabaseConnectionException(string message) : base(message) { }
//    }
//}




using System;

public class CustomExceptions
{
    // Exception for Invalid Email Format
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) { }

        public InvalidEmailException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception for Invalid Salary Values (negative or invalid)
    public class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message) { }

        public InvalidSalaryException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception for File Upload Issues (e.g., file not found, unsupported format)
    public class FileUploadException : Exception
    {
        public FileUploadException(string message) : base(message) { }

        public FileUploadException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception for Application Deadline Exceeding
    public class DeadlineExceededException : Exception
    {
        public DeadlineExceededException(string message) : base(message) { }

        public DeadlineExceededException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Exception for Database Connectivity Issues
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) { }

        public DatabaseConnectionException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
