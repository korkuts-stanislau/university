using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinq
{
    [Table(Name = "Educators")]
    public class dbEducator
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int EducatorId { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string MiddleName { get; set; }
    }
}
