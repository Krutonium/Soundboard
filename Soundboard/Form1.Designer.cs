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
            this.AddButton = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbBinds.SuspendLayout();
            this.panelBinds.SuspendLayout();
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
            this.gbBinds.Location = new System.Drawing.Point(409, 12);
            this.gbBinds.Name = "gbBinds";
            this.gbBinds.Size = new System.Drawing.Size(468, 426);
            this.gbBinds.TabIndex = 1;
            this.gbBinds.TabStop = false;
            this.gbBinds.Text = "Keybinds";
            // 
            // panelBinds
            // 
            this.panelBinds.Controls.Add(this.btnSave);
            this.panelBinds.Controls.Add(this.AddButton);
            this.panelBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBinds.Location = new System.Drawing.Point(3, 16);
            this.panelBinds.Name = "panelBinds";
            this.panelBinds.Size = new System.Drawing.Size(462, 407);
            this.panelBinds.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(355, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(104, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add Keybind";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(355, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // frmSoundboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 450);
            this.Controls.Add(this.gbBinds);
            this.Controls.Add(this.listSounds);
            this.Name = "frmSoundboard";
            this.Text = "Soundboard";
            this.Load += new System.EventHandler(this.FrmSoundboard_Load);
            this.gbBinds.ResumeLayout(false);
            this.panelBinds.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listSounds;
        private System.Windows.Forms.GroupBox gbBinds;
        private System.Windows.Forms.Panel panelBinds;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button AddButton;
    }
}

