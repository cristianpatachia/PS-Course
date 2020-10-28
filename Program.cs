using System;
using System.Collections.Generic;
using System.Linq;
using CristianPatachia.DataModel;
using CristianPatachia.Domain;
using CristianPatachia.Domain.CorrelationService;
using CristianPatachia.Domain.Implementation;
using CristianPatachia.Domain.Interfaces;

namespace CristianPatachia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var systemDataSet           = new SystemDataSet();
            var depotInventoryService   = new DepotInventoryService();
            var depotCorrelationService = new DepotCorrelationService(systemDataSet);
            var siteDistributionService = new SiteDistributionService(systemDataSet, depotCorrelationService);

            var countries   = systemDataSet.Countries;
            var depots      = systemDataSet.Depots;
            var drugUnits   = systemDataSet.DrugUnits;
            var drugTypes   = systemDataSet.DrugTypes;
            var sites       = systemDataSet.Sites;

            //foreach (var country in countries) { Console.WriteLine($"Country Id: {country.Id}, Name: {country.Name}"); }
            //foreach (var depot in depots) { Console.WriteLine($"Depot Id: {depot.Id}, Name: {depot.Name}"); }
            //foreach (var type in drugTypes) { Console.WriteLine($"Drug Id: {type.Id}, Name: {type.Name}"); }
            //foreach (var unit in drugUnits) { Console.WriteLine($"Drug Unit: {unit.Id}, PickNumber: {unit.PickNumber}"); }

            depotInventoryService.AssociateDrugs(ref drugUnits, "SUV01", 5, 18);
            //foreach (var unit in drugUnits)
            //{
            //    if (unit.Destination != null)
            //    { Console.WriteLine($"PickNumber {unit.PickNumber} is set for shipment to {unit.Destination}"); }
            //}

            depotInventoryService.DisassociateDrugs(ref drugUnits, 9, 12);
            //foreach (var unit in drugUnits)
            //{
            //    if (unit.Destination == null)
            //    { Console.WriteLine($"PickNumber {unit.PickNumber} is not assigned to a depot."); }
            //}

            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                    LabelDrugs("PainkillerAB", i, drugUnits);
                else
                    LabelDrugs("PainkillerXY", i, drugUnits);
            }

            //foreach (var type in drugUnits) { Console.WriteLine($"Drug Id: {type.Id} has been assigned to Type: {type.AssignedType}"); }
            //var sortedDrugs = AssignDrugType(drugUnits);

            var sortedDrugs = drugUnits.ToGroupedDrugUnitsgro();

            //foreach (var entry in sortedDrugs)
            //{
            //    Console.WriteLine($"{entry.Key}");
            //        foreach (var item in entry.Value)
            //        {
            //            Console.WriteLine($"Id: {item.Id}, PickNumber: {item.PickNumber}; ");
            //        }
            //}

            //var correlatedData = depotCorrelationService.CorrelateData();
            //foreach (var entry in correlatedData)
            //{
            //    Console.WriteLine($"Depot: {entry.DepotName}; Country: {entry.CountryId}; Drug type: {entry.DrugTypeName}; Drug Unit: {entry.DrugUnitId} Pick Number: {entry.PickNumber}");
            //}

            var requestedDrugs = siteDistributionService.GetRequestedDrugUnits("F02", "PainkillerXY", 5);
            Console.WriteLine($"Requested drugs for site 2: ");
            foreach (var reqDrug in requestedDrugs)
            {
                Console.WriteLine($"Drug Unit Id: {reqDrug.Id} - Pick Number: {reqDrug.PickNumber} - Drug Type: {reqDrug.AssignedType}");
            }

            Console.ReadLine();

        }

        public static void LabelDrugs(string drugName, int drugId, List<DrugUnit> drugUnits)
        {
            foreach (var drug in drugUnits)
            {
                if (drug.Id == drugId)
                {
                    drug.AssignedType = drugName;
                }
            }
        }

        public static Dictionary<string, List<DrugUnit>> AssignDrugType(List<DrugUnit> drugUnits)
                    => drugUnits
                        .GroupBy(x => x.AssignedType)
                        .ToDictionary(x => x.Key, x => x.ToList());

    }
}
