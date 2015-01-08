using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformation.DAL.DAO;
using EmployeeInformation.DAL.DB_Gateway;

namespace EmployeeInformation.BLL
{
    class EmployeeManager
    {
       
       

        public string Save(Employee aEmployee)
        {
            EmployeeDBGateway aEmployeeDbGateway = new EmployeeDBGateway();
            if (aEmployeeDbGateway.UniqueCheker(aEmployee.Email)==null)
            {
               aEmployeeDbGateway.Save(aEmployee);
                return "Successfully Save";
            }
            else
            {
                return "Please Give a unique email!";
            }
        }

       
    }
}
