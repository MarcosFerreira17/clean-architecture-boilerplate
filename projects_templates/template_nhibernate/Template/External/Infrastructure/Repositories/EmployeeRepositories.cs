using System.Linq;
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

        public IEnumerable<Employee> GetAll()
        {
            return _session.Query<Employee>().ToList();
        }

        public Task<Employee> GetById(long id)
        {
            return _session.GetAsync<Employee>(id);
        }

        public async Task Remove(long id)
        {
            ITransaction transaction = _session.BeginTransaction();
            var entity = await _session.GetAsync<Employee>(id);
            await _session.DeleteAsync(entity);
            await transaction.CommitAsync();
        }

        public async Task Update(Employee entity)
        {
            ITransaction transaction = _session.BeginTransaction();
            await _session.UpdateAsync(entity);
            await transaction.CommitAsync();
        }
    }
}
