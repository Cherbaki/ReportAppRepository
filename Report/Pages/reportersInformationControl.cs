using Report.Data;
using Report.Models;
using Report.Repositories;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Report.Pages
{
    public partial class reportersInformationControl : UserControl
    {
        private readonly ReporterInformationRepository _reporterInformationRepository;
        private Form1? _mainForm;
        public Form1? MainForm
        {
            get => _mainForm;
            set => _mainForm = value;
        }


        public reportersInformationControl()
        {
            InitializeComponent();
            _reporterInformationRepository = new ReporterInformationRepository();
        }


        private void reportersInformationControl_Load(object sender, EventArgs e)
        {
            //Load Countries data from the JSON to the UI
            LoadCountryStateCityData();

            //Disable all the span elementes
            ReporterSpan.Visible = false;
            NameSpan.Visible = false;
            AddressSpan.Visible = false;
            EmailSpan.Visible = false;
            ReporterTypeSpan.Visible = false;

            //Disable the success notification
            SuccessButton.Visible = false;

            //Check the first country
            CountrySL.SelectedIndex = 0;

            //Fill the reporterType combo box
            FillReporterType();
            //Select The first reporter by default
            ReporterTypeSL.SelectedIndex = 0;
        }
        private void RestoreButton_Click(object sender, EventArgs e)
        {
            MainForm!.setActivePanel(MainForm.RecordsControl);   
        }
        private void CountrySL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                var selectedCountryName = (string)CountrySL.SelectedItem;
                UpdateStateAndCity(selectedCountryName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SubmitBT_Click(object sender, EventArgs e)
        {
            var result = ValidateFormAndDisplaySpan();
            if (!result)
                return;

            string? selectedEnum = null;
            //Selected reporter
            if (HCPradioButton.Checked)
                selectedEnum = HCPradioButton.Text;
            else if (PatientRadioButton.Checked)
                selectedEnum = PatientRadioButton.Text;
            else
                selectedEnum = PatientRadioButton.Text;
            //Selected Country
            var selectedCountry = GetCountriesData()!.Find(co => co.Name == CountrySL.Text);

            //Now create a model
            var reportersInfo = new ReportersInformation()
            {
                Reporter = selectedEnum,
                Name = NameTB.Text,
                ReporterType = ReporterTypeSL.Text,
                Occupation = OccupationTB.Text,
                SpecialityArea = SpecialityAreaTB.Text,
                Address = AddressTB.Text,
                Country = selectedCountry!.Name,
                State = StateSL.Text,
                City = CitySL.Text,
                Pin = PinTB.Text,
                LandlineNo = LandlineNoTB.Text,
                MobileNo = MobileNoTB.Text,
                Email = EmailTB.Text,
                FaxNo = FaxNoTB.Text,
                ReportDate = ReportDateDTP.Value
            };

            _reporterInformationRepository.AddReportersInformation(reportersInfo);

            //Clear the form elements
            ClearFormElements();

            //Show the notification
            SuccessButton.Visible = true;
            var newThread = new Thread(HideSuccessNotification);
            newThread.Start();
        }
            

        public void HideSuccessNotification()
        {
            Thread.Sleep(1000);
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => { SuccessButton.Visible = false; }));
            }
        }
        //Clear all the form controlls
        public void ClearFormElements()
        {
            NameTB.Text = "";
            ReporterTypeSL.SelectedIndex = 0;
            OccupationTB.Text = "";
            SpecialityAreaTB.Text = "";
            AddressTB.Text = "";
            this.CountrySL.SelectedIndexChanged -= new System.EventHandler(this.CountrySL_SelectedIndexChanged!);
            CountrySL.SelectedIndex = 0;
            this.CountrySL.SelectedIndexChanged += new System.EventHandler(this.CountrySL_SelectedIndexChanged!);
            StateSL.SelectedIndex = 0;
            CitySL.SelectedIndex = 0;
            PinTB.Text = "";
            LandlineNoTB.Text = "";
            MobileNoTB.Text = "";
            EmailTB.Text = "";
            FaxNoTB.Text = "";
        }
        //Validate the user input
        public bool ValidateFormAndDisplaySpan()
        {
            var valid = true;

            //Check all reporters radio Button
            bool selected = false;
            if(HCPradioButton.Checked || PatientRadioButton.Checked || OthersRadioButton.Checked)
                selected = true;

            if (!selected)
            {
                //Display span and return failure
                ReporterSpan.Visible = true;
                valid = false;
            }
            else 
                ReporterSpan.Visible = false;
            
            //Check name textBox
            if (NameTB.Text.Length <= 0)
            {
                NameSpan.Visible = true;
                valid = false;
            }
            else
                NameSpan.Visible = false;

            //Validate Reporter Type
            bool reporterTypeValidity = false;
            foreach(var item in GetReporterTypes())
            {
                if (ReporterTypeSL.Text == item) { 
                    reporterTypeValidity = true;
                    break;
                }
            }
            if (!reporterTypeValidity) {
                //Display the reporter type span
                ReporterTypeSpan.Visible = true;
                valid = false;
            }
            else
                ReporterTypeSpan.Visible = false;


            //Check address textBox
            if (AddressTB.Text.Length <= 0)
            {
                AddressSpan.Visible = true;
                valid = false;
            }
            else
                AddressSpan.Visible = false;

            //Check emial textBox
            if (EmailTB.Text.Length <= 0)
            {
                EmailSpan.Visible = true;
                valid = false;
            }
            else
                EmailSpan.Visible = false;



            return valid;
        }
        //This method will Update the StateSL and CitySL UI controls based on the selected country
        public void UpdateStateAndCity(string selectedCountryName)
        {
            //Clear all 3 combo box
            ClearCountryStateCityUI();
            var countries = GetCountriesData();
            if (countries == null)
                return;
            var selectedCountry = countries.Find(co => co.Name == selectedCountryName);

            foreach(var country in countries!)
                    CountrySL.Items.Add(country.Name);

            this.CountrySL.SelectedIndexChanged -= new System.EventHandler(this.CountrySL_SelectedIndexChanged!);
            CountrySL.SelectedItem = selectedCountry!.Name;
            this.CountrySL.SelectedIndexChanged += new System.EventHandler(this.CountrySL_SelectedIndexChanged!);


            //Add All the respective states
            foreach (var state in selectedCountry.States!)
                StateSL.Items.Add(state);
            StateSL.SelectedIndex = 0;
            //Add all the respective cities
            foreach (var city in selectedCountry.Cities!)
                CitySL.Items.Add(city);
            CitySL.SelectedIndex = 0;
        }
        //This method loads countryies data into the UIs combo boxes
        public void LoadCountryStateCityData()
        {
            List<Country>? countries = GetCountriesData();
            if (countries == null)
                return;

            foreach (var country in countries) { 
                CountrySL.Items.Add(country.Name);

                if(country.States != null)
                    foreach (var state in country.States)
                        StateSL.Items.Add(state);

                if(country.Cities != null)
                    foreach (var city in country.Cities)
                        CitySL.Items.Add(city);
            }

        }
        //This method will clear the User Interface Country,State and City combo boxes
        public void ClearCountryStateCityUI()
        {
            CountrySL.Items.Clear();
            StateSL.Items.Clear();
            CitySL.Items.Clear();
        }
        //This method fills the reporter type combo box
        public void FillReporterType()
        {
            foreach (var item in GetReporterTypes())
                ReporterTypeSL.Items.Add(item);
        }
        //Loads and returns country list from the json file
        public List<Country>? GetCountriesData()
        {
            List<Country>? countries = null;
            using (var SR = new StreamReader("CountiresData.json"))
            {
                var json = SR.ReadToEnd();
                countries = JsonSerializer.Deserialize<List<Country>>(json);
            }

            return countries;
        }
        public List<string> GetReporterTypes()
        {
            return new List<string>()
            {
                "ReporterType1","ReporterType2","ReporterType3","ReporterType4","ReporterType5"
            };
        }
    }
}
