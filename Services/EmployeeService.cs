using Dapper;
using Npgsql;

public class EmployeeService
{
    private string _connectionString = "Server=localhost;Port=5432;Database=homework;User Id=postgres;Password=postgres;";

    public List<Employee> GetEmployee()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            return connection.Query<Employee>(
                "select emp.id, emp.firstname, emp.lastname, dep.id as DepartmentId, dep.name as DepartmentName " +
                "from department as dep " +
                "left join department_employee as de " +
                "on dep.id=de.departmentid " +
                "left join employee as emp " +
                "on de.employeeid=emp.id").ToList();
        }
    }

      public Employee GetEmployeeById(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "select emp.id, emp.firstname, emp.lastname, dep.id as DepartmentId, dep.name as DepartmentName " +
                "from department as dep " +
                "join department_employee as de " +
                "on dep.id=de.departmentid " +
                "join employee as emp " +
                "on de.employeeid=emp.id where emp.id=@id";
            var response = connection.QuerySingleOrDefault<Employee>(sql, new { id });
            return response;
        }
    }

        public void Insert(Employee emp)
    {
        // Add contact to database
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO Employee (id, birthdate, firstname, lastname, hiredate, gender)" +
                         $"VALUES (@id, @birthdate, @firstname, @lastname, @hiredate, @gender) returning id;";
            var createdId=connection.ExecuteScalar<int>(sql, emp);
            }
    }

     public int UpdateEmployee(Employee dep)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update Employee set birthdate = @birthdate, "+
            "firstname=@firstname, "+
            "lastname=@lastname, "+
            "hiredate=@hiredate, "+
            "gender=@gender "+
            "where id = @id;";
            var response = connection.Execute(sql, dep);
            return response;
        }
    }

}