using CristianPatachia.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CristianPatachia.Domain.Interfaces
{
    public interface ISiteDistributionService
    {
        IEnumerable<DrugUnit> GetRequestedDrugUnits(string siteId, string drugCode, int quantity);
    }
}