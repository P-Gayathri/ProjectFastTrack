﻿using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using HidLibrary;
using ClientcardFT3;



namespace ClientcardFB3
{
    public partial class FastTrackForm : Form
    {
        TrxLog clsFT;
        DateTime curSvcDisplayDate;
        LoginForm frmLogIn;



        //SerialPort portScale;
        //Boolean scaleActive = false;
        //string portName = "";
        //int portBaudRate = 9600;
        Parity portParity = (Parity)Enum.Parse(typeof(Parity), "None");
        //int portDataBits = 8;
        StopBits portStopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
        Handshake portHandshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
        int refreshTimeLeft = 30;
        int refreshTimeStart = 30;

        const int defaultScaleRefreshTime = 10;                     //Timer for Automated scale feature <7-27-2014>
        int scaleTimerCurrentValue= defaultScaleRefreshTime;                            //Timer for Automated scale feature <7-27-2014>

        bool timerEnabled = true;
  

        //int rowIndex = 0;
        enum ftcolumns
        { ID, Name, FamilySize, FoodList, ActualsLbs, TEFAPLbs, BabyLbs, SupplLbs }

        public FastTrackForm(LoginForm loginform)
        {
            InitializeComponent();
            curSvcDisplayDate = DateTime.Today;
            PrefsChanged();
            //refreshTimeStart = refreshTimeLeft = CCFBPrefs.ServiceLogRefreshRate;

            frmLogIn = loginform;
            lblFBName.Text = CCFBPrefs.FoodBankName;
            clsFT = new TrxLog(CCFBGlobal.connectionString, false, true, false, false);

            dgvFT.Columns["colBabySvcs"].Visible = CCFBPrefs.EnableBabyServices;
            dgvFT.Columns["colLbsBaby"].Visible = CCFBPrefs.EnableBabyServices;
            dgvFT.Columns["colLbsTEFAP"].Visible = CCFBPrefs.EnableTEFAP;
            dgvFT.Columns["colLbsSuppl"].Visible = CCFBPrefs.EnableSupplemental;

            enableScaleFeature.Visible = ScaleTimer.Enabled = ScaleTimerLabel.Visible=BtnEnableDisableTimer.Visible = tbScaleWt.Visible = btnRefresh.Visible = CCFBPrefs.EnableFTscale;                   //Automated scale feature <7-27-2014>
           
            fillForm();
            StartTimer();

            enableScale.Enabled = false;
            //tbTotBabyDL.Visible = false;
        }

