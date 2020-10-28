using CristianPatachia.DataModel;
using CristianPatachia.Domain.CorrelationService;
using CristianPatachia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CristianPatachia.Domain.Implementation
{
    public class SiteDistributionService : ISiteDistributionService
    {
        public SystemDataSet systemDataSet { get; set; }
        public DepotCorrelationService depotCorrelationService { get; set; }

        public SiteDistributionService(SystemDataSet systemDataSet, DepotCorrelationService depotCorrelationService)
        {
            this.systemDataSet = systemDataSet;
            this.depotCorrelationService = depotCorrelationService;
        }

        public IEnumerable<DrugUnit> GetRequestedDrugUnits(string siteId, string drugCode, int quantity)
        {
            var correlatedDataSet = depotCorrelationService.CorrelateData();
            var countryCode = systemDataSet.Sites
                                        .Where(x => x.Id == siteId)
                                        .Select(x => x.CountryCode)
                                        .FirstOrDefault();

            var requestedDrugs = correlatedDataSet
                                        .Where(x => x.CountryId == countryCode && x.DrugTypeName == drugCode)
                                        .Select(x => new DrugUnit
                                        {
                                            AssignedType = x.DrugTypeName,
                                            Id = x.DrugUnitId,
                                            PickNumber = x.PickNumber
                                        }).Take(quantity)
                                        .AsEnumerable();

            return requestedDrugs;
        }
    }
}
