using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation.DAL.DB_Gateway
{
    internal class EmployeeDBGateway
    {
         string connectionString = @"Data Source= (LOCAL)\SQLEXPRESS; Database = Employee DB; Integrated Security = true";
        private SqlConnection connection;

        public EmployeeDBGateway()
        {
            connection=new SqlConnection(connectionString);
        }
     
        public void Save(Employee aEmployee)
        {

            connection.Open();
            string query = "INSERT INTO T_Employee VALUES('" + aEmployee.Name + "','" + aEmployee.Email + "','" +
                           aEmployee.Address + "','" + aEmployee.DesignationId + "')";
            SqlCommand command = new SqlCommand(query, connection);
           command.ExecuteNonQuery();
            connection.Close();

        }

        public Employee UniqueCheker(string email)
        {


            connection.Open();
            string query = "SELECT * FROM T_Employee WHERE Email='" + email + "';";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();



                Employee aEmployee = new Employee();
                aEmployee.Name = reader["Name"].ToString();
                aEmployee.Email = reader["Email"].ToString();
                aEmployee.Address = reader["Address"].ToString();
                reader.Close();
                connection.Close();
                return aEmployee;
            }
            else
            {
                reader.Close();
                connection.Close();
                return null;
            }


        }
       
    }

}
