using Report.Models;
using Report.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Report.Pages
{
    public partial class recordsControl : UserControl
    {

        private readonly ReporterInformationRepository _reporterInformationRepository;
        public List<ReportersInformation>? ReportersInformation { get; set; }

        public recordsControl()
        {
            InitializeComponent();
            _reporterInformationRepository = new ReporterInformationRepository();
        }

        private void recordsControl_Load(object sender, EventArgs e)
        {
            //Hide the span
            SearchRecordSpan.Visible = false;

            ReportersInformation = _reporterInformationRepository.GetAllReportersInformation();

            //Load the ReportersInformation into the UI
            foreach (var item in ReportersInformation)
                ReportsLB.Items.Add(item.Name);
        }

        private void ReportsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReportsLB.SelectedItem == null)
                return;
            string selectedReportName = ReportsLB.SelectedItem!.ToString()!;
            var selectedReport = ReportersInformation?.FirstOrDefault(sr => sr.Name == selectedReportName);
            if (selectedReport == null) {
                ReportDataTB.Text = "";
                return;
            }
            var data = GetReportDataAsString(selectedReport);
            ReportDataTB.Text = data;
        }

        public string GetReportDataAsString(ReportersInformation reportersInformation)
        {
            return 
                $"""
                Reporter: {reportersInformation.Reporter}
                Name: {reportersInformation.Name}
                Reporter Type: {reportersInformation.ReporterType}
                Occupation: {reportersInformation.Occupation}
                Speciality Area: {reportersInformation.SpecialityArea}
                Address: {reportersInformation.Address}
                Country/State/City: {reportersInformation.Country}/{reportersInformation.State}/{reportersInformation.City}
                Pin: {reportersInformation.Pin}
                Landline No: {reportersInformation.LandlineNo}
                Mobile No: {reportersInformation.MobileNo}
                Email: {reportersInformation.Email}
                Fax No: {reportersInformation.FaxNo}
                Report Date: {reportersInformation.ReportDate}
                """;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var input = SearchRecordTB.Text;
            if (input == null || input == "")
                return;

            var index = ReportsLB.Items.IndexOf(input);

            if (index == -1)
            {
                //In this case report is not found in the list
                SearchRecordSpan.Visible = true;
                return;
            }
            else
                SearchRecordSpan.Visible = false;


            ReportsLB.SelectedIndex = index;
        }
    }
}
