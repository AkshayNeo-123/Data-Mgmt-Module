using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class StorageLocation
    {
        public int Id { get; set; }

     
        [MaxLength(100)]
        public string Name { get; set; }

        //public ICollection<Materials> Materials { get; set; }
    }

}
