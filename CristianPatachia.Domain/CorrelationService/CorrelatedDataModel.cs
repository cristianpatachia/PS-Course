using System;
using System.Collections.Generic;
using System.Text;

namespace CristianPatachia.Domain.CorrelationService
{
    public class CorrelatedDataModel
    {
        public string DepotName { get; set; }
        public int CountryId { get; set; }
        public string DrugTypeName { get; set; }
        public int DrugUnitId { get; set; }
        public int PickNumber { get; set; }
    }
}
