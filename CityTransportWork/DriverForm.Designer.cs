namespace CityTransportWork
{
    partial class DriverForm
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
            this.schedule = new System.Windows.Forms.TabControl();
            this.schedulePage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reportPage = new System.Windows.Forms.TabPage();
            this.money = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trips = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FIO = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.schedule.SuspendLayout();
            this.schedulePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.reportPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // schedule
            // 
            this.schedule.Controls.Add(this.schedulePage);
            this.schedule.Controls.Add(this.reportPage);
            this.schedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedule.Location = new System.Drawing.Point(0, 0);
            this.schedule.Name = "schedule";
            this.schedule.SelectedIndex = 0;
            this.schedule.Size = new System.Drawing.Size(1126, 425);
            this.schedule.TabIndex = 2;
            // 
            // schedulePage
            // 
            this.schedulePage.Controls.Add(this.label1);
            this.schedulePage.Controls.Add(this.dateTimePicker);
            this.schedulePage.Controls.Add(this.dataGridView1);
            this.schedulePage.Location = new System.Drawing.Point(4, 25);
            this.schedulePage.Name = "schedulePage";
            this.schedulePage.Padding = new System.Windows.Forms.Padding(3);
            this.schedulePage.Size = new System.Drawing.Size(1118, 396);
            this.schedulePage.TabIndex = 0;
            this.schedulePage.Text = "Расписание";
            this.schedulePage.UseVisualStyleBackColor = true;
            this.schedulePage.Click += new System.EventHandler(this.schedulePage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(915, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1115, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // reportPage
            // 
            this.reportPage.Controls.Add(this.money);
            this.reportPage.Controls.Add(this.label3);
            this.reportPage.Controls.Add(this.time);
            this.reportPage.Controls.Add(this.label2);
            this.reportPage.Controls.Add(this.trips);
            this.reportPage.Controls.Add(this.label4);
            this.reportPage.Controls.Add(this.FIO);
            this.reportPage.Controls.Add(this.dateTimePicker1);
            this.reportPage.Location = new System.Drawing.Point(4, 25);
            this.reportPage.Name = "reportPage";
            this.reportPage.Padding = new System.Windows.Forms.Padding(3);
            this.reportPage.Size = new System.Drawing.Size(1118, 396);
            this.reportPage.TabIndex = 1;
            this.reportPage.Text = "Отчёт";
            this.reportPage.UseVisualStyleBackColor = true;
            this.reportPage.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // money
            // 
            this.money.AutoSize = true;
            this.money.Location = new System.Drawing.Point(282, 243);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(14, 16);
            this.money.TabIndex = 13;
            this.money.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Выручка";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(282, 186);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(14, 16);
            this.time.TabIndex = 11;
            this.time.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Время в пути";
            // 
            // trips
            // 
            this.trips.AutoSize = true;
            this.trips.Location = new System.Drawing.Point(282, 124);
            this.trips.Name = "trips";
            this.trips.Size = new System.Drawing.Size(14, 16);
            this.trips.TabIndex = 9;
            this.trips.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Количество поездок";
            // 
            // FIO
            // 
            this.FIO.AutoSize = true;
            this.FIO.Location = new System.Drawing.Point(121, 71);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(13, 16);
            this.FIO.TabIndex = 7;
            this.FIO.Text = " .";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(515, 180);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 425);
            this.Controls.Add(this.schedule);
            this.Name = "DriverForm";
            this.Text = "Водитель";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DriverForm_FormClosed);
            this.Load += new System.EventHandler(this.DriverForm_Load);
            this.schedule.ResumeLayout(false);
            this.schedulePage.ResumeLayout(false);
            this.schedulePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.reportPage.ResumeLayout(false);
            this.reportPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl schedule;
        private System.Windows.Forms.TabPage schedulePage;
        private System.Windows.Forms.TabPage reportPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label trips;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label FIO;
    }
}