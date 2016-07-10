using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core
{
    public class SearchCriteria
    {
        SearchOperator SearchOperator { get; set; }
        string SearchField { get; set; }
    }

    public enum SearchOperator
    {
        Equals, StartsWith, EndsWith, LessThan, GreaterThan
    }
}
