using System;
using System.Collections.Generic;
using System.Text;
using CristianPatachia.DataModel;

namespace CristianPatachia.Domain.CorrelationService
{
    public abstract class BaseCorrelationService<T>
    {
        protected readonly SystemDataSet DataSet;

        public BaseCorrelationService(SystemDataSet dataSet)
        {
            this.DataSet = dataSet;
        }

        public abstract T CorrelateData();
    }
}
