using MySql.Data.MySqlClient;
using CSharpASPandADO.Models;

public class EmployeeService
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public EmployeeService(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public void AddEmployee(Employee employee)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            string query = "INSERT INTO Employees (EmpNo, EmpName, EmpDesignation, EmpSalary) VALUES (@EmpNo, @EmpName, @EmpDesignation, @EmpSalary)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@EmpNo", employee.EmpNo);
            cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
            cmd.Parameters.AddWithValue("@EmpDesignation", employee.EmpDesignation);
            cmd.Parameters.AddWithValue("@EmpSalary", employee.EmpSalary);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // To see the all employee details

    public List<Employee> GetAllEmployees()
    {
        List<Employee> employeeList = new List<Employee>();

        using (MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            string query = "SELECT EmpNo, EmpName, EmpDesignation, EmpSalary FROM Employees";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Employee emp = new Employee
                {
                    EmpNo = Convert.ToInt32(reader["EmpNo"]),
                    EmpName = reader["EmpName"].ToString(),
                    EmpDesignation = reader["EmpDesignation"].ToString(),
                    EmpSalary = Convert.ToInt32(reader["EmpSalary"])
                };

                employeeList.Add(emp);
            }

            reader.Close();
        }

        return employeeList;
    }

    // Update Employee
    public void UpdateEmployee(Employee employee)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            string query = "UPDATE Employees SET EmpName=@EmpName, EmpDesignation=@EmpDesignation, EmpSalary=@EmpSalary WHERE EmpNo=@EmpNo";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmpNo", employee.EmpNo);
            cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
            cmd.Parameters.AddWithValue("@EmpDesignation", employee.EmpDesignation);
            cmd.Parameters.AddWithValue("@EmpSalary", employee.EmpSalary);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // Delete Employee
    public void DeleteEmployee(int empNo)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            string query = "DELETE FROM Employees WHERE EmpNo=@EmpNo";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmpNo", empNo);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // Get single employee by ID
    public Employee GetEmployeeById(int empNo)
    {
        Employee employee = null;

        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            string query = "SELECT EmpNo, EmpName, EmpDesignation, EmpSalary FROM Employees WHERE EmpNo=@EmpNo";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmpNo", empNo);

            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmpNo = Convert.ToInt32(reader["EmpNo"]),
                        EmpName = reader["EmpName"].ToString(),
                        EmpDesignation = reader["EmpDesignation"].ToString(),
                        EmpSalary = Convert.ToInt32(reader["EmpSalary"])
                    };
                }
            }
        }

        return employee;
    }


}
