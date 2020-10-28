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
            
            //The implementation of the method should select from the drug inventory that supplies the country’s site, 
            //    the specified quantity of units of the requested type.
            //correla0tedData.Where(x => x.Country == siteId).Select(x => x.DrugCode).Take(quantity);
        }
    }
}
//CountryName = countries[i].Name,
//DepotName = depots[i].Name,
//PickNumber = drugUnits[j].PickNumber,
//DrugUnitId = drugUnits[j].Id,
//DrugTypeName = drugTypes[i + 1].Name,

//should select from the drug inventory that
//supplies the country’s site, the specified quantity of units of the requested type

    //In the Domain application, create an interface named ISiteDistributionService and a class 
//SiteDistributionService which will implement the newly created interface. 
//The signature of the method from ISiteDistributionService will be:
//IEnumerable<DrugUnit> GetRequestedDrugUnits(string siteId, string drugCode, int quantity);
//The implementation of the method should select from the drug inventory that 
//supplies the country’s site, the specified quantity of units of the requested type.