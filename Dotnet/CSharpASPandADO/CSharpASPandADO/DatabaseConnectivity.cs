using MySql.Data.MySqlClient;

public class DatabaseConnectivity
{
    public void TestDatabaseConnection()
    {
        string connectionString = "server=localhost;user=root;password=root;database=cplus";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connected to the database!");

                string query = "SELECT EmpNo, EmpName, EmpDesignation, EmpSalary FROM Employees";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"EmpNo: {reader["EmpNo"]}, Name: {reader["EmpName"]}, Designation: {reader["EmpDesignation"]}, Salary: {reader["EmpSalary"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
