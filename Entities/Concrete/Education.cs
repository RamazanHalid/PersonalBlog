using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Education : IEntity
    {
        public int EducationId { get; set; } 
        public string SchoolTypeTr { get; set; }
        public string SchoolTypeEn { get; set; }
        public string HeaderTr { get; set; }
        public string HeaderEn { get; set; }
        public string ContentTr { get; set; }
        public string ContentEn { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
