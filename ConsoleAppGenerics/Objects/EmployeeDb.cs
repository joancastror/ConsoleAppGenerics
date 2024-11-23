
using ConsoleAppGenerics.Class;
using ConsoleAppGenerics.Interfaces;
using ConsoleAppGenerics.Models;
using System.Linq.Expressions;

namespace ConsoleAppGenerics.Objects
{
    public class EmployeeDb : IBaseRepository<Employee, EmployeeResult, List<EmployeeResult>>
    {
        private readonly List<Employee> employees;

        public EmployeeDb(List<Employee> employees)
        {
            this.employees = employees;
        }
        public Task<bool> Exists(Func<Employee, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeResult>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeResult>> GetAll(Func<Employee, bool> filter)
        {
           
            throw new NotImplementedException();
        }

        public Task<EmployeeResult> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeResult> Remove(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeResult> Save(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeResult> Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
