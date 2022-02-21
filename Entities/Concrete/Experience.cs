using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Experience : IEntity
    {
        public int ExperienceId { get; set; } 
        public string CompanyNameTr { get; set; }
        public string CompanyNameEn { get; set; }
        public string RoleTr { get; set; }
        public string RoleEn { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
