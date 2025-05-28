using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
namespace EmployeeWebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EmployeeService : System.Web.Services.WebService
    {
        private string connectionString =
       ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        [WebMethod]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, name, department FROM emp_info", con);
               
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())

                {
                    employees.Add(new Employee
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Name = rdr["name"].ToString(),
                        Department = rdr["department"].ToString()
                    });
                }
            }
            return employees;
        }
        [WebMethod]
        public int AddEmployee(string name, string department)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO emp_info (name, department) VALUES (@name, @department); SELECT SCOPE_IDENTITY(); ",
            con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@department", department);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        [WebMethod]
        public bool UpdateEmployee(int id, string name, string department)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE emp_info SET name = @name, department = @department WHERE id = @id",
               
                con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@department", department);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        [WebMethod]
        public bool DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM emp_info WHERE id =@id", con);
               
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        [WebMethod]
        public List<Employee> SearchEmployees(string searchTerm)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                "SELECT id, name, department FROM emp_info WHERE name LIKE @search OR department LIKE @search",
               
                con);
                cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Name = rdr["name"].ToString(),
                        Department = rdr["department"].ToString()
                    });
                }
            }
            return employees;
        }
    }
}
