using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace AwgTestFramework
{
    public partial class dutui : Form
    {
        public dutui()
        {
            InitializeComponent();

            PopulateSettingsPath();

            /* Check if MySettings.XML file is present, right at the beginning. If it is not present load default values in DUT UI Dialog*/

            check_if_xmlvalue_isset();

            if (xml_value_set == true)
            {
                /*If MySettings.XML file is present then populate the DUT UI Dialog with the values present in XML file*/

                PCAppConfig.Checked = Convert.ToBoolean(deserdata[0].pc_pbu_state);

                PBUApp.Checked = !Convert.ToBoolean(deserdata[0].pc_pbu_state);

                //Sharmila - 01/04/2015
                //Get the state of SourceXpress radio button by deserializing the MySettings.xml
                SourceXpress.Checked = Convert.ToBoolean(deserdata[0].sx_state);

                /*If PC App is in checked state then disable all the controls for AWG Settings as the IP Address is fixed */
                if (PCAppConfig.Checked == true)
                {

                    pc_pbu_state = true;

                    groupBox1.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;
                    groupBox5.Enabled = false;

                }

                DUT1_IP.Checked = Convert.ToBoolean(deserdata[0].ADD_IP_NAME);
                DUT2_IP.Checked = Convert.ToBoolean(deserdata[1].ADD_IP_NAME);
                DUT3_IP.Checked = Convert.ToBoolean(deserdata[2].ADD_IP_NAME);
                DUT4_IP.Checked = Convert.ToBoolean(deserdata[3].ADD_IP_NAME);

                DUT1_Name.Checked = !Convert.ToBoolean(deserdata[0].ADD_IP_NAME);
                DUT2_Name.Checked = !Convert.ToBoolean(deserdata[1].ADD_IP_NAME);
                DUT3_Name.Checked = !Convert.ToBoolean(deserdata[2].ADD_IP_NAME);
                DUT4_Name.Checked = !Convert.ToBoolean(deserdata[3].ADD_IP_NAME);

                SCOPE_IP.Checked = Convert.ToBoolean(deserdata[0].SCOPE_IP_NAME);
                SCOPE_NAME.Checked = !Convert.ToBoolean(deserdata[0].SCOPE_IP_NAME);

                EXTSOURCE_IP.Checked = Convert.ToBoolean(deserdata[0].EXTSRC_IP_NAME);
                EXTSOURCE_NAME.Checked = !Convert.ToBoolean(deserdata[0].EXTSRC_IP_NAME);

                checkBox1controller.Checked = Convert.ToBoolean(deserdata[0].AWGController);
                //Sharmila - 01/04/2015
                //Get the status as to whether the controller checkbox was enabled or disabled by deserializing the MySettings.xml
                checkBox1controller.Enabled = Convert.ToBoolean(deserdata[0].IsAWGControllerEnabled);

                if (checkBox1controller.Checked == true)
                {
                    awg_controller_selected();
                }

                else if (DUT1_IP.Checked == true)
                {

                    dut1_ip_selected();

                }

                else if (DUT1_Name.Checked == true)
                {
                    dut1_name_selected();

                }
                if (DUT2_IP.Checked == true)
                {
                    dut2_ip_selected();


                }
                else if (DUT2_Name.Checked == true)
                {
                    dut2_name_selected();

                }
                if (DUT3_IP.Checked == true)
                {
                    dut3_ip_selected();
                }
                else if (DUT3_Name.Checked == true)
                {

                    dut3_name_selected();
                }

                if (DUT4_IP.Checked == true)
                {

                    dut4_ip_selected();
                }
                else if (DUT4_Name.Checked == true)
                {
                    dut4_name_selected();
                }

                if (SCOPE_IP.Checked)
                {
                    scope_ip_selected();
                }
                else if (SCOPE_NAME.Checked)
                {
                    scope_name_selected();
                }


                if (EXTSOURCE_IP.Checked)
                {
                    extsource_ip_selected();
                }
                else if (EXTSOURCE_NAME.Checked)
                {
                    extsource_name_selected();
                }

                dut1ip.Text = deserdata[0].DUTIP;
                dut2ip.Text = deserdata[1].DUTIP;
                dut3ip.Text = deserdata[2].DUTIP;
                dut4ip.Text = deserdata[3].DUTIP;

                dut1name.Text = deserdata[0].DutName;
                dut2name.Text = deserdata[1].DutName;
                dut3name.Text = deserdata[2].DutName;
                dut4name.Text = deserdata[3].DutName;

                scopename.Text = deserdata[0].ScopeName;

                scopeip.Text = deserdata[0].ScopeIP;

                scopecontype.Text = deserdata[0].ScopeConnType;

                extsourcename.Text = deserdata[0].ExtSourceName;

                extsourceip.Text = deserdata[0].ExtSourceIP;

                extsourcecontype.Text = deserdata[0].ExtSourceConnType;

                awg1contype.Text = deserdata[0].AwgConnType;
                awg2contype.Text = deserdata[1].AwgConnType;
                awg3contype.Text = deserdata[2].AwgConnType;
                awg4contype.Text = deserdata[3].AwgConnType;

                timer1.Enabled = true;
            }

        }


        public MySettings settings1 = new MySettings();
        public MySettings settings2 = new MySettings();
        public MySettings settings3 = new MySettings();
        public MySettings settings4 = new MySettings();


        public string path = "C:\\MySettings.xml";
        public String time_value;

        public List<MySettings> deserdata;
        public List<MySettings> settingsdeserialize;
        public List<MySettings> ndutsettings;
        /// <summary>
        /// Reflects the state change caused by "clicking"<para>
        /// the "PC App" or the "PBU App".  If true then</para><para>
        /// "PC App" was checked or false when the "PBU App"</para><para>
        /// was checked.</para>
        /// </summary>
        public static bool pc_pbu_state;
        //Sharmila - 01/04/2015
        //The status of SourceXpress radio button
        public static bool sx_state;

        public static bool dut1_ip_name_address_selected = false;
        public static bool dut2_ip_name_address_selected = false;
        public static bool dut3_ip_name_address_selected = false;
        public static bool dut4_ip_name_address_selected = false;
        public static bool scope_ip_address_name_selected = false;
        public static bool extsource_ip_address_name_selected = false;
        public static bool dut1ipvalue;
        public static bool xml_value_set = false;
        public static bool AWG1Controller_set = false;
        public static bool IgnoreUI = false;

        public static bool test_cancelled = false;

        /// <summary>
        /// Gets the enviromental variable for the current user and puts the MySettings.xml file in My Documents.
        /// </summary>
        private void PopulateSettingsPath()
        {
            string currentUserFile = Environment.GetEnvironmentVariable("USERPROFILE");
            currentUserFile = currentUserFile + "\\My Documents\\MySettings.xml";
            path = currentUserFile;
        }

        private void writetofile_Click(object sender, EventArgs e)
        {

            serialize_deserialize();

        }

        //Function to serialize the user data to XML File


        public static void SerializeToXML(List<MySettings> ndutsettings, String path)
        {
            XmlSerializer serializer = new XmlSerializer(ndutsettings.GetType());

            StreamWriter textWriter = new StreamWriter(path);

            serializer.Serialize(textWriter, ndutsettings);

            textWriter.Close();

        }

        //Function to deserialize the data from XML File


        public static List<MySettings> DeserializeFromXML(List<MySettings> settingsdeserialize, String path)
        {


            XmlSerializer deserializer = new XmlSerializer(typeof(List<MySettings>));

            TextReader textReader = new StreamReader(path);

            settingsdeserialize = (List<MySettings>)deserializer.Deserialize(textReader);

            textReader.Close();

            int value = settingsdeserialize.Count;

            return settingsdeserialize;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (timeout.Text != null)
                {
                    int time_value = Convert.ToInt32(timeout.Text);

                    if (time_value != 0)
                    {

                        time_value--;

                        timeout.Text = Convert.ToString(time_value);
                    }

                    else
                    {

                        serialize_deserialize();

                    }
                }
                else
                {
                    MessageBox.Show("Invalid Time out value");
                }
            }
            catch (Exception excep)
            {
                Debug.WriteLine(excep.Message);
                timeout.Text = "1";
            }

        }

        private void PCAppConfig_Click(object sender, EventArgs e)
        {
            pc_pbu_state = true;

            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            MessageBox.Show("The IP Adress selected will be 127.0.0.1");

        }

        private void PBUApp_Click(object sender, EventArgs e)
        {

            pc_pbu_state = false;

            if (!checkBox1controller.Enabled)
            {
                checkBox1controller.Enabled = true;
            }
            if (checkBox1controller.Checked)
            {
                awg1contype.Enabled = false;
                DUT1_IP.Enabled = false;
                DUT1_Name.Enabled = false;
                dut1ip.Enabled = false;
                dut1name.Enabled = false;
            }
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
        }

        private void DUT1_IP_Click(object sender, EventArgs e)
        {
            dut1_ip_selected();
        }

        private void DUT1_Name_Click(object sender, EventArgs e)
        {
            dut1_name_selected();
        }

        private void DUT2_IP_Click(object sender, EventArgs e)
        {
            dut2_ip_selected();
        }

        private void DUT2_Name_Click(object sender, EventArgs e)
        {
            dut2_name_selected();
        }

        private void DUT3_IP_Click(object sender, EventArgs e)
        {
            dut3_ip_selected();
        }

        private void DUT3_Name_Click(object sender, EventArgs e)
        {
            dut3_name_selected();
        }

        private void DUT4_IP_Click(object sender, EventArgs e)
        {
            dut4_ip_selected();
        }

        private void DUT4_Name_Click(object sender, EventArgs e)
        {
            dut4_name_selected();
        }

        public void ReadSettings()
        {
            List<MySettings> settingsdeserialize = new List<MySettings> { settings1, settings2, settings3, settings4 };

            deserdata = DeserializeFromXML(settingsdeserialize, path);

        }

        private void SCOPE_IP_CheckedChanged(object sender, EventArgs e)
        {
            scope_ip_selected();
        }

        private void SCOPE_NAME_CheckedChanged(object sender, EventArgs e)
        {

            scope_name_selected();
        }

        private void EXTSOURCE_IP_CheckedChanged(object sender, EventArgs e)
        {
            extsource_ip_selected();
        }

        private void EXTSOURCE_NAME_CheckedChanged(object sender, EventArgs e)
        {
            extsource_name_selected();
        }

        public void check_if_xmlvalue_isset()
        {
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                loaddefaultvalues();
            }
            else
            {
                ReadSettings();
                xml_value_set = true;
            }
        }

        public void loaddefaultvalues()
        {
            scopecontype.SelectedIndex = 0;
            awg1contype.SelectedIndex = 0;
            awg2contype.SelectedIndex = 0;
            awg3contype.SelectedIndex = 0;
            awg4contype.SelectedIndex = 0;
            timer1.Enabled = true;
            PBUApp.Checked = true;
            DUT1_Name.Checked = true;
            DUT2_Name.Checked = true;
            DUT3_Name.Checked = true;
            DUT4_Name.Checked = true;
            dut1name.SelectedIndex = 0;
            dut2name.SelectedIndex = 1;
            dut3name.SelectedIndex = 2;
            dut4name.SelectedIndex = 3;
            dut1ip.Enabled = false;
            dut2ip.Enabled = false;
            dut3ip.Enabled = false;
            dut4ip.Enabled = false;

            SCOPE_NAME.Checked = true;
            scopename.SelectedIndex = 0;

            EXTSOURCE_NAME.Checked = true;
            scopename.SelectedIndex = 0;
            checkBox1controller.Checked = false;

        }

        public void serialize_deserialize()
        {
            settings1.DUTIP = dut1ip.Text;
            settings1.AwgConnType = awg1contype.Text;
            settings1.DutName = dut1name.Text;
            settings1.ADD_IP_NAME = dut1_ip_name_address_selected;

            settings2.DUTIP = dut2ip.Text;
            settings2.AwgConnType = awg2contype.Text;
            settings2.DutName = dut2name.Text;
            settings2.ADD_IP_NAME = dut2_ip_name_address_selected;

            settings3.DUTIP = dut3ip.Text;
            settings3.AwgConnType = awg3contype.Text;
            settings3.DutName = dut3name.Text;
            settings3.ADD_IP_NAME = dut3_ip_name_address_selected;

            settings4.DUTIP = dut4ip.Text;
            settings4.AwgConnType = awg4contype.Text;
            settings4.DutName = dut4name.Text;
            settings4.ADD_IP_NAME = dut4_ip_name_address_selected;

            settings1.AWGController = checkBox1controller.Checked;
            //Sharmila - 01/04/2015
            //Serialize the status of SourceXpress radio button and the Controller checkbox enabled/disabled status
            settings1.sx_state = SourceXpress.Checked;
            if (sx_state)
                checkBox1controller.Enabled = false;
            settings1.IsAWGControllerEnabled = checkBox1controller.Enabled;

            settings1.ScopeConnType = scopecontype.Text;
            settings1.ScopeIP = scopeip.Text;
            settings1.ScopeName = scopename.Text;
            settings1.SCOPE_IP_NAME = scope_ip_address_name_selected;

            settings1.ExtSourceConnType = extsourcecontype.Text;
            settings1.ExtSourceIP = extsourceip.Text;
            settings1.ExtSourceName = extsourcename.Text;
            settings1.EXTSRC_IP_NAME = extsource_ip_address_name_selected;

            List<MySettings> ndutsettings = new List<MySettings> { settings1, settings2, settings3, settings4 };

            SerializeToXML(ndutsettings, path);

            dutui form1 = new dutui();

            List<MySettings> settingsdeserialize = new List<MySettings> { settings1, settings2, settings3, settings4 };

            deserdata = DeserializeFromXML(settingsdeserialize, path);

            if (!pc_pbu_state && AWG1Controller_set)
            {
                IgnoreUI = PIOnly.Checked;
            }

            // this.Close();

            Application.Exit();

        }

        public void dut1_ip_selected()
        {
            dut1name.Enabled = false;
            dut1ip.Enabled = true;
            dut1_ip_name_address_selected = true;
        }

        public void dut1_name_selected()
        {
            dut1name.Enabled = true;
            dut1ip.Enabled = false;
            dut1_ip_name_address_selected = false;
        }

        public void dut2_ip_selected()
        {
            dut2name.Enabled = false;
            dut2ip.Enabled = true;
            dut2_ip_name_address_selected = true;
        }

        public void dut2_name_selected()
        {
            dut2name.Enabled = true;
            dut2ip.Enabled = false;
            dut2_ip_name_address_selected = false;
        }

        public void dut3_ip_selected()
        {
            dut3name.Enabled = false;
            dut3ip.Enabled = true;
            dut3_ip_name_address_selected = true;
        }


        public void dut3_name_selected()
        {
            dut3name.Enabled = true;
            dut3ip.Enabled = false;
            dut3_ip_name_address_selected = false;
        }

        public void dut4_ip_selected()
        {
            dut4name.Enabled = false;
            dut4ip.Enabled = true;
            dut4_ip_name_address_selected = true;
        }

        public void dut4_name_selected()
        {
            dut4name.Enabled = true;
            dut4ip.Enabled = false;
            dut4_ip_name_address_selected = false;
        }

        public void extsource_name_selected()
        {
            extsourcename.Enabled = true;
            extsourceip.Enabled = false;
            extsource_ip_address_name_selected = false;
        }

        public void extsource_ip_selected()
        {
            extsourcename.Enabled = false;
            extsourceip.Enabled = true;
            extsource_ip_address_name_selected = true;
        }

        public void scope_name_selected()
        {
            scopename.Enabled = true;
            scopeip.Enabled = false;
            scope_ip_address_name_selected = false;
        }

        public void scope_ip_selected()
        {
            scopename.Enabled = false;
            scopeip.Enabled = true;
            scope_ip_address_name_selected = true;
        }

        private void checkBox1controller_Click(object sender, EventArgs e)
        {
            awg_controller_selected();
        }

        public void awg_controller_selected()
        {
            if (checkBox1controller.Checked == true)
            {
                dut1name.Enabled = false;
                dut1ip.Enabled = false;
                // dut1_ip_name_address_selected = false;
                awg1contype.Enabled = false;
                DUT1_IP.Enabled = false;
                DUT1_Name.Enabled = false;
                AWG1Controller_set = true;
            }
            else
            {
                if (dut1_ip_name_address_selected == true)
                {
                    dut1ip.Enabled = true;
                }
                else
                {
                    dut1name.Enabled = true;
                }
                // dut1_ip_name_address_selected = false;
                awg1contype.Enabled = true;
                DUT1_IP.Enabled = true;
                DUT1_Name.Enabled = true;
                AWG1Controller_set = false;
            }
        }

        //Sharmila - 01/04/2015
        //This method gets executed when we click the SourceXpress radio button
        //If Controller 1 was checked, then all the AWG 1 controls would have been disabled. So enable them first and then disabled the Controller checkbox
        private void SourceXpress_Click(object sender, EventArgs e)
        {
            sx_state = true;
            if (checkBox1controller.Checked)
            {
                //Enable all the AWG 1 controls
                awg1contype.Enabled = true;
                DUT1_IP.Enabled = true;
                DUT1_Name.Enabled = true;
                if (DUT1_IP.Checked)
                    dut1ip.Enabled = true;
                else
                    dut1name.Enabled = true;
            }
            checkBox1controller.Enabled = false;
            pc_pbu_state = false;
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
        }

    }

}
