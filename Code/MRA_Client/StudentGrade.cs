using MRA_Client.Controller;
using MRA_Client.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


namespace MRA_Client
{
    public partial class StudentGrade : Form
    {
        public Account Account { get; set; }
        List<GrandItem> grandItems;
        public StudentGrade(Account account)
        {
            Account = account;
            InitializeComponent();
        }

        private void StudentGrade_Load(object sender, EventArgs e)
        {
            LoadSubject();
            LoadData();
        }
        private void LoadSubject()
        {
            string rollStudent = Account.Roll;
            cbSubject.DisplayMember = "roll";
            cbSubject.DataSource = StudentMarkController.GetListOfSubject(rollStudent);
            LoadData();
        }
        private void LoadData()
        {
            dgvMarkReport.DataSource = null;
            dgvMarkReport.Columns.Clear();
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
