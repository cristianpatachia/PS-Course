using System;
using System.Collections.Generic;
using System.Linq;
using CristianPatachia.DataModel;

namespace CristianPatachia.DataModel 
{
    public class SystemDataSet 
    {
        public List<Country> Countries;
        public List<Depot> Depots;
        public List<DrugType> DrugTypes;
        public List<DrugUnit> DrugUnits;
        public List<Site> Sites;

        public SystemDataSet()
        {
            Countries   = new List<Country>();
            Depots      = new List<Depot>();
            DrugTypes   = new List<DrugType>();
            DrugUnits   = new List<DrugUnit>();
            Sites       = new List<Site>();

            // country
            Countries.Add(new Country() { Id = 1, Name = "USA" } );
            Countries.Add(new Country() { Id = 2, Name = "Canada" } );
            Countries.Add(new Country() { Id = 3, Name = "Mexico" });
            
            //depot
            Depots.Add(new Depot() { Id = "SUV01", Name = "AAADepot" } );
            Depots.Add(new Depot() { Id = "SUV02", Name = "BBBDepot" } );
            Depots.Add(new Depot() { Id = "SUV03", Name = "CCCDepot" });

            // drugTypes
            DrugTypes.Add(new DrugType() { Id = "P001", Name = "PainkillerAB" } );
            DrugTypes.Add(new DrugType() { Id = "P002", Name = "PainkillerXY"} );
            DrugTypes.Add(new DrugType() { Id = "P003", Name = "PainkillerZZ" });

            // drugUnits
            for (int i = 1; i <= 20; i++)
            { DrugUnits.Add(new DrugUnit() { Id = 21 - i, PickNumber = i }); }

            // site
            Sites.Add(new Site() { Id = "F01", Name = "Facility01", CountryCode = 1 });
            Sites.Add(new Site() { Id = "F02", Name = "Facility02", CountryCode = 2 });
            Sites.Add(new Site() { Id = "F03", Name = "Facility03", CountryCode = 1 });
            Sites.Add(new Site() { Id = "F04", Name = "Facility04", CountryCode = 3 });
        }
    }
}
