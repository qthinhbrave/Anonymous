using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    public class MotaAttribute : Attribute
    {
        public MotaAttribute(string v) => Description = v;

        public string Description { set; get; }
    }
}
