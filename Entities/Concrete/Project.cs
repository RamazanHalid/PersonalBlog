using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Project : IEntity
    {
        public int ProjectId { get; set; }
        public string ProjectNameTr { get; set; }
        public string ProjectNameEn { get; set; }
        public string ContentShortTr { get; set; }
        public string ContentShortEn { get; set; }
        public string ContentTr { get; set; }
        public string ContentEn { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Technologies { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }
        public int ViewCount { get; set; }
    }
}
