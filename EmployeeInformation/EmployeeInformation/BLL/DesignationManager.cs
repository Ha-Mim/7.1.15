using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformation.DAL.DAO;
using EmployeeInformation.DAL.DB_Gateway;

namespace EmployeeInformation.BLL
{
  
    class DesignationManager
    {  
       const int  MIN_LENTH_OF_CODE = 3 ;
        public string Save(Designation aDesignation)
        {
            if (aDesignation.Code.Length >= MIN_LENTH_OF_CODE)
            {
                DesignationDBGateway aDesignationDbGateway = new DesignationDBGateway();
                Designation selactedDesignation=new Designation();
                selactedDesignation = aDesignationDbGateway.Find(aDesignation.Code);
                if (selactedDesignation == null)
                {


                    aDesignationDbGateway.Save(aDesignation);
                    return "Succesfully Saved";
                }
                else
                {
                    return "This code already exists";
                }
            }
            else
            {
                return "Code must be" + MIN_LENTH_OF_CODE + "char long";
            }
        }

        public List<Designation> Combobox()
        {
            DesignationDBGateway aDesignationDbGateway = new DesignationDBGateway();
            return aDesignationDbGateway.ComboboxLoad();
        }
    }
}
