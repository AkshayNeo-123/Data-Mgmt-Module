using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.Dosage;

namespace DataMgmtModule.Application.Dtos.CommonDtos
{
    public class CompoundingDataAndComponents
    {
        public CompoundingDataDTO CompoundingDataDTO { get; set; }
        public CompoundingComponentsDTO[] Components{get;set;}
        public DosageDTO DosageDTO { get; set; }
    }
}
