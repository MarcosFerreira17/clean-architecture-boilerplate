using Domain.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Infrastructure.Mappings
{
    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap()
        {
            Id(x=> x.Id, x=> 
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
            });

            Property(n => n.Name, n =>
            {
                n.Length(100);
                n.Type(NHibernateUtil.String);
                n.NotNullable(true);
            });

            Property(a => a.Age, a =>
            {
                a.Type(NHibernateUtil.Int64);
                a.NotNullable(true);
            });

            Property(s => s.Salary, s =>
            {
                s.Type(NHibernateUtil.Double);
                s.Scale(2);
                s.Precision(10);
                s.NotNullable(true);
            });
        }

    }
}
