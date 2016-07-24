using Kelas.App.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.School
{
    public class SchoolService : ISchoolService
    {
        private ISchoolRepository _schoolRepo;

        public SchoolService(ISchoolRepository schoolRepo)
        {
            _schoolRepo = schoolRepo;
        }

        public async Task<School> CreateSchool(NewSchool newSchool)
        {
            if (newSchool == null)
                throw new ArgumentNullException(nameof(newSchool));

            return await _schoolRepo.Insert(newSchool);
        }

        public async Task<int> DeleteSchool(Guid schoolId)
        {
            if (schoolId.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(schoolId));

            return await _schoolRepo.Delete(schoolId);
        }

        public async Task<School> GetSchool(Guid schoolId)
        {
            if (schoolId.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(schoolId));

            return await _schoolRepo.GetById(schoolId);
        }

        public async Task<School> GetSchoolByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var criteria = new List<SearchCriteria>()
            {
                new SearchCriteria()
                {
                    SearchField = "Name",
                    SearchOperator = SearchOperator.Equals,
                    SearchValue = name
                }
            };

            var schools = await _schoolRepo.Get(criteria);

            return schools.FirstOrDefault();
        }

        public async Task<IEnumerable<School>> GetSchools()
        {
            return await _schoolRepo.Get(null);
        }

        public async Task<IEnumerable<School>> GetSchools(List<SearchCriteria> searchCriteria)
        {
            return await _schoolRepo.Get(searchCriteria);
        }

        public async Task<IEnumerable<School>> GetSchoolsByOwner(string owner)
        {
            if (string.IsNullOrEmpty(owner))
                throw new ArgumentNullException(nameof(owner));

            var criteria = new List<SearchCriteria>()
            {
                new SearchCriteria()
                {
                    SearchField = "Owner",
                    SearchOperator = SearchOperator.Equals,
                    SearchValue = owner
                }
            };

            return await _schoolRepo.Get(criteria);
        }

        public async Task<School> UpdateSchool(Guid schoolId, EditSchool editSchool)
        {
            if (schoolId.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(schoolId));

            if (editSchool == null)
                throw new ArgumentNullException(nameof(editSchool));

            return await _schoolRepo.Update(schoolId, editSchool);
        }
    }
}
