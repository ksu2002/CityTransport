namespace CityTransportWork
{
    partial class MonthlyReport
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
            this.FIO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trips = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // FIO
            // 
            this.FIO.AutoSize = true;
            this.FIO.Location = new System.Drawing.Point(207, 57);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(13, 16);
            this.FIO.TabIndex = 0;
            this.FIO.Text = " .";
            this.FIO.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество поездок";
            // 
            // trips
            // 
            this.trips.AutoSize = true;
            this.trips.Location = new System.Drawing.Point(368, 110);
            this.trips.Name = "trips";
            this.trips.Size = new System.Drawing.Size(14, 16);
            this.trips.TabIndex = 2;
            this.trips.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время в пути";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(368, 172);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(14, 16);
            this.time.TabIndex = 4;
            this.time.Text = "0";
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выручка";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // money
            // 
            this.money.AutoSize = true;
            this.money.Location = new System.Drawing.Point(368, 229);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(14, 16);
            this.money.TabIndex = 6;
            this.money.Text = "0";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(590, 57);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // MonthlyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.money);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trips);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FIO);
            this.Name = "MonthlyReport";
            this.Text = "Отчет за месяц";
            this.Load += new System.EventHandler(this.MonthlyReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label trips;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}