using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
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

namespace Report.Pages
{
    public partial class dashboardControl : UserControl
    {

        private readonly ReporterInformationRepository _reporterInformationRepository;
        private readonly PlotView _plotView;
        private DataTable? _dataTable;


        public dashboardControl()
        {
            InitializeComponent();

            InitializeMonthsDGVColumns();

            _plotView = new PlotView();
            _plotView.Size = new Size(500, 500); // Set the size of the PlotView

            this.VisibleChanged += new EventHandler(dashboardControl_VisibleChanged!);

            _reporterInformationRepository = new ReporterInformationRepository();
        }


        private void dashboardControl_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == true)
                UpdateUI();
        }


        public void UpdateUI()
        {
            UpdateYearReportsChart();
            UpdateMonthsDGV();
        }
        public void UpdateMonthsDGV()
        {
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var reportInfos = _reporterInformationRepository.GetAllReportersInformation();

            for (int i = 0; i < reportInfos.Count(); i++)
                _dataTable!.Rows.Add();

            for (int c = 0; c < 12; c++)
            {
                //Get target columns(months) items(report)
                var currentColumnItems = reportInfos.Where(ri => ri.ReportDate.Month == months[c]).ToList();
                for(int r = 0; r < currentColumnItems.Count(); r++)
                {
                    var cell = mothsDGV.Rows[r].Cells[c];
                    cell.Value = currentColumnItems[r].Name;
                }
            }

        }
        public void UpdateYearReportsChart()
        {
            var plotModel = new PlotModel();

            var series = new ColumnSeries();

            var reportInfos = _reporterInformationRepository.GetAllReportersInformation();
            reportInfos = reportInfos.OrderBy(ri => ri.ReportDate).ToList();

            var yearsList = new List<string>();
            foreach (var reportInfo in reportInfos)
                yearsList.Add(reportInfo.ReportDate.Year.ToString());

            int counter = 0;
            foreach (var year in yearsList.Distinct())
            {
                series.Items.Add(
                    new ColumnItem { Value = yearsList.Where(yl => yl == year).Count(), CategoryIndex = counter }
                );
                counter++;
            }
            plotModel.Series.Add(series);


            plotModel.Title = "Number of Reports by Year";
            plotModel.Axes.Add(
                new CategoryAxis
                {
                    Position = AxisPosition.Bottom,
                    ItemsSource = yearsList.Distinct()
                });
            plotModel.Axes.Add(
                new LinearAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Number of Reports"
                });

            _plotView.Model = plotModel;

            // For Windows Forms:
            RecordsChartPanel.Controls.Add(_plotView);
        }
        public void InitializeMonthsDGVColumns()
        {
            mothsDGV.ReadOnly = true;

            // create a DataTable with 12 columns for each month of the year
            _dataTable = new DataTable();
            _dataTable.Columns.Add("January", typeof(string));
            _dataTable.Columns.Add("February", typeof(string));
            _dataTable.Columns.Add("March", typeof(string));
            _dataTable.Columns.Add("April", typeof(string));
            _dataTable.Columns.Add("May", typeof(string));
            _dataTable.Columns.Add("June", typeof(string));
            _dataTable.Columns.Add("July", typeof(string));
            _dataTable.Columns.Add("August", typeof(string));
            _dataTable.Columns.Add("September", typeof(string));
            _dataTable.Columns.Add("October", typeof(string));
            _dataTable.Columns.Add("November", typeof(string));
            _dataTable.Columns.Add("December", typeof(string));

            // set the DataTable as the data source for the DataGridView control
            mothsDGV.DataSource = _dataTable;
            // set AutoGenerateColumns to false to use the columns we defined in the DataTable
            mothsDGV.AutoGenerateColumns = false;

            // customize the appearance and behavior of the columns as needed
            mothsDGV.Columns[0].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[1].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[2].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[3].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[4].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[5].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[6].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[7].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[8].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[9].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[10].DefaultCellStyle.Format = "C";
            mothsDGV.Columns[11].DefaultCellStyle.Format = "C";

            mothsDGV.Columns[0].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[1].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[2].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[3].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[4].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[5].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[6].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[7].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[8].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[9].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[10].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            mothsDGV.Columns[11].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);

            mothsDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            mothsDGV.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;


            mothsDGV.AllowUserToAddRows = false;
        }

    }
}
