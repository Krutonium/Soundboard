namespace Soundboard
{
    partial class frmSoundboard
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
            this.listSounds = new System.Windows.Forms.ListBox();
            this.gbBinds = new System.Windows.Forms.GroupBox();
            this.panelBinds = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.cbCaps = new System.Windows.Forms.CheckBox();
            this.gbBinds.SuspendLayout();
            this.SuspendLayout();
            // 
            // listSounds
            // 
            this.listSounds.FormattingEnabled = true;
            this.listSounds.Location = new System.Drawing.Point(12, 19);
            this.listSounds.Name = "listSounds";
            this.listSounds.Size = new System.Drawing.Size(391, 420);
            this.listSounds.TabIndex = 0;
            this.listSounds.SelectedIndexChanged += new System.EventHandler(this.ListSounds_SelectedIndexChanged);
            // 
            // gbBinds
            // 
            this.gbBinds.Controls.Add(this.panelBinds);
            this.gbBinds.Location = new System.Drawing.Point(409, 48);
            this.gbBinds.Name = "gbBinds";
            this.gbBinds.Size = new System.Drawing.Size(468, 390);
            this.gbBinds.TabIndex = 1;
            this.gbBinds.TabStop = false;
            this.gbBinds.Text = "Keybinds";
            // 
            // panelBinds
            // 
            this.panelBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBinds.Location = new System.Drawing.Point(3, 16);
            this.panelBinds.Name = "panelBinds";
            this.panelBinds.Size = new System.Drawing.Size(462, 371);
            this.panelBinds.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(773, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(412, 19);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(104, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add Keybind";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cbCaps
            // 
            this.cbCaps.AutoSize = true;
            this.cbCaps.Location = new System.Drawing.Point(552, 23);
            this.cbCaps.Name = "cbCaps";
            this.cbCaps.Size = new System.Drawing.Size(192, 17);
            this.cbCaps.TabIndex = 2;
            this.cbCaps.Text = "Only Function when Capslock is on";
            this.cbCaps.UseVisualStyleBackColor = true;
            this.cbCaps.CheckedChanged += new System.EventHandler(this.cbCaps_CheckedChanged);
            // 
            // frmSoundboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 450);
            this.Controls.Add(this.cbCaps);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.gbBinds);
            this.Controls.Add(this.listSounds);
            this.Name = "frmSoundboard";
            this.Text = "Soundboard";
            this.Load += new System.EventHandler(this.FrmSoundboard_Load);
            this.gbBinds.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listSounds;
        private System.Windows.Forms.GroupBox gbBinds;
        private System.Windows.Forms.Panel panelBinds;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.CheckBox cbCaps;
    }
}

