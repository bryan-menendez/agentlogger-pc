namespace AgentLogger
{
    partial class LoggerAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggerAgent));
            this.lblName = new System.Windows.Forms.Label();
            this.btnClockToggle = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.tableClockHours = new System.Windows.Forms.DataGridView();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableClockHours)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnClockToggle
            // 
            this.btnClockToggle.Location = new System.Drawing.Point(7, 464);
            this.btnClockToggle.Name = "btnClockToggle";
            this.btnClockToggle.Size = new System.Drawing.Size(316, 52);
            this.btnClockToggle.TabIndex = 7;
            this.btnClockToggle.Text = "Iniciar Registro";
            this.btnClockToggle.UseVisualStyleBackColor = true;
            this.btnClockToggle.Click += new System.EventHandler(this.btnClockToggle_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(332, 28);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.menuToolStripMenuItem.Text = "Options";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAutoLogin,
            this.menuAutoStart,
            this.menuAutoStop,
            this.menuAutoWindows});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // menuAutoLogin
            // 
            this.menuAutoLogin.Checked = true;
            this.menuAutoLogin.CheckOnClick = true;
            this.menuAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuAutoLogin.Name = "menuAutoLogin";
            this.menuAutoLogin.Size = new System.Drawing.Size(220, 26);
            this.menuAutoLogin.Text = "Auto Login";
            this.menuAutoLogin.Click += new System.EventHandler(this.menuAutoLogin_Click);
            // 
            // menuAutoStart
            // 
            this.menuAutoStart.Checked = true;
            this.menuAutoStart.CheckOnClick = true;
            this.menuAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuAutoStart.Name = "menuAutoStart";
            this.menuAutoStart.Size = new System.Drawing.Size(220, 26);
            this.menuAutoStart.Text = "Auto Start";
            this.menuAutoStart.Click += new System.EventHandler(this.menuAutoStart_Click);
            // 
            // menuAutoStop
            // 
            this.menuAutoStop.Checked = true;
            this.menuAutoStop.CheckOnClick = true;
            this.menuAutoStop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuAutoStop.Name = "menuAutoStop";
            this.menuAutoStop.Size = new System.Drawing.Size(220, 26);
            this.menuAutoStop.Text = "Auto Stop";
            this.menuAutoStop.Click += new System.EventHandler(this.menuAutoStop_Click);
            // 
            // menuAutoWindows
            // 
            this.menuAutoWindows.Checked = true;
            this.menuAutoWindows.CheckOnClick = true;
            this.menuAutoWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuAutoWindows.Name = "menuAutoWindows";
            this.menuAutoWindows.Size = new System.Drawing.Size(220, 26);
            this.menuAutoWindows.Text = "Start with Windows";
            // 
            // tableClockHours
            // 
            this.tableClockHours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableClockHours.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableClockHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableClockHours.Location = new System.Drawing.Point(15, 132);
            this.tableClockHours.Name = "tableClockHours";
            this.tableClockHours.ReadOnly = true;
            this.tableClockHours.RowHeadersVisible = false;
            this.tableClockHours.RowHeadersWidth = 51;
            this.tableClockHours.RowTemplate.Height = 24;
            this.tableClockHours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableClockHours.Size = new System.Drawing.Size(305, 311);
            this.tableClockHours.TabIndex = 9;
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.Location = new System.Drawing.Point(12, 56);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(76, 17);
            this.lblInstitution.TabIndex = 11;
            this.lblInstitution.Text = "Institution: ";
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.Location = new System.Drawing.Point(12, 104);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(89, 25);
            this.lblHorario.TabIndex = 12;
            this.lblHorario.Text = "Horario";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(10, 529);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(227, 29);
            this.lblEstado.TabIndex = 13;
            this.lblEstado.Text = "Estado: En espera";
            // 
            // LoggerAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 567);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.lblInstitution);
            this.Controls.Add(this.tableClockHours);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnClockToggle);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoggerAgent";
            this.Text = "Logger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoggerAgent_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableClockHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnClockToggle;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAutoStart;
        private System.Windows.Forms.ToolStripMenuItem menuAutoStop;
        private System.Windows.Forms.ToolStripMenuItem menuAutoWindows;
        private System.Windows.Forms.DataGridView tableClockHours;
        private System.Windows.Forms.Label lblInstitution;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.ToolStripMenuItem menuAutoLogin;
        private System.Windows.Forms.Label lblEstado;
    }
}