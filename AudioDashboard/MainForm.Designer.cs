namespace AudioDashboard
{
    partial class MainForm
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
            this.cmbOutput = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbInput = new System.Windows.Forms.ComboBox();
            this.lblOutputDevice = new System.Windows.Forms.Label();
            this.lblInputDevice = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.cbPlayOnSpeaker = new System.Windows.Forms.CheckBox();
            this.lblSpeakerDevice = new System.Windows.Forms.Label();
            this.cmbSpeaker = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbOutput
            // 
            this.cmbOutput.FormattingEnabled = true;
            this.cmbOutput.Location = new System.Drawing.Point(145, 25);
            this.cmbOutput.Name = "cmbOutput";
            this.cmbOutput.Size = new System.Drawing.Size(121, 21);
            this.cmbOutput.TabIndex = 1;
            this.cmbOutput.SelectedIndexChanged += new System.EventHandler(this.cmbOutput_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 115);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbInput
            // 
            this.cmbInput.FormattingEnabled = true;
            this.cmbInput.Location = new System.Drawing.Point(16, 25);
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Size = new System.Drawing.Size(121, 21);
            this.cmbInput.TabIndex = 3;
            this.cmbInput.SelectedIndexChanged += new System.EventHandler(this.cmbInput_SelectedIndexChanged);
            // 
            // lblOutputDevice
            // 
            this.lblOutputDevice.AutoSize = true;
            this.lblOutputDevice.Location = new System.Drawing.Point(143, 9);
            this.lblOutputDevice.Name = "lblOutputDevice";
            this.lblOutputDevice.Size = new System.Drawing.Size(76, 13);
            this.lblOutputDevice.TabIndex = 4;
            this.lblOutputDevice.Text = "OutputDevice:";
            // 
            // lblInputDevice
            // 
            this.lblInputDevice.AutoSize = true;
            this.lblInputDevice.Location = new System.Drawing.Point(12, 9);
            this.lblInputDevice.Name = "lblInputDevice";
            this.lblInputDevice.Size = new System.Drawing.Size(71, 13);
            this.lblInputDevice.TabIndex = 5;
            this.lblInputDevice.Text = "Input Device:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(16, 144);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cbPlayOnSpeaker
            // 
            this.cbPlayOnSpeaker.AutoSize = true;
            this.cbPlayOnSpeaker.Location = new System.Drawing.Point(16, 92);
            this.cbPlayOnSpeaker.Name = "cbPlayOnSpeaker";
            this.cbPlayOnSpeaker.Size = new System.Drawing.Size(96, 17);
            this.cbPlayOnSpeaker.TabIndex = 7;
            this.cbPlayOnSpeaker.Text = "Enable Default";
            this.cbPlayOnSpeaker.UseVisualStyleBackColor = true;
            this.cbPlayOnSpeaker.CheckedChanged += new System.EventHandler(this.cbPlayOnSpeaker_CheckedChanged);
            // 
            // lblSpeakerDevice
            // 
            this.lblSpeakerDevice.AutoSize = true;
            this.lblSpeakerDevice.Location = new System.Drawing.Point(13, 49);
            this.lblSpeakerDevice.Name = "lblSpeakerDevice";
            this.lblSpeakerDevice.Size = new System.Drawing.Size(87, 13);
            this.lblSpeakerDevice.TabIndex = 9;
            this.lblSpeakerDevice.Text = "Speaker Device:";
            // 
            // cmbSpeaker
            // 
            this.cmbSpeaker.FormattingEnabled = true;
            this.cmbSpeaker.Location = new System.Drawing.Point(16, 65);
            this.cmbSpeaker.Name = "cmbSpeaker";
            this.cmbSpeaker.Size = new System.Drawing.Size(121, 21);
            this.cmbSpeaker.TabIndex = 8;
            this.cmbSpeaker.SelectedIndexChanged += new System.EventHandler(this.cmbSpeaker_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 192);
            this.Controls.Add(this.lblSpeakerDevice);
            this.Controls.Add(this.cmbSpeaker);
            this.Controls.Add(this.cbPlayOnSpeaker);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblInputDevice);
            this.Controls.Add(this.lblOutputDevice);
            this.Controls.Add(this.cmbInput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbOutput);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbOutput;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbInput;
        private System.Windows.Forms.Label lblOutputDevice;
        private System.Windows.Forms.Label lblInputDevice;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox cbPlayOnSpeaker;
        private System.Windows.Forms.Label lblSpeakerDevice;
        private System.Windows.Forms.ComboBox cmbSpeaker;
    }
}

