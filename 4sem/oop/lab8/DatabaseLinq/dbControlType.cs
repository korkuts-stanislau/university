using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinq
{
    [Table(Name = "ControlTypes")]
    public class dbControlType
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ControlTypeId { get; set; }
        [Column]
        public string ControlTypeName { get; set; }
    }
}
