using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCcrudApplication.Models
{
    public class DAC
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnectionString"].ConnectionString.ToString();
        public List<Employee> getEmployee()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> emp = new List<Employee>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    emp.Add(new Employee
                    {
                        EmpID = Convert.ToInt32(reader["EmpID"]),
                        Name = reader["Name"].ToString(),
                        Department = reader["Department"].ToString(),
                        Location = reader["Location"].ToString(),
                        Salary = Convert.ToInt32(reader["Salary"])
                    });
                }
            }
            con.Close();
            return emp;
        }

        public void insertEmployee(string Name, string Department, string Location, int Salary)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_insertEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name", Name).ToString();
            cmd.Parameters.AddWithValue("Department", Department).ToString();
            cmd.Parameters.AddWithValue("Location", Location).ToString();
            cmd.Parameters.AddWithValue("Salary", Salary);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateEmployee(int EmpID, string Name, string Department, string Location, int Salary)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_updateEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpID", EmpID);
            cmd.Parameters.AddWithValue("Name", Name).ToString();
            cmd.Parameters.AddWithValue("Department", Department).ToString();
            cmd.Parameters.AddWithValue("Location", Location).ToString();
            cmd.Parameters.AddWithValue("Salary", Salary);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteEmployee(int EmpID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_deleteEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpID", EmpID).ToString();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Employee getEmployeebyID(int EmpID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getEmpbyID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpID", EmpID);
            SqlDataReader reader = cmd.ExecuteReader();
            Employee emp = new Employee();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    emp.EmpID = Convert.ToInt32(reader["EmpID"]);
                    emp.Name = Convert.ToString(reader["Name"]);
                    emp.Department = Convert.ToString(reader["Department"]);
                    emp.Location = Convert.ToString(reader["Location"]);
                    emp.Salary = Convert.ToInt32(reader["Salary"]);
                }
            }
            con.Close();
            return emp;
        }
        
    }
}