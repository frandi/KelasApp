using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.School
{
    public interface ISchoolService
    {
        /// <summary>
        /// Get a school by its id
        /// </summary>
        /// <param name="schoolId">Id of the school</param>
        /// <returns></returns>
        Task<School> GetSchool(Guid schoolId);

        /// <summary>
        /// Get school by its name
        /// </summary>
        /// <param name="name">Name of the school</param>
        /// <returns></returns>
        Task<School> GetSchoolByName(string name);

        /// <summary>
        /// Get all schools
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<School>> GetSchools();

        /// <summary>
        /// Get schools based on certain criteria
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        Task<IEnumerable<School>> GetSchools(List<SearchCriteria> searchCriteria);

        /// <summary>
        /// Get schools by owner
        /// </summary>
        /// <param name="owner">Owner user name</param>
        /// <returns></returns>
        Task<IEnumerable<School>> GetSchoolsByOwner(string owner);

        /// <summary>
        /// Create a new school
        /// </summary>
        /// <param name="newSchool">New school details</param>
        /// <returns></returns>
        Task<School> CreateSchool(NewSchool newSchool);

        /// <summary>
        /// Update a school
        /// </summary>
        /// <param name="schoolId">Id of the school</param>
        /// <param name="editSchool">Updated details of the school</param>
        /// <returns></returns>
        Task<School> UpdateSchool(Guid schoolId, EditSchool editSchool);

        /// <summary>
        /// Delete a school
        /// </summary>
        /// <param name="schoolId">Id of the school</param>
        /// <returns></returns>
        Task<int> DeleteSchool(Guid schoolId);
    }
}
