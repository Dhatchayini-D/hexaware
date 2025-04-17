using CareerHub.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.dao
{
    public interface IApplicantDAO
    {
        void AddApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void DeleteApplicant(int applicantId);
        Applicant GetApplicantById(int applicantId);
        List<Applicant> GetAllApplicants();
    }
}
