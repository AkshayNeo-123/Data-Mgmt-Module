using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]

        public States States { get; set; }
        //public bool? IsDelete { get; set; }
    }
}
