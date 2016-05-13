namespace weatherApp2
{
    partial class DayScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.weatherImage = new System.Windows.Forms.PictureBox();
            this.currentTempLabel = new System.Windows.Forms.Label();
            this.humidityLabel = new System.Windows.Forms.Label();
            this.chancePrecipLabel = new System.Windows.Forms.Label();
            this.cloudsLabel = new System.Windows.Forms.Label();
            this.highLowTempLabel = new System.Windows.Forms.Label();
            this.windLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.weatherImage)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.White;
            this.dateLabel.Location = new System.Drawing.Point(3, 30);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(408, 39);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "label1";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weatherImage
            // 
            this.weatherImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.weatherImage.Location = new System.Drawing.Point(0, 33);
            this.weatherImage.Name = "weatherImage";
            this.weatherImage.Size = new System.Drawing.Size(408, 400);
            this.weatherImage.TabIndex = 3;
            this.weatherImage.TabStop = false;
            // 
            // currentTempLabel
            // 
            this.currentTempLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentTempLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTempLabel.ForeColor = System.Drawing.Color.White;
            this.currentTempLabel.Location = new System.Drawing.Point(3, 382);
            this.currentTempLabel.Name = "currentTempLabel";
            this.currentTempLabel.Size = new System.Drawing.Size(120, 62);
            this.currentTempLabel.TabIndex = 4;
            this.currentTempLabel.Text = "label1";
            this.currentTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // humidityLabel
            // 
            this.humidityLabel.BackColor = System.Drawing.Color.Transparent;
            this.humidityLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humidityLabel.ForeColor = System.Drawing.Color.White;
            this.humidityLabel.Location = new System.Drawing.Point(-4, 584);
            this.humidityLabel.Name = "humidityLabel";
            this.humidityLabel.Size = new System.Drawing.Size(134, 67);
            this.humidityLabel.TabIndex = 6;
            this.humidityLabel.Text = "label1";
            this.humidityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chancePrecipLabel
            // 
            this.chancePrecipLabel.BackColor = System.Drawing.Color.Transparent;
            this.chancePrecipLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chancePrecipLabel.ForeColor = System.Drawing.Color.White;
            this.chancePrecipLabel.Location = new System.Drawing.Point(249, 479);
            this.chancePrecipLabel.Name = "chancePrecipLabel";
            this.chancePrecipLabel.Size = new System.Drawing.Size(159, 89);
            this.chancePrecipLabel.TabIndex = 7;
            this.chancePrecipLabel.Text = "label1";
            this.chancePrecipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cloudsLabel
            // 
            this.cloudsLabel.BackColor = System.Drawing.Color.Transparent;
            this.cloudsLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cloudsLabel.ForeColor = System.Drawing.Color.White;
            this.cloudsLabel.Location = new System.Drawing.Point(3, 507);
            this.cloudsLabel.Name = "cloudsLabel";
            this.cloudsLabel.Size = new System.Drawing.Size(189, 33);
            this.cloudsLabel.TabIndex = 8;
            this.cloudsLabel.Text = "label1";
            this.cloudsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // highLowTempLabel
            // 
            this.highLowTempLabel.BackColor = System.Drawing.Color.Transparent;
            this.highLowTempLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highLowTempLabel.ForeColor = System.Drawing.Color.White;
            this.highLowTempLabel.Location = new System.Drawing.Point(262, 402);
            this.highLowTempLabel.Name = "highLowTempLabel";
            this.highLowTempLabel.Size = new System.Drawing.Size(125, 33);
            this.highLowTempLabel.TabIndex = 9;
            this.highLowTempLabel.Text = "label1";
            this.highLowTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windLabel
            // 
            this.windLabel.BackColor = System.Drawing.Color.Transparent;
            this.windLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windLabel.ForeColor = System.Drawing.Color.White;
            this.windLabel.Location = new System.Drawing.Point(262, 583);
            this.windLabel.Name = "windLabel";
            this.windLabel.Size = new System.Drawing.Size(125, 69);
            this.windLabel.TabIndex = 28;
            this.windLabel.Text = "label1";
            this.windLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.windLabel);
            this.Controls.Add(this.highLowTempLabel);
            this.Controls.Add(this.cloudsLabel);
            this.Controls.Add(this.chancePrecipLabel);
            this.Controls.Add(this.humidityLabel);
            this.Controls.Add(this.currentTempLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.weatherImage);
            this.Name = "DayScreen";
            this.Size = new System.Drawing.Size(414, 736);
            this.Load += new System.EventHandler(this.DayScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.weatherImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.PictureBox weatherImage;
        private System.Windows.Forms.Label currentTempLabel;
        private System.Windows.Forms.Label humidityLabel;
        private System.Windows.Forms.Label chancePrecipLabel;
        private System.Windows.Forms.Label cloudsLabel;
        private System.Windows.Forms.Label highLowTempLabel;
        private System.Windows.Forms.Label windLabel;
    }
}
