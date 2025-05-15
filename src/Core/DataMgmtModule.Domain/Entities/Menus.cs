using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class Menus
    {
        public int id { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public int Order { get; set; }
        public string Route { get; set; }
    }
}
