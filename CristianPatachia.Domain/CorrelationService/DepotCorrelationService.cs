using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CristianPatachia.DataModel;

namespace CristianPatachia.Domain.CorrelationService
{
    public class DepotCorrelationService : BaseCorrelationService<List<CorrelatedDataModel>>
    {

        public DepotCorrelationService(SystemDataSet dataSet) : base(dataSet)
        {
        }

        public override List<CorrelatedDataModel> CorrelateData()
        {
            var correlatedData = new List<CorrelatedDataModel>();
            var countries = DataSet.Countries;
            var depots = DataSet.Depots;
            var drugUnits = DataSet.DrugUnits;
            var drugTypes = DataSet.DrugTypes;

            //correlatedData = drugUnits.Join(drugUnits,
            //                            d => d.AssignedType,
            //                            u => u.Destination,
            //                            (d, u) => new
            //                            {
            //                                d.Name,
            //                                u.Name,
            //                                d.PickNumber,
            //                                d.Id,
            //                                u.Id,
            //                            })
            //                            .OrderBy(d => d.PickNumber);

            //eturn correlatedData;

            //CountryName = countries[i].Name,
            //DepotName = depots[i].Name,
            //PickNumber = drugUnits[j].PickNumber,
            //DrugUnitId = drugUnits[j].Id,
            //DrugTypeName = drugTypes[i + 1].Name,



            for (int i = 0; i < countries.Count; i++)
            {
                for (int j = 0; j < drugUnits.Count; j++)
                {
                if (i + 1 >= countries.Count)
                {
                    break;
                }

                if (j % 2 == 0)
                {
                    correlatedData.Add(new CorrelatedDataModel
                    {
                        CountryId = countries[i].Id,
                        DepotName = depots[i].Name,
                        PickNumber = drugUnits[j].PickNumber,
                        DrugUnitId = drugUnits[j].Id,
                        DrugTypeName = drugTypes[i + 1].Name,
                    });
                }
                else
                {
                    correlatedData.Add(new CorrelatedDataModel
                    {
                        CountryId = countries[i + 1].Id,
                        DepotName = depots[i + 1].Name,
                        PickNumber = drugUnits[j].PickNumber,
                        DrugUnitId = drugUnits[j].Id,
                        DrugTypeName = drugUnits[i + 1].AssignedType
                    });
                }

            }
        }

            return correlatedData;
        }
    }
}
