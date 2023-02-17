using Report.Pages;

namespace Report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ReportersInformationControl.Dock = DockStyle.Fill;
            DashboardControl.Dock = DockStyle.Fill;
            RecordsControl.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(this.ReportersInformationControl);
            this.MainPanel.Controls.Add(this.DashboardControl);
            this.MainPanel.Controls.Add(this.RecordsControl);

            this.ReportersInformationControl.MainForm = this;
            setActivePanel(ReportersInformationControl);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void RIButton_Click(object sender, EventArgs e)
        {
            setActivePanel(ReportersInformationControl);
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            setActivePanel(DashboardControl);
        }

        public void setActivePanel(UserControl control)
        {
            //Deactivate all controlls
            ReportersInformationControl.Visible = false;
            DashboardControl.Visible = false;


            //Activate the seleted controll
            control.Visible = true;
        }
    }
}