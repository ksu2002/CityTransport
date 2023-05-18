namespace CityTransportWork
{
    partial class AddTrip
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
            this.routeNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.transportType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.driver = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.car = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // routeNumber
            // 
            this.routeNumber.FormattingEnabled = true;
            this.routeNumber.Location = new System.Drawing.Point(223, 44);
            this.routeNumber.Name = "routeNumber";
            this.routeNumber.Size = new System.Drawing.Size(121, 24);
            this.routeNumber.TabIndex = 0;
            this.routeNumber.SelectedIndexChanged += new System.EventHandler(this.routeNumber_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер маршрута";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вид транспорта";
            // 
            // transportType
            // 
            this.transportType.FormattingEnabled = true;
            this.transportType.Location = new System.Drawing.Point(223, 112);
            this.transportType.Name = "transportType";
            this.transportType.Size = new System.Drawing.Size(121, 24);
            this.transportType.TabIndex = 2;
            this.transportType.SelectedIndexChanged += new System.EventHandler(this.transportType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Время отправления";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Водитель";
            // 
            // driver
            // 
            this.driver.FormattingEnabled = true;
            this.driver.Location = new System.Drawing.Point(223, 259);
            this.driver.Name = "driver";
            this.driver.Size = new System.Drawing.Size(121, 24);
            this.driver.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Машина";
            // 
            // car
            // 
            this.car.FormattingEnabled = true;
            this.car.Location = new System.Drawing.Point(223, 332);
            this.car.Name = "car";
            this.car.Size = new System.Drawing.Size(121, 24);
            this.car.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(223, 185);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 22);
            this.dateTimePicker1.TabIndex = 14;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // AddTrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 399);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.car);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.driver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transportType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.routeNumber);
            this.Name = "AddTrip";
            this.Text = "Новая поездка";
            this.Load += new System.EventHandler(this.AddTrip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox routeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox transportType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox driver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox car;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}