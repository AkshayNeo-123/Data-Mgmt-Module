using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.ComponentDto
{
    public class ComponentDto:Common
    {
        public int Id { get; set; }
        public string ComponentName { get; set; } = null!;
     
    }
}
