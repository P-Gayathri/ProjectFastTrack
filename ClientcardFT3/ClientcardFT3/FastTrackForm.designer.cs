﻿namespace ClientcardFB3
{
    partial class FastTrackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastTrackForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dgvFT = new System.Windows.Forms.DataGridView();
            this.colHHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamilySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFoodList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBabySvcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNonFood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLbsStd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLbsOther = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLbsTEFAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLbsSuppl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLbsBaby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDone = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnEnableDisableTimer = new System.Windows.Forms.Button();
            this.tbScaleWt = new System.Windows.Forms.TextBox();
            this.lblFBName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblsep = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dgvFT
            // 
            this.dgvFT.AllowUserToAddRows = false;
            this.dgvFT.AllowUserToDeleteRows = false;
            this.dgvFT.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvFT.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHHID,
            this.colName,
            this.colFamilySize,
            this.colFoodList,
            this.colBabySvcs,
            this.colNonFood,
            this.colNotes,
            this.colLbsStd,
            this.colLbsOther,
            this.colLbsTEFAP,
            this.colLbsSuppl,
            this.colLbsBaby,
            this.colDone});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFT.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvFT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFT.GridColor = System.Drawing.Color.DimGray;
            this.dgvFT.Location = new System.Drawing.Point(0, 0);
            this.dgvFT.Name = "dgvFT";
            this.dgvFT.RowHeadersVisible = false;
            this.dgvFT.RowHeadersWidth = 10;
            this.dgvFT.RowTemplate.Height = 88;
            this.dgvFT.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFT.Size = new System.Drawing.Size(1168, 631);
            this.dgvFT.TabIndex = 24;
            this.dgvFT.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFT_CellBeginEdit);
            this.dgvFT.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFT_CellEndEdit);
            this.dgvFT.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFT_CellMouseClick);
            this.dgvFT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFT_KeyDown);
            // 
            // colHHID
            // 
            this.colHHID.DataPropertyName = "HouseholdId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colHHID.DefaultCellStyle = dataGridViewCellStyle3;
            this.colHHID.DividerWidth = 1;
            this.colHHID.HeaderText = "ID";
            this.colHHID.Name = "colHHID";
            this.colHHID.ReadOnly = true;
            this.colHHID.Width = 60;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colName.DataPropertyName = "Name";
            this.colName.DividerWidth = 5;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colFamilySize
            // 
            this.colFamilySize.DataPropertyName = "FamilySize";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colFamilySize.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFamilySize.DividerWidth = 3;
            this.colFamilySize.HeaderText = "FamilySize";
            this.colFamilySize.Name = "colFamilySize";
            this.colFamilySize.ReadOnly = true;
            this.colFamilySize.Width = 80;
            // 
            // colFoodList
            // 
            this.colFoodList.DataPropertyName = "FoodSvcList";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colFoodList.DefaultCellStyle = dataGridViewCellStyle5;
            this.colFoodList.DividerWidth = 3;
            this.colFoodList.HeaderText = "Food List";
            this.colFoodList.MinimumWidth = 100;
            this.colFoodList.Name = "colFoodList";
            this.colFoodList.ReadOnly = true;
            this.colFoodList.Width = 145;
            // 
            // colBabySvcs
            // 
            this.colBabySvcs.DividerWidth = 2;
            this.colBabySvcs.HeaderText = "Baby Services";
            this.colBabySvcs.Name = "colBabySvcs";
            this.colBabySvcs.ReadOnly = true;
            this.colBabySvcs.Width = 130;
            // 
            // colNonFood
            // 
            this.colNonFood.DividerWidth = 2;
            this.colNonFood.HeaderText = "Non-Food List";
            this.colNonFood.Name = "colNonFood";
            this.colNonFood.ReadOnly = true;
            // 
            // colNotes
            // 
            this.colNotes.DataPropertyName = "Notes";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colNotes.DefaultCellStyle = dataGridViewCellStyle6;
            this.colNotes.DividerWidth = 5;
            this.colNotes.HeaderText = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.ReadOnly = true;
            this.colNotes.Width = 200;
            // 
            // colLbsStd
            // 
            this.colLbsStd.DataPropertyName = "LbsStd";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLbsStd.DefaultCellStyle = dataGridViewCellStyle7;
            this.colLbsStd.DividerWidth = 1;
            this.colLbsStd.HeaderText = "Lbs Std";
            this.colLbsStd.MinimumWidth = 20;
            this.colLbsStd.Name = "colLbsStd";
            this.colLbsStd.Width = 50;
            // 
            // colLbsOther
            // 
            this.colLbsOther.DataPropertyName = "LbsOther";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLbsOther.DefaultCellStyle = dataGridViewCellStyle8;
            this.colLbsOther.DividerWidth = 1;
            this.colLbsOther.HeaderText = "Lbs Other";
            this.colLbsOther.MinimumWidth = 20;
            this.colLbsOther.Name = "colLbsOther";
            this.colLbsOther.Width = 50;
            // 
            // colLbsTEFAP
            // 
            this.colLbsTEFAP.DataPropertyName = "LbsCommodity";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLbsTEFAP.DefaultCellStyle = dataGridViewCellStyle9;
            this.colLbsTEFAP.DividerWidth = 1;
            this.colLbsTEFAP.HeaderText = "Lbs Comm";
            this.colLbsTEFAP.MinimumWidth = 20;
            this.colLbsTEFAP.Name = "colLbsTEFAP";
            this.colLbsTEFAP.Width = 50;
            // 
            // colLbsSuppl
            // 
            this.colLbsSuppl.DataPropertyName = "LbsSupplemental";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLbsSuppl.DefaultCellStyle = dataGridViewCellStyle10;
            this.colLbsSuppl.DividerWidth = 1;
            this.colLbsSuppl.HeaderText = "Lbs Suppl";
            this.colLbsSuppl.MinimumWidth = 20;
            this.colLbsSuppl.Name = "colLbsSuppl";
            this.colLbsSuppl.Width = 50;
            // 
            // colLbsBaby
            // 
            this.colLbsBaby.DataPropertyName = "LbsBabySvc";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLbsBaby.DefaultCellStyle = dataGridViewCellStyle11;
            this.colLbsBaby.DividerWidth = 3;
            this.colLbsBaby.HeaderText = "Lbs Baby";
            this.colLbsBaby.MinimumWidth = 20;
            this.colLbsBaby.Name = "colLbsBaby";
            this.colLbsBaby.Width = 50;
            // 
            // colDone
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.colDone.DefaultCellStyle = dataGridViewCellStyle12;
            this.colDone.DividerWidth = 2;
            this.colDone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colDone.HeaderText = "";
            this.colDone.Name = "colDone";
            this.colDone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDone.Text = "Save";
            this.colDone.UseColumnTextForButtonValue = true;
            this.colDone.Width = 50;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnEnableDisableTimer);
            this.splitContainer1.Panel1.Controls.Add(this.tbScaleWt);
            this.splitContainer1.Panel1.Controls.Add(this.lblFBName);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvFT);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 682);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 4;
            // 
            // BtnEnableDisableTimer
            // 
            this.BtnEnableDisableTimer.Location = new System.Drawing.Point(709, 10);
            this.BtnEnableDisableTimer.Name = "BtnEnableDisableTimer";
            this.BtnEnableDisableTimer.Size = new System.Drawing.Size(124, 27);
            this.BtnEnableDisableTimer.TabIndex = 28;
            this.BtnEnableDisableTimer.Text = "Enable Timer";
            this.BtnEnableDisableTimer.UseVisualStyleBackColor = true;
            this.BtnEnableDisableTimer.Click += new System.EventHandler(this.BtnEnableDisableTimer_Click);
            // 
            // tbScaleWt
            // 
            this.tbScaleWt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.tbScaleWt.Location = new System.Drawing.Point(1065, 0);
            this.tbScaleWt.Name = "tbScaleWt";
            this.tbScaleWt.Size = new System.Drawing.Size(75, 41);
            this.tbScaleWt.TabIndex = 27;
            this.tbScaleWt.Text = "0.00";
            this.tbScaleWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScaleWt.TextChanged += new System.EventHandler(this.tbScaleWt_TextChanged);
            // 
            // lblFBName
            // 
            this.lblFBName.AutoSize = true;
            this.lblFBName.Font = new System.Drawing.Font("Verdana", 14F);
            this.lblFBName.Location = new System.Drawing.Point(12, 14);
            this.lblFBName.Name = "lblFBName";
            this.lblFBName.Size = new System.Drawing.Size(215, 29);
            this.lblFBName.TabIndex = 26;
            this.lblFBName.Text = "Food Bank Name";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(878, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(127, 27);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus,
            this.tsslblsep,
            this.tsslblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1168, 24);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            this.tssStatus.AutoSize = false;
            this.tssStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tssStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(118, 19);
            // 
            // tsslblsep
            // 
            this.tsslblsep.AutoSize = false;
            this.tsslblsep.BackColor = System.Drawing.SystemColors.Control;
            this.tsslblsep.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsslblsep.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslblsep.Name = "tsslblsep";
            this.tsslblsep.Size = new System.Drawing.Size(150, 19);
            // 
            // tsslblMsg
            // 
            this.tsslblMsg.AutoSize = false;
            this.tsslblMsg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tsslblMsg.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsslblMsg.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslblMsg.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tsslblMsg.ForeColor = System.Drawing.Color.Magenta;
            this.tsslblMsg.Name = "tsslblMsg";
            this.tsslblMsg.Size = new System.Drawing.Size(500, 19);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FastTrackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1168, 682);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FastTrackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ClientcardFB3 FAST TRACK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FastTrackForm_FormClosing);
            this.Load += new System.EventHandler(this.FastTrackForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FastTrackForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFT)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dgvFT;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblFBName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslblsep;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamilySize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFoodList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBabySvcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNonFood;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLbsStd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLbsOther;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLbsTEFAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLbsSuppl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLbsBaby;
        private System.Windows.Forms.DataGridViewButtonColumn colDone;
        private System.Windows.Forms.TextBox tbScaleWt;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnEnableDisableTimer;
    }
}