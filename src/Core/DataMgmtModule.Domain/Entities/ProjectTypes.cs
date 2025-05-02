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
        public int ProjectTypeName { get; set; }
        public Boolean IsDelete { get; set; }
    }
}
