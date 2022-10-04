using Domain.Entities;
using Infrastructure.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepositories : IEmployeeRepository<Employee>
    {
        private readonly ISession _session;

        public EmployeeRepositories(ISession session)
        {
            _session = session;
        }

        public async Task Add(Employee entity)
        {
            ITransaction transaction = _session.BeginTransaction();
            await _session.SaveAsync(entity);
            await transaction.CommitAsync();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
