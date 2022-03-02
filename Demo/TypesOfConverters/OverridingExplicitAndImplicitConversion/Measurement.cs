using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesOfConverters.OverridingExplicitAndImplicitConversion
{
    public class Measurement
    {
        public int Value { get; set; }

        public static implicit operator Measurement(int value)
        {
            return new Measurement() { Value = value };
        }

        public static explicit operator int(Measurement m)
        {
            return m.Value;
        }
    }
}