        private void fillForm()
        {
            tssStatus.Text = "Loading";
            tsslblMsg.Text = "";
            Application.DoEvents();
            string val = "";
            clsFT.openForADate(curSvcDisplayDate, "");
            int totEntries = 0;
            int totStdLbs = 0;
            int totOtherLbs = 0;
            int totTEFAP = 0;
            int totSuppl = 0;
            int totBaby = 0;

            int infants = 0;
            int yth = 0;
            int teens = 0;
            int eighteen = 0;
            int adlt = 0;
            int senr = 0;
            int totFam = 0;
            dgvFT.Rows.Clear();

            DataGridViewRow dvr;
            int rowCount = 0;
            for (int i = 0; i < clsFT.RowCount; i++)
            {
                try
                {
                    clsFT.setDataRow(i);
                    infants = clsFT.Infants;
                    yth = clsFT.Youth;
                    teens = clsFT.Teens;
                    eighteen = clsFT.Eighteen;
                    adlt = clsFT.Adults;
                    senr = clsFT.Seniors;
                    totFam = clsFT.TotalFamily;
                    totStdLbs = clsFT.LbsStd;
                    totOtherLbs = clsFT.LbsOther;
                    totTEFAP = clsFT.LbsCommodity;
                    totSuppl = clsFT.LbsSupplemental;
                    totBaby = clsFT.LbsBabySvc;
                    totEntries++;

                    //Grid View
                    dgvFT.Rows.Add();
                    dvr = dgvFT.Rows[rowCount];
                    dvr.Tag = clsFT.TrxId;

                    string tmp;

                    foreach (DataGridViewColumn dgvCol in dgvFT.Columns)
                    {
                        if (dgvCol.DataPropertyName != null && dgvCol.DataPropertyName != "")
                        {
                            tmp = "";
                            switch (dgvCol.CellType.Name)
                            {
                                case "DataGridViewTextBoxCell":
                                    switch (dgvCol.DataPropertyName.ToLower())
                                    {
                                        case "familysize":
                                            if (clsFT.Infants > 0)
                                            {
                                                if (clsFT.Infants == 1)
                                                    val = "1 infant";
                                                else
                                                    val = clsFT.Infants.ToString() + " infants";
                                                CCFBGlobal.AppendTextWithComma(ref tmp, val);
                                            }
                                            if (clsFT.Youth > 0)
                                            {
                                                if (clsFT.Youth == 1)
                                                    val = "1 child";
                                                else
                                                    val = clsFT.Youth.ToString() + " children";
                                                CCFBGlobal.AppendTextWithComma(ref tmp, val);
                                            }
                                            if (clsFT.Teens + clsFT.Eighteen > 0)
                                            {
                                                if (clsFT.Teens + clsFT.Eighteen == 1)
                                                    val = " 1 teen";
                                                else
                                                    val = (clsFT.Teens + clsFT.Eighteen).ToString() + " teens";
                                                CCFBGlobal.AppendTextWithComma(ref tmp, val);
                                            }
                                            if (clsFT.Adults > 0)
                                            {
                                                if (clsFT.Adults == 1)
                                                    val = "1 adult";
                                                else
                                                    val = clsFT.Adults.ToString() + " adults";
                                                CCFBGlobal.AppendTextWithComma(ref tmp, val);
                                            }
                                            if (clsFT.Seniors > 0)
                                            {
                                                if (clsFT.Seniors == 1)
                                                    val = "1 senior";
                                                else
                                                    val = clsFT.Seniors.ToString() + " seniors";
                                                CCFBGlobal.AppendTextWithComma(ref tmp, val);
                                            }
                                            tmp = tmp.Replace(",", "\r\n");
                                            break;
                                        case "foodsvclist":
                                            tmp = clsFT.FoodSvcList.Replace(",", "\r\n");
                                            break;
                                        default:
                                            dvr.Cells[dgvCol.HeaderCell.ColumnIndex].Value = clsFT.GetDataString(dgvCol.DataPropertyName);
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            if (tmp != "")
                                dvr.Cells[dgvCol.HeaderCell.ColumnIndex].Value = tmp;
                        }
                        dvr.Cells[dgvCol.HeaderCell.ColumnIndex].Style.ForeColor = Color.Black;
                    }

                    rowCount++;
                }
                catch (Exception ex)
                {
                    CCFBGlobal.appendErrorToErrorReport("", ex.GetBaseException().ToString());
                }
                if (rowCount > 0)
                {
                    dgvFT.CurrentCell = dgvFT[dgvFT.Columns["colLbsStd"].Index, 0];
                    dgvFT.Focus();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            refreshTimeLeft--;
            tssStatus.Text = refreshTimeLeft.ToString();
            Application.DoEvents();
            if (refreshTimeLeft <= 0)
            {
                timer.Stop();
                fillForm();
                StartTimer();
            }
        }

        public void PrefsChanged()
        {
            //leftForTextBox = tbTotCmDL.Left;
            //EnablelvwColumn(CCFBPrefs.EnableTEFAP, lvDailyLog.Columns[11], tbTotCmDL);                      //"dlCommodity"
            //EnablelvwColumn(CCFBPrefs.EnableSupplemental, lvDailyLog.Columns[12], tbTotSuplDL);             //"dlSuppl"
            //EnablelvwColumn(CCFBPrefs.EnableBabyServices, lvDailyLog.Columns[13]);             //"dlBabySvcLbs"
        }

        private void EnablelvwColumn(bool isEnabled, ColumnHeader colHdr)
        {
            if (isEnabled == false)
                colHdr.Width = 0;
            else
            {
                colHdr.Width = 45;
            }
        }

        private void FastTrackForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogIn.Close();
        }

        private void StartTimer()
        {

            refreshTimeLeft = refreshTimeStart;
            tssStatus.Text = refreshTimeLeft.ToString();
            tssStatus.BackColor = Color.LightGreen;
            timer.Start();

        }

        private void dgvFT_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            timer.Stop();
            tssStatus.BackColor = Color.Khaki;
            tssStatus.Text = "EDITING";
            //btnRefresh.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initScalePort();
            StartScaleTimer();
            timerEnabled = true;
            BtnEnableDisableTimer.Text = "Disable Timer";
            ScaleTimerLabel.BackColor = Color.PaleGreen;

        }

        private void dgvFT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvFT.ColumnCount - 1)
            {
                DataGridViewRow dgvr = dgvFT.CurrentRow;
                clsFT.saveFastTrack(dgvr.Tag.ToString(), dgvr.Cells["colLbsStd"].Value.ToString()
                                                       , dgvr.Cells["colLbsOther"].Value.ToString()
                                                       , dgvr.Cells["colLbsTEFAP"].Value.ToString()
                                                       , dgvr.Cells["colLbsSuppl"].Value.ToString()
                                                       , dgvr.Cells["colLbsBaby"].Value.ToString());
                fillForm();
                StartTimer();
            }
        }

