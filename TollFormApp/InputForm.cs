using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace TollFormApp
{
    public partial class InputForm : Form
    {
        private string welcomeMessage;
        private string welcomeName;
        private int login_id; //private int login_id;
        private List<string[]> allRoads = new List<string[]>();
        private List<string[]> driverRoads = new List<string[]>();
        private string insertMessage;
        private string startDate;
        private string endDate;

        public InputForm(int driver_id = 1001)
        {
            this.login_id = driver_id;
            InitializeComponent();
            exitButton.Click += new System.EventHandler(exitButton_Click);
            enterFormButton.Click += new System.EventHandler(enterFormButton_Click);
            resetButton.Click += new System.EventHandler(InputForm_Load);
            roadComboBox.SelectedIndexChanged += new System.EventHandler(roadComboBox_SelectedIndexChanged);
            submitButton.Click += new System.EventHandler(submitButton_Click);
        }

        Label welcomeLabel = new Label();
        Label startDateLabel = new Label();
        Label endDateLabel = new Label();
        Label tollDateLabel = new Label();
        Label tollAmountLabel = new Label();

        MaskedTextBox startDateMaskedTextBox = new MaskedTextBox();
        MaskedTextBox endDateMaskedTextBox = new MaskedTextBox();
        MaskedTextBox tollDateMaskedTextBox = new MaskedTextBox();

        CheckBox roadCheckBox = new CheckBox();
        CheckedListBox roadCheckedListBox = new CheckedListBox();
        RadioButton enterTollRadioButton = new RadioButton();
        RadioButton viewTollRadioButton = new RadioButton();
        RadioButton mfRadioButton = new RadioButton();
        RadioButton ssRadioButton = new RadioButton();
        RadioButton allDaysRadioButton = new RadioButton();
        Button enterFormButton = new Button();
        Button backLoginButton = new Button();
        Button resetButton = new Button();
        Button exitButton = new Button();
        Button submitButton = new Button();
        Button viewButton = new Button();
        ComboBox roadComboBox = new ComboBox();
        GroupBox inputTypeGroupBox = new GroupBox();
        GroupBox dateGroupBox = new GroupBox();
        GroupBox payDateGroupBox = new GroupBox();
        GroupBox weekdayGroupBox = new GroupBox();
        GroupBox roadViewGroupBox = new GroupBox();
        GroupBox roadInputGroupBox = new GroupBox();
        GroupBox processGroupBox = new GroupBox();
        ToolTip objectToolTip = new ToolTip();
        ErrorProvider formErrorProvider = new ErrorProvider();

        private void roadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roadComboBox.SelectedIndex == -1)
            {
                tollAmountLabel.Text = null;
            }
            else
            {
                int itemNum = roadComboBox.SelectedIndex;
                string cost = allRoads[itemNum][1];
                insertMessage = "You have selected " + roadComboBox.SelectedItem.ToString()
                                + "\nToll cost is $" + cost;
                tollAmountLabel.Text = insertMessage;
                formErrorProvider.SetError(roadComboBox, null);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string submitMsg = null;
            formErrorProvider.Clear();
            try
            {
                DateTime validDate = DateTime.Parse(tollDateMaskedTextBox.Text);
                if (validDate > DateTime.Now)
                {
                    submitMsg = "Error - You cannot enter a future date.\nPlease re enter date";
                    MessageBox.Show(submitMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    formErrorProvider.SetError(tollDateMaskedTextBox, submitMsg);
                }
                else if (validDate <= DateTime.Now.AddDays(-31))
                {
                    submitMsg = "Error - Unfortunately toll payments are allowed for the\n"
                                    + "prior 30 days only.\n"
                                    + "Please call (503) PDX-TOLL to resolve.";
                    MessageBox.Show(submitMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    formErrorProvider.SetError(tollDateMaskedTextBox, submitMsg);
                }
                else if (roadComboBox.SelectedIndex == -1)
                {
                    submitMsg = "Error - Please select a toll road from the dropdown.";
                    MessageBox.Show(submitMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    formErrorProvider.SetError(roadComboBox, submitMsg);
                }
                else
                {
                    int itemNum = roadComboBox.SelectedIndex;
                    submitMsg = welcomeName + ", you about to pay $" + allRoads[itemNum][1] 
                                + "\nfor using " + allRoads[itemNum][0] 
                                + " on " + validDate.ToString("d")
                                + "\n\nPlease click Yes to confirm or No to cancel and go back";
                    DialogResult result = MessageBox.Show(submitMsg
                                                          , "Confirm"
                                                          , MessageBoxButtons.YesNo
                                                          , MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        // not yet implementd to insert into table
                    }
                    else
                    {
                        // do nothing - close pop-up and go back to input form as it was
                    }
                }
            }
            catch
            {
                submitMsg = "Error - Please enter a valid date";
                MessageBox.Show(submitMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formErrorProvider.SetError(tollDateMaskedTextBox, submitMsg);
            }
        }

        // Enter form button, labeled Submit will 
        // first check if radio button is selected
        // then open the corresponding group boxes
        // else show error to user
        private void enterFormButton_Click(object sender, EventArgs e)
        {
            if (enterTollRadioButton.Checked)
            {
                welcomeMessage += "\n\nPlease enter a toll date within the last 30 days and select a road from the dropdown";
                welcomeLabel.Text = welcomeMessage;
                inputTypeGroupBox.Visible = false;
                payDateGroupBox.Visible = true;
                roadInputGroupBox.Visible = true;
                processGroupBox.Visible = true;
                submitButton.Visible = true;
                moveProcessButtons();
            }
            else if (viewTollRadioButton.Checked)
            {
                welcomeMessage += "\nPlease enter a date range and select roads to view tolls";
                welcomeLabel.Text = welcomeMessage;
                inputTypeGroupBox.Visible = false;
                dateGroupBox.Visible = true;
                roadViewGroupBox.Visible = true;
                processGroupBox.Visible = true;
                viewButton.Visible = true;
                moveProcessButtons();
            }
            else
            {
                MessageBox.Show("No selection made.\nPlease click enter tolls or view tolls option"
                                , "Error"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);
            }
        }

        // Move exit button to process group box after selection made
        private void moveProcessButtons()
        {
            exitButton.Parent = processGroupBox;
            exitButton.Location = new System.Drawing.Point(370, 25);
            exitButton.Size = new System.Drawing.Size(100, 30);
            backLoginButton.Parent = processGroupBox;
            backLoginButton.Parent = processGroupBox;
            backLoginButton.Location = new System.Drawing.Point(250, 25);
            backLoginButton.Size = new System.Drawing.Size(100, 30);
        }

        // Exit button will display a message box copied from JAT LoginForm code
        // So user sees consistent close procedure
        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit this program?"
                                                  , "Exiting"
                                                  , MessageBoxButtons.YesNo
                                                  , MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                // do nothing and go back to form
            }
        }

        // Load welcome message with the user's name
        private void loadWelcomeMessage()
        {
            welcomeLabel.Parent = this;
            welcomeLabel.Location = new System.Drawing.Point(10, 10);
            welcomeLabel.Size = new System.Drawing.Size(500, 50);
            welcomeLabel.Name = "welcomeLabel";
            welcomeMessage = "Welcome " + welcomeName + " to your input form!";
            welcomeLabel.Text = welcomeMessage;
        }

        // Load the road input group box
        // And combo box and label
        private void loadRoadInput()
        {
            roadInputGroupBox.Parent = this;
            roadInputGroupBox.Location = new System.Drawing.Point(20, 150);
            roadInputGroupBox.Size = new System.Drawing.Size(250, 150);
            roadInputGroupBox.Name = "roadInputGroupBox";
            roadInputGroupBox.Text = "Select a toll road";
            roadInputGroupBox.Visible = false; // default

            // Setup combo box control
            roadComboBox.Parent = roadInputGroupBox;
            roadComboBox.Location = new System.Drawing.Point(20, 25);
            roadComboBox.Size = new System.Drawing.Size(150, 30);
            roadComboBox.Name = "roadComboBox";
            roadComboBox.Items.Clear();
            roadComboBox.Text = "Select toll road";
            objectToolTip.SetToolTip(roadComboBox, "All toll roads are available for selection. Choose 1 road");

            // Location group and check boxes
            roadViewGroupBox.Parent = this;
            roadViewGroupBox.Location = new System.Drawing.Point(20, 150);
            roadViewGroupBox.Size = new System.Drawing.Size(250, 150);
            roadViewGroupBox.Name = "roadViewGroupBox";
            roadViewGroupBox.Text = "Select a toll road";
            roadViewGroupBox.Visible = false; // default

            roadCheckedListBox.Parent = roadViewGroupBox;
            roadCheckedListBox.Location = new System.Drawing.Point(20, 25);
            roadCheckedListBox.Size = new System.Drawing.Size(200, 100);
            roadCheckedListBox.Name = "roadCheckedListBox";
            roadCheckedListBox.Items.Clear();
            objectToolTip.SetToolTip(roadCheckedListBox, "Toll roads you have taken are displayed. Check 1 or more roads.");
            
            // Fill in combo box and checked list box with all available roads in tolls DB
            // TO DO move this into own method for click changed event
            try
            {
                int allCount = allRoads.Count;
                int driverCount = driverRoads.Count;
                for (int i = 0; i < allCount; i++)
                {
                    roadComboBox.Items.Add(allRoads[i][0].ToString());
                }
                for (int d = 0; d < driverCount; d++)
                {
                    roadCheckedListBox.Items.Add(driverRoads[d][0] + " toll $" + driverRoads[d][1]);
                }

            }
            catch
            {
                MessageBox.Show("Not working");
            }

            tollAmountLabel.Parent = roadInputGroupBox;
            tollAmountLabel.Location = new System.Drawing.Point(20, 110);
            tollAmountLabel.Size = new System.Drawing.Size(150, 30);
            tollAmountLabel.Name = "tollAmountLabel";
            tollAmountLabel.Text = null;
        }

        // Load the process input group box
        // And submit and reset buttons
        private void loadProcessInput()
        {
            processGroupBox.Parent = this;
            processGroupBox.Location = new System.Drawing.Point(20, 320);
            processGroupBox.Size = new System.Drawing.Size(500, 80);
            processGroupBox.Name = "processGroupBox";
            processGroupBox.Text = "Process input";
            processGroupBox.Visible = false; // default view

            submitButton.Parent = processGroupBox;
            submitButton.Location = new System.Drawing.Point(10, 25);
            submitButton.Size = new System.Drawing.Size(100, 30);
            submitButton.Name = "submitButton";
            submitButton.Text = "&Submit";
            submitButton.Visible = false; // default view
            objectToolTip.SetToolTip(submitButton
                                    , "Click to submit toll into your record.");

            viewButton.Parent = processGroupBox;
            viewButton.Location = new System.Drawing.Point(10, 25);
            viewButton.Size = new System.Drawing.Size(100, 30);
            viewButton.Name = "viewButton";
            viewButton.Text = "&View Results";
            viewButton.Visible = false; // default view
            objectToolTip.SetToolTip(viewButton
                                    , "Click to view results in a new window.");

            resetButton.Parent = processGroupBox;
            resetButton.Location = new System.Drawing.Point(130, 25);
            resetButton.Size = new System.Drawing.Size(100, 30);
            resetButton.Name = "resetButton";
            resetButton.Text = "&Reset Input";
            objectToolTip.SetToolTip(resetButton
                                    , "Click to reset and go back to Select input type");


        }
        
        // Load pay toll date group box label and masked text box
        private void loadPayTollDate()
        {
            payDateGroupBox.Parent = this;
            payDateGroupBox.Location = new System.Drawing.Point(20, 60);
            payDateGroupBox.Size = new System.Drawing.Size(250, 60);
            payDateGroupBox.Name = "payDateGroupBox";
            payDateGroupBox.Text = "Pay toll";
            payDateGroupBox.Visible = false; // default does not show

            tollDateLabel.Parent = payDateGroupBox;
            tollDateLabel.Location = new System.Drawing.Point(20, 25);
            tollDateLabel.Size = new System.Drawing.Size(100, 30);
            tollDateLabel.Name = "tollDateLabel";
            tollDateLabel.Text = "Enter toll date";

            tollDateMaskedTextBox.Parent = payDateGroupBox;
            tollDateMaskedTextBox.Location = new System.Drawing.Point(140, 20);
            tollDateMaskedTextBox.Size = new System.Drawing.Size(80, 40);
            tollDateMaskedTextBox.Name = "tollDateMaskedTextBox";
            tollDateMaskedTextBox.Mask = "00/00/0000";
            objectToolTip.SetToolTip(tollDateMaskedTextBox
                                    , "Please enter a date within the last 30 days.\n"
                                    + "For earlier pay dates. Please call (503) PDX-TOLL"
                                    );
        }

        // Load date search group box
        private void loadDateSearch()
        {
            // Date Group box and date labels and masked text boxes
            dateGroupBox.Parent = this;
            dateGroupBox.Location = new System.Drawing.Point(20, 60);
            dateGroupBox.Size = new System.Drawing.Size(500, 60);
            dateGroupBox.Name = "dateGroupBox";
            dateGroupBox.Text = "Select date range";
            dateGroupBox.Visible = false; // default not shown until radio selection is made

            startDateLabel.Parent = dateGroupBox;
            startDateLabel.Location = new System.Drawing.Point(20, 25);
            startDateLabel.Size = new System.Drawing.Size(120, 30);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Text = "Edit your start date";

            startDateMaskedTextBox.Parent = dateGroupBox;
            startDateMaskedTextBox.Location = new System.Drawing.Point(140, 20);
            startDateMaskedTextBox.Size = new System.Drawing.Size(70, 40);
            startDateMaskedTextBox.Name = "startDateMaskedTextBox";
            startDateMaskedTextBox.Mask = "00/00/0000";
            startDateMaskedTextBox.Text = startDate;
            objectToolTip.SetToolTip(startDateMaskedTextBox
                                    , "Default value is earliest toll date.\n"
                                    + "You can edit to a later date.");

            endDateLabel.Parent = dateGroupBox;
            endDateLabel.Location = new System.Drawing.Point(250, 25);
            endDateLabel.Size = new System.Drawing.Size(120, 30);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Text = "Edit your end date";

            endDateMaskedTextBox.Parent = dateGroupBox;
            endDateMaskedTextBox.Location = new System.Drawing.Point(370, 20);
            endDateMaskedTextBox.Size = new System.Drawing.Size(70, 40);
            endDateMaskedTextBox.Name = "endDateMaskedTextBox";
            endDateMaskedTextBox.Mask = "00/00/0000";
            endDateMaskedTextBox.Text = endDate;
            objectToolTip.SetToolTip(endDateMaskedTextBox
                                    , "Default value is latest toll date.\n"
                                    + "You can edit to an earlier date.");
        }

        // Load default or reset view of
        // input type group box
        // and radio buttons for enter toll or view tolls
        // and buttons to submit, go back, or exit
        private void loadInputTypeControls()
        {
            inputTypeGroupBox.Parent = this;
            inputTypeGroupBox.Location = new System.Drawing.Point(20, 60);
            inputTypeGroupBox.Size = new System.Drawing.Size(500, 100);
            inputTypeGroupBox.Name = "inputTypeGroupBox";
            inputTypeGroupBox.Text = "Select input type";
            inputTypeGroupBox.Visible = true;

            enterTollRadioButton.Parent = inputTypeGroupBox;
            enterTollRadioButton.Location = new System.Drawing.Point(20, 25);
            enterTollRadioButton.Size = new System.Drawing.Size(200, 30);
            enterTollRadioButton.Name = "enterTollRadioButton";
            enterTollRadioButton.Text = "Enter a toll payment into the system";
            enterTollRadioButton.Checked = false;
            objectToolTip.SetToolTip(enterTollRadioButton, "Select and click Submit to pay a toll");

            viewTollRadioButton.Parent = inputTypeGroupBox;
            viewTollRadioButton.Location = new System.Drawing.Point(20, 60);
            viewTollRadioButton.Size = new System.Drawing.Size(200, 30);
            viewTollRadioButton.Name = "viewTollRadioButton";
            viewTollRadioButton.Text = "View paid tolls from the system";
            viewTollRadioButton.Checked = false;
            objectToolTip.SetToolTip(viewTollRadioButton, "Select and click Submit to view your paid tolls");

            enterFormButton.Parent = inputTypeGroupBox;
            enterFormButton.Location = new System.Drawing.Point(220, 60);
            enterFormButton.Size = new System.Drawing.Size(85, 25);
            enterFormButton.Name = "enterFormButton";
            enterFormButton.Text = "&Submit";
            objectToolTip.SetToolTip(enterFormButton, "Click to submit and open the rest of the form.");

            backLoginButton.Parent = inputTypeGroupBox;
            backLoginButton.Location = new System.Drawing.Point(310, 60);
            backLoginButton.Size = new System.Drawing.Size(85, 25);
            backLoginButton.Name = "backLoginButton";
            backLoginButton.Text = "&Back to Login";
            objectToolTip.SetToolTip(backLoginButton, "Click to go back to login page");

            exitButton.Parent = inputTypeGroupBox;
            exitButton.Location = new System.Drawing.Point(400, 60);
            exitButton.Size = new System.Drawing.Size(85, 25);
            exitButton.Name = "exitButton";
            exitButton.Text = "&Exit";
            objectToolTip.SetToolTip(exitButton, "Click to close form and exit the program.");
        }

        // Load road view group and checked list box
        private void loadRoadView()
        {

        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            this.Text = "Input Form";
            this.Size = new System.Drawing.Size(600, 600);

            // TO DO need to move this in a method? or ok here?
            var inputClass = new InputClass(login_id); // class accepts a valid driver_id post login as parameter
            welcomeName = inputClass.getDriverName();
            startDate = inputClass.getMinDate().ToString("MM/dd/yyyy");
            endDate = inputClass.getMaxDate().ToString("MM/dd/yyyy");
            allRoads = inputClass.getTollRoads();
            driverRoads = inputClass.getDriverRoads();

            formErrorProvider.Clear();

            loadWelcomeMessage();
            loadInputTypeControls();
            loadProcessInput();
            loadRoadInput();
            loadPayTollDate();
            loadDateSearch();
            //loadRoadView();
            //show dateRangeGroupBox




            // TO DO set icon

 


            //roadCheckedListBox.Items.AddRange(roadItems);
        }
    }
}
