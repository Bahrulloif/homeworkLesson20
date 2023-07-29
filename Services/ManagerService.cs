using Dapper;
using Npgsql;

public class ManagerService
{

    private string _connectionString = "Server=localhost;Port=5432;Database=homework;User Id=postgres;Password=postgres;";

    public List<Manager> GetManagers()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            return connection.Query<Manager>(
                "select emp.id as ManagerId, concat(emp.firstname, ' ', emp.lastname) as ManagerFullName, dep.id as DepartmentId, dep.name as DepartmentName, dm.fromdate, dm.todate " +
                "from department as dep " +
                "join department_manager as dm " +
                "on dm.departmentid=dep.id " +
                "join employee as emp " +
                "on emp.id=dm.employeeid").ToList();
        }
    }



    public void Insert(Manager dep)
    {
        // Add contact to database
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO department_manager (managerid, departmentid, fromdate) " +
                         $"VALUES (@managerid, @departmentid, @fromdate) returning id;";
            var createdId = connection.ExecuteScalar<int>(sql, dep);
        }
    }
}