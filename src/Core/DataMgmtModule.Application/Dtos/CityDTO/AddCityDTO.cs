using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.CityDTO
{
    public class AddCityDTO
    {
        public string? CityName { get; set; }
        public int? StateId { get; set; }
    }
}
