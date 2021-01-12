using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinq
{
    [Table(Name = "Subjects")]
    public class dbSubject
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int SubjectId { get; set; }
        [Column]
        public string SubjectName { get; set; }
        [Column]
        public int LectureHours { get; set; }
        [Column]
        public int LabHours { get; set; }
        [Column]
        public int ControlTypeId { get; set; }
        [Column]
        public int EducatorId { get; set; }
    }
}
