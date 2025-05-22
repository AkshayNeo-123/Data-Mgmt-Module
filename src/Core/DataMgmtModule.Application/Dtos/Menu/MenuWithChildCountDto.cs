using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.Menu
{
    public class MenuWithChildCountDto
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        //public string Path { get; set; }
        //public string Icon { get; set; }
        public int Order { get; set; } 
        public int? ParentId { get; set; }
        public int ChildCount { get; set; }
        public string? Route { get; set; }
        //public List<MenuWithChildCountDto> Children { get; set; } = new();
    }
}
