using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection __conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            __conn = conn;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return __conn.Query<Department>("SELECT * FROM department");
        }

        public void InsertDepartment( string name) 
        {
            __conn.Execute("INTSERT INTO departments (Name) VALUES (@NAME)",
                new { name});
        }
    }
}
