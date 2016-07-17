using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Common.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Check if the Guid object is null or empty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Guid obj)
        {
            return obj == null || obj.Equals(Guid.Empty);
        }
    }
}
