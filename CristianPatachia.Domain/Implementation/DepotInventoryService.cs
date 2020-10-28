using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CristianPatachia.DataModel;
using CristianPatachia.Domain.Interfaces;

namespace CristianPatachia.Domain.Implementation
{
    public class DepotInventoryService : IDepotInventoryService
    {
        public void AssociateDrugs(ref List<DrugUnit> drugUnits, string depotId, int startPickNumber, int endPickNumber)
               => drugUnits
                    .Where(x => x.PickNumber > startPickNumber && x.PickNumber < endPickNumber)
                    .Select(x => { x.Destination = depotId; return x; });


        public void DisassociateDrugs(ref List<DrugUnit> drugUnits, int startPickNumber, int endPickNumber)
               => drugUnits
                    .Where(x => x.PickNumber > startPickNumber && x.PickNumber < endPickNumber)
                    .Select(x => { x.Destination = null; return x; });
    }
}
