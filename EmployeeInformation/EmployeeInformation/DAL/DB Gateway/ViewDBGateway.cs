using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using View = EmployeeInformation.DAL.DAO.View;

namespace EmployeeInformation.DAL
{
    class ViewDBGateway
    {
        
        string connectionString = @"Data Source= (LOCAL)\SQLEXPRESS; Database = Employee DB; Integrated Security = true";
        private SqlConnection connection;

        public  ViewDBGateway()
        {
            connection=new SqlConnection(connectionString);
        }
     
        public List<View> Search(string name)
        {
            string query = "";
            

            connection.Open();
            if (name != string.Empty)
            {
                query = "SELECT  T_Employee.SerialNo,T_Employee.Name,T_Employee.Email,T_Employee.Address,T_Designation.Code,T_Designation.Designation FROM T_Employee LEFT JOIN T_Designation ON T_Employee.Designation_Id=T_Designation.Id WHERE T_Employee.Name='" + name + "';";
            }
            else
            {
                query = "SELECT  T_Employee.SerialNo,T_Employee.Name,T_Employee.Email,T_Employee.Address,T_Designation.Code,T_Designation.Designation FROM T_Employee LEFT JOIN T_Designation ON T_Employee.Designation_Id=T_Designation.Id;";
            }
            List<View> viewList = new List<View>();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                View aView = new View();
                aView.SerialNo = reader["SerialNo"].ToString();
                aView.Name = reader["Name"].ToString();
                aView.Email = reader["Email"].ToString();
                aView.Address = reader["Address"].ToString();
                aView.Code = reader["Code"].ToString();
                aView.Designation = reader["Designation"].ToString();

                viewList.Add(aView);

            }
            reader.Close();
            connection.Close();
            return viewList;
        }
    }
  
      
}
