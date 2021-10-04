using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_Commerce.Helpers
{
    public class FilterParameters
    {
        public string KeyWord { get; set; }
        private string _price;
        public string Price {
            get {
                return _price;
            }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Regex regex = new Regex(@"([a-zA-Z]+)(\d+)");
                    Match match = regex.Match(value);

                    if (match.Success)
                    {
                        Operator = match.Groups[1].Value;
                        CompareValue = Int32.Parse(match.Groups[2].Value);
                    }
                }

                _price = value;
            } 
        }
        public string Operator { get; set; }
        public int CompareValue { get; set; }

        public string Fields { get; set; }

        public string OrderBy { get; set; }
    }
}
