using System;
using System.Collections.Generic;
using System.Text;
using CristianPatachia.DataModel;

namespace CristianPatachia.Domain.Interfaces
{
    public interface IDepotInventoryService
    {
        void AssociateDrugs(ref List<DrugUnit> drugUnits, string depotId, int startPickNumber, int endPickNumber);
        void DisassociateDrugs(ref List<DrugUnit> drugUnits, int startPickNumber, int endPickNumber);
    }
}