        private void dgvFT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tsslblMsg.Text = "";
            int testTrxId = Convert.ToInt32(dgvFT.Rows[e.RowIndex].Tag.ToString());
            if (testTrxId != clsFT.TrxId)
            {
                clsFT.find(testTrxId);
            }
            DataGridViewCellStyle dgvCellStyle = dgvFT[e.ColumnIndex, e.RowIndex].Style;
            if (dgvFT[e.ColumnIndex, e.RowIndex].Value != clsFT.GetDataValue(dgvFT.Columns[e.ColumnIndex].DataPropertyName))
            {
                try
                {
                    Convert.ToInt32(dgvFT[e.ColumnIndex, e.RowIndex].Value);
                    dgvCellStyle.ForeColor = Color.Maroon;
                }
                catch
                {
                    dgvFT[e.ColumnIndex, e.RowIndex].Value = clsFT.GetDataValue(dgvFT.Columns[e.ColumnIndex].DataPropertyName);
                    Microsoft.VisualBasic.Interaction.Beep();
                    dgvCellStyle.ForeColor = Color.Magenta;
                    tsslblMsg.Text = "Invalid number entered";
                }

            }
            else
            {
                dgvCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgvFT_KeyDown(object sender, KeyEventArgs e)
        {
            CCFBGlobal.checkForIntOnKeyPress(e);
        }

        private void FastTrackForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvFT.Focused == true)
                CCFBGlobal.checkForIntOnKeyPress(e);
        }

        private void initScalePort()
        {
            decimal? weight;
            bool? isStable;

            USBScale s = new USBScale();
            s.Connect();

            if (s.IsConnected)
            {
                s.GetWeight(out weight, out isStable);
                s.Disconnect();
                tbScaleWt.Text = Convert.ToString(weight);
            }
            else
            {

                tbScaleWt.Text = "0.0";

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void FastTrackForm_Load(object sender, EventArgs e)
        {

        }

        private void tbScaleWt_TextChanged(object sender, EventArgs e)
        {
        }
        private void BtnEnableDisableTimer_Click(object sender, EventArgs e)        //Automated Scale feature
        {
            if (timerEnabled)
            {
                timerEnabled = false;
                BtnEnableDisableTimer.Text = "Enable Timer";
                ScaleTimer.Stop();
                ScaleTimerLabel.Text = "Timer Disabled";
                ScaleTimerLabel.BackColor = Color.Azure;
            }
            else
            {
                StartScaleTimer();
                timerEnabled = true;
                BtnEnableDisableTimer.Text = "Disable Timer";
                ScaleTimerLabel.BackColor = Color.PaleGreen;
            }
        }

        private void StartScaleTimer()
        {
            initScalePort();
            scaleTimerCurrentValue = defaultScaleRefreshTime;
            ScaleTimerLabel.Text = scaleTimerCurrentValue.ToString();
            ScaleTimer.Start();
        }

        private void ScaleTimer_Tick(object sender, EventArgs e)
        {
            scaleTimerCurrentValue--;
            ScaleTimerLabel.Text = scaleTimerCurrentValue.ToString();
            if (scaleTimerCurrentValue <= 0)
            {
                ScaleTimer.Stop();
                StartScaleTimer();
            }
        }                                                                                       // Automated Scale feature

        private void dgvFT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)   //Automated Scale feature
        {


        }

        private void enableScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enableScaleToolStripMenuItem1_Click(object sender, EventArgs e)                //Automated Scale feature
        {
            initScalePort();
            btnRefresh.Visible = true;
            tbScaleWt.Visible = true;
            ScaleTimer.Enabled = true;
            ScaleTimerLabel.Visible = true;
            BtnEnableDisableTimer.Visible = true;

            enableScale.Enabled = false;
            disableScale.Enabled = true;
        }
        private void disableScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRefresh.Visible = false;
            tbScaleWt.Visible = false;
            ScaleTimer.Enabled = false;
            ScaleTimerLabel.Visible = false;
            BtnEnableDisableTimer.Visible = false;

            enableScale.Enabled = true;
            disableScale.Enabled = false;
        }

        private void dgvFT_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < dgvFT.ColumnCount - 1 && e.ColumnIndex > dgvFT.ColumnCount - 7)
            {
                DataGridViewRow dgvr = dgvFT.CurrentRow;
                float weightReading = float.Parse(tbScaleWt.Text);
                dgvr.Cells[e.ColumnIndex].Value = (int)Math.Round(weightReading);
            }
        }
    }
}                                                                                       




