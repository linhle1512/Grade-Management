using MRA_Client.Controller;
using MRA_Client.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MRA_Client
{
    public partial class StudentGrade : Form
    {
        public Account Account { get; set; }




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
            cbSubject.ValueMember = "roll";
            cbSubject.DataSource = StudentMarkController.GetListOfSubject(rollStudent);
            LoadData();
            LoadGrandItem();
        }
        List<GrandItem> grandItems;

        private void LoadData()
        {

            string rollStudent = Account.Roll;
            dgvMarkReport.DataSource = StudentMarkController.GetScoreStudent(rollStudent);
            foreach (GrandItem grandItem in grandItems)
            {
                dgvMarkReport.Columns.Add(grandItem.RollType, grandItem.Name + " (" + grandItem.Weight + ")");
                dgvMarkReport.Columns[grandItem.RollType].Width = 150;
                dgvMarkReport.Columns[grandItem.RollType].DataPropertyName = grandItem.RollType;
            }
        }

        private void LoadGrandItem()
        {

            string rollSuject = cbSubject.SelectedValue.ToString();

            grandItems = ManagementController.GetGrandType(rollSuject);


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrandItem();

        }
    }
}
