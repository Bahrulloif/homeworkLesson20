using Dapper;
using Npgsql;

public class DepartmentService
{

    private string _connectionString = "Server=localhost;Port=5432;Database=homework;User Id=postgres;Password=postgres;";

    public List<Department> GetDepartments()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            return connection.Query<Department>(
                "select dep.id, dep.Name, dm.employeeid as ManagerId, concat(emp.firstname,' ', emp.lastname) as ManagerFullName " +
                "from department as dep  " +
                "left join department_manager as dm  " +
                "on dep.id=dm.departmentid " +
                "left join employee as emp " +
                "on emp.id=dm.employeeid").ToList();
        }
    }

     public Department GetDepartmentById(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "select dep.id, dep.Name, dm.employeeid as ManagerId, concat(emp.firstname,' ', emp.lastname) as ManagerFullName " +
                "from department_manager as dm " +
                "join department as dep " +
                "on dep.id=dm.departmentid " +
                "join employee as emp " +
                "on emp.id=dm.employeeid where dep.id=@id";
            var response = connection.QuerySingleOrDefault<Department>(sql, new { id });
            return response;
        }
    }

        public void Insert(Department dep)
    {
        // Add contact to database
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO department (id, name) " +
                         $"VALUES (@id, @name) returning id;";
            var createdId=connection.ExecuteScalar<int>(sql, dep);
            }
    }


    public int UpdateDepartment(Department dep)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update department set name = @Name where id = @id;";
            var response = connection.Execute(sql, dep);
            return response;
        }
    }




}