using GameProject.loan.connection;
using GameProject.loan.models;
using GameProject.loan.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject.loan
{
    public partial class PaymentScheduleForm : Form
    {
        private PaymentScheduleService _service;
        public PaymentScheduleForm()
        {
            InitializeComponent();

            var db = new Database();
            var repo = new PaymentScheduleRepository(db);
            _service = new PaymentScheduleService(repo);
            dgvSchedule.AutoGenerateColumns = true;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.ReadOnly = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = new PaymentScheduleFilter
                {
                    FromDate = dtFrom.Value.Date,
                    ToDate = dtTo.Value.Date,
                    CID = txtCID.Text.Trim(),
                    LC = txtLC.Text.Trim()
                };
                
                var result = _service.GetFilteredSchedules(filter);

                dgvSchedule.DataSource = result;

                if (result.Count == 0)
                    MessageBox.Show("No records found.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }
    }
}
