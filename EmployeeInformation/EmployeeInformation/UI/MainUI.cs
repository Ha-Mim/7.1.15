using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformation.UI;

namespace EmployeeInformation
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeUI employee = new EmployeeUI();
            employee.Show();
        }

        private void addDesignationButton_Click(object sender, EventArgs e)
        {
            AddDesignation designation = new AddDesignation();
            designation.Show();
        }

        private void findEditButton_Click(object sender, EventArgs e)
        {
            Find_EditUI aFindEditUi =new Find_EditUI();
            aFindEditUi.Show();
        }
    }
}
