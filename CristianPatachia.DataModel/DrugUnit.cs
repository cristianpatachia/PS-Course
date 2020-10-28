using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CristianPatachia;

namespace CristianPatachia.DataModel
{
    public class DrugUnit
    {
        public int Id { get; set; }
        public int PickNumber { get; set; }
        public string Destination { get; set; }
        public string AssignedType { get; set; } 
    }
   
}

