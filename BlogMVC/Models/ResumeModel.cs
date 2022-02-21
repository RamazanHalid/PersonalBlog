using Entities.Concrete;
using System.Collections.Generic;

namespace BlogMVC.Models
{
    public class ResumeModel
    {
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
