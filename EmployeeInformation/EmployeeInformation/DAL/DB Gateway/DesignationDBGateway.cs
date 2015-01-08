using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation.DAL.DB_Gateway
{
    internal class DesignationDBGateway
    {
        private string connectionString =
            @"Data Source= (LOCAL)\SQLEXPRESS; Database = Employee DB; Integrated Security = true";

        private SqlConnection connection;

        public DesignationDBGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public void Save(Designation aDesignation)
        {
            connection.Open();
            string query = "INSERT INTO T_Designation VALUES('" + aDesignation.Code + "','" + aDesignation.Name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public Designation Find(string code)
        {
            connection.Open();
            string query = "SELECT * FROM T_Designation WHERE Code ='" + code + "';";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)

            {
                reader.Read();
                Designation aDesignation = new Designation();
                aDesignation.Id = (int) reader["Id"];
                aDesignation.Code = reader["Code"].ToString();
                aDesignation.Name = reader["Designation"].ToString();
                reader.Close();
                connection.Close();
                return aDesignation;

            }
            else
            {

                reader.Close();
                connection.Close();
                return null;
            }

        }

        public List<Designation> ComboboxLoad()
        {


            List<Designation> designationList = new List<Designation>();


            connection.Open();
            string query = "SELECT * FROM T_Designation";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.Id = (int)reader["Id"];
                aDesignation.Code = reader["Code"].ToString();
                aDesignation.Name = reader["Designation"].ToString();
                designationList.Add(aDesignation);

            }
            reader.Close();
            connection.Close();
            return designationList;
        }


    }
}

