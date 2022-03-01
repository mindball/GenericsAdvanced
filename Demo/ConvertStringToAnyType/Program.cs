using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringToAnyType
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceSettings = new ServiceSettings()
            {
                //Url = GetSettingOrDefault<string>("Url"),
                //Enabled = GetSettingOrDefault<bool>("Enable"),
                //Retries = GetSettingOrDefault<int>("Retries"),
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
            var settings = ConfigurationManager.AppSettings[settingName];

            if(settings == null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(settings, typeof(T));
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

            return (TOutput)result;
        }
    }
    
}
