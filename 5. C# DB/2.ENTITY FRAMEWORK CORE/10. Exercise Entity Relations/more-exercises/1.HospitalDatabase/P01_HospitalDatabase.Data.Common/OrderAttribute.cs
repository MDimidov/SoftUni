using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Common
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        public int Order { get; }

        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
}
