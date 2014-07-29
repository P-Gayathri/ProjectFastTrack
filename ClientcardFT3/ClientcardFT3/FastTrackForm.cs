using System;
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
        Boolean scaleActive = false;
        //string portName = "";
        //int portBaudRate = 9600;
        Parity portParity = (Parity)Enum.Parse(typeof(Parity), "None");
        //int portDataBits = 8;
        StopBits portStopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
        Handshake portHandshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
        int refreshTimeLeft = 30;
        int refreshTimeStart = 30;
        //int rowIndex = 0;

        bool timerEnabled = false;

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

            initScalePort();
            fillForm();
            StartTimer();
            //tbTotBabyDL.Visible = false;
        }

        private void fillForm()
        {
            tssStatus.Text = "Loading";
            tsslblMsg.Text = "";
            Application.DoEvents();
            string val = "";
            clsFT.openForADate(curSvcDisplayDate,"");
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
                initScalePort();
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
            if (timerEnabled)
            {
                refreshTimeLeft = refreshTimeStart;
                tssStatus.Text = refreshTimeLeft.ToString();
                tssStatus.BackColor = Color.LightGreen;
                btnRefresh.Visible = true;
                timer.Start();
            }
            else
            {
                tssStatus.BackColor = Color.LightGray;
                tssStatus.Text = "Timer Disabled";
            }
        }

        private void dgvFT_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            timer.Stop();
            tssStatus.BackColor = Color.Khaki;
            tssStatus.Text ="EDITING";
            btnRefresh.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initScalePort();
            StartTimer();
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
                //s.DebugScaleData();
                s.Disconnect();
                tbScaleWt.Text= Convert.ToString(weight);  
            }
            else
            {
            
                tbScaleWt.Text ="0.0";
             
            }
        }

         private void readScale()
         {
            if (scaleActive == true)
            {
                //Byte[] buf;
                //tbScaleWt.Text = "";
               // portScale.Write("500");
                bool oktoread = true;
                //while (oktoread)
                //{
                //    try
                //    {
                //        string message = portScale.ReadExisting();
                //        if (message == "")
                //        {
                //            oktoread = false;
                //        }
                //        else
                //        {
                //            tbScaleWt.Text = message;
                //        }
                //    }
                //    catch (TimeoutException) { Debug.Print("timed out"); oktoread = false; }
                //}
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            readScale();
        }

        private void FastTrackForm_Load(object sender, EventArgs e)
        {

        }

        private void tbScaleWt_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnEnableDisableTimer_Click(object sender, EventArgs e)
        {
            if (timerEnabled)
            {
                timerEnabled = false;
                BtnEnableDisableTimer.Text = "Enable Timer";
                timer.Stop();
                tssStatus.BackColor = Color.LightGray;
                tssStatus.Text = "Timer Disabled";
            }
            else
            {
                timerEnabled = true;
                BtnEnableDisableTimer.Text = "Disable Timer";
                initScalePort();
                StartTimer();
            }
        }

    }
}



