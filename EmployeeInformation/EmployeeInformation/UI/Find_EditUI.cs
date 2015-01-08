using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.DAO;
using View = EmployeeInformation.DAL.DAO.View;

namespace EmployeeInformation.UI
{
    public partial class Find_EditUI : Form
    {

        public Find_EditUI()
        {
            InitializeComponent();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ViewManager aViewManager = new ViewManager();
            Employee aEmploye = new Employee();
            aEmploye.Name = searchTextBox.Text;
            List<View> aView = new List<View>();
            aView = aViewManager.SearchEmployees(aEmploye.Name);
            showlistView.Items.Clear();

            foreach (View View in aView)
            {
                ListViewItem myView = new ListViewItem();
                myView.Text = (View.SerialNo.ToString());
                myView.SubItems.Add(View.Name);
                myView.SubItems.Add(View.Email);
                myView.SubItems.Add(View.Address);
                myView.SubItems.Add(View.Code);
                myView.SubItems.Add(View.Designation);

                showlistView.Items.Add(myView);
            }

        }



        public void ContextMenuOpening(object sender, CancelEventArgs e)
        {

            Point mousePosition = showlistView.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hit = showlistView.HitTest(mousePosition);

            e.Cancel = hit.Item == null;

            //if (e.Button == MouseButtons.Right)
            //{
            //    var loc = showlistView.HitTest(e.Location);

            //    if (loc.Item != null && contextMenuStrip1.Items.Count == 0)
            //    {

            //        contextMenuStrip1.Items.Add("TEST1");
            //        contextMenuStrip1.Items.Add("TEST2");

            //    }

            //private void showlistView_SelectedIndexChanged(object sender, EventArgs e)
            //{

            //}

        }
    }
}

