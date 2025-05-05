using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class ProjectTypes
    {
        public int Id { get; set; }
        public string ProjectTypeName { get; set; }
        public bool IsDelete { get; set; }
    }
}
