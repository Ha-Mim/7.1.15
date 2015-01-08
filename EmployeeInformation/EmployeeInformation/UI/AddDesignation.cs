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
    public partial class AddDesignation : Form
    {
        public AddDesignation()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Designation aDesignation = new Designation();
            aDesignation.Code = codeTextBox.Text;
            aDesignation.Name = titleTextBox.Text;
            DesignationManager aDesignationManager = new DesignationManager();
            string msg = aDesignationManager.Save(aDesignation);
            MessageBox.Show(msg);

        }
    }
}
