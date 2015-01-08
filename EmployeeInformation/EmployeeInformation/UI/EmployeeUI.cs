using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation
{
    public partial class EmployeeUI : Form
    {
        public EmployeeUI()
        {
            InitializeComponent();
        }
        private EmployeeManager aEmployeeManager = new EmployeeManager();
        private DesignationManager aDesignationManager = new DesignationManager();
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            List<Designation> aDesignationList=new List<Designation>();
            aDesignationList = aDesignationManager.Combobox();
            foreach (Designation aDesignation in aDesignationList)
            {
                designationComboBox.Items.Add(aDesignation);
            }
            designationComboBox.DisplayMember = "Name";
            designationComboBox.ValueMember = "Id";
        }

     
        private void saveButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee=new Employee();
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
           
   
            Designation selectedDesignation = (Designation)designationComboBox.SelectedItem;
            aEmployee.DesignationId = selectedDesignation.Id;
            string msg=aEmployeeManager.Save(aEmployee);
            MessageBox.Show(msg);

        }

        
    }
}
