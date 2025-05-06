using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class States
    {
        [Key]
        public int? StateId { get; set; }
        public string? StatesName { get; set; }
        //public ICollection<Cities> Cities { get; set; }
        //public bool IsDelete { get; set; }
    }
}
