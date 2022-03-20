using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringToAnyType
{
    internal class Analyte
    {
        public string ComponentID { get; set; }


    }

    public class Program
    {
        static void Main(string[] args)
        {
            var s = new string[] { "paul", "bob", "lauren", "007", "90", "101", "3A", "2B" };
            foreach (var a in s.OrderBy(x => x, new SemiNumericComparer()))
            {
                Console.WriteLine(a);    
            }
                //[11530 = 1000][11530][11610 = 1000][11610][14540 = 1000][14540][148 = 1][148]
            ;

            var serviceSettings = new ServiceSettings()
            {
                Url = GetSettingOrDefault<string>("Url"),
                Enabled = GetSettingOrDefault<bool>("Enable"),
                Retries = GetSettingOrDefault<int>("Retries"),
                StartDate = GetSettingOrDefault<DateTime>("StartDate")
            };

            var pointObj = new Point<double>();
            pointObj.X = 1.2;
            var convertToInt = pointObj.AsTof<int>();

            var pointObj2 = new Point<string>();
            pointObj2.X = "1.2";
            convertToInt = pointObj.AsTof<int>();
            ;

        }

        public static T GetSettingOrDefault<T>(string settingName)
            where T : IConvertible
        {
            var settingValue = ConfigurationManager.AppSettings[settingName];

            if (settingValue == null)
            {
                return default(T);
            }

            return (T) Convert.ChangeType(settingValue, typeof(T));
        }

    }

    internal class ServiceSettings
    {
        public string Url { get; set; }
        public int Retries { get; set; }
        public bool Enabled { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class Point<T>
    {
        public T X { get; set; }

        public TOutput AsTof<TOutput>()
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            var result = converter.ConvertTo(this.X, typeof(TOutput));

            return (TOutput) result;
        }
    }

    public class SemiNumericComparer : IComparer<string>
    {
        /// <summary>
        /// Method to determine if a string is a number
        /// </summary>
        /// <param name="value">String to test</param>
        /// <returns>True if numeric</returns>
        public static bool IsNumeric(string value)
        {
            return int.TryParse(value, out _);
        }

        /// <inheritdoc />
        public int Compare(string s1, string s2)
        {
            const int S1GreaterThanS2 = 1;
            const int S2GreaterThanS1 = -1;

            var IsNumeric1 = IsNumeric(s1);
            var IsNumeric2 = IsNumeric(s2);

            if (IsNumeric1 && IsNumeric2)
            {
                var i1 = Convert.ToInt32(s1);
                var i2 = Convert.ToInt32(s2);

                if (i1 > i2)
                {
                    return S1GreaterThanS2;
                }

                if (i1 < i2)
                {
                    return S2GreaterThanS1;
                }

                return 0;
            }

            if (IsNumeric1)
            {
                return S2GreaterThanS1;
            }

            if (IsNumeric2)
            {
                return S1GreaterThanS2;
            }

            return string.Compare(s1, s2, true, CultureInfo.InvariantCulture);
        }
    }
}
