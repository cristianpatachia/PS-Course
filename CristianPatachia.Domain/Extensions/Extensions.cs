using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CristianPatachia.DataModel;

namespace CristianPatachia.Domain
{
    public static class Extensions
    {
        public static Dictionary<string, List<DrugUnit>> ToGroupedDrugUnitsgro(this List<DrugUnit> drugUnits) 
            => drugUnits
                .GroupBy(x => x.AssignedType)
                .ToDictionary(x => x.Key, x => x.ToList());
        
    }
}
