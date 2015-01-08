using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformation.DAL;
using EmployeeInformation.DAL.DAO;
using EmployeeInformation.DAL.DB_Gateway;

namespace EmployeeInformation.BLL
{
    class ViewManager
    {
        public List<View> SearchEmployees(string name)
        {
            ViewDBGateway aViewDbGateway = new ViewDBGateway();
            return aViewDbGateway.Search(name);
        } 
    }
}
