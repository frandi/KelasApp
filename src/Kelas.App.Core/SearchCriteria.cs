using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core
{
    public class SearchCriteria
    {
        public SearchOperator SearchOperator { get; set; }
        public string SearchField { get; set; }
        public string SearchValue { get; set; }
    }

    public enum SearchOperator
    {
        Equals, StartsWith, Contains, LessThan, GreaterThan
    }
}
