namespace Sample_TeleGraph
{
    partial class Item_command
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
            this.Key = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Key
            // 
            this.Key.AutoSize = true;
            this.Key.Location = new System.Drawing.Point(5, 10);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(34, 13);
            this.Key.TabIndex = 0;
            this.Key.Text = "Key:  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(5, 35);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(66, 13);
            this.Description.TabIndex = 2;
            this.Description.Text = "Description: ";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(172, 7);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(83, 20);
            this.name.TabIndex = 3;
            // 
            // Ccommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.name);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Key);
            this.Name = "Ccommand";
            this.Size = new System.Drawing.Size(268, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Description;
        public System.Windows.Forms.Label Key;
        public System.Windows.Forms.TextBox name;
    }
}
