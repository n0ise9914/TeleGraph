namespace Sample_TeleGraph
{
    partial class Item_Plugin
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
            this.CommandList = new System.Windows.Forms.TableLayoutPanel();
            this.Author = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.Commands = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CommandList
            // 
            this.CommandList.BackColor = System.Drawing.SystemColors.Menu;
            this.CommandList.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.CommandList.ColumnCount = 1;
            this.CommandList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CommandList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CommandList.Location = new System.Drawing.Point(6, 140);
            this.CommandList.Name = "CommandList";
            this.CommandList.RowCount = 2;
            this.CommandList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CommandList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CommandList.Size = new System.Drawing.Size(293, 268);
            this.CommandList.TabIndex = 8;
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(18, 43);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(44, 13);
            this.Author.TabIndex = 9;
            this.Author.Text = "Author: ";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(18, 18);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(41, 13);
            this.name.TabIndex = 10;
            this.name.Text = "Name: ";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(18, 91);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(66, 13);
            this.Description.TabIndex = 11;
            this.Description.Text = "Description: ";
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(18, 68);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(48, 13);
            this.Version.TabIndex = 12;
            this.Version.Text = "Version: ";
            // 
            // Commands
            // 
            this.Commands.AutoSize = true;
            this.Commands.Location = new System.Drawing.Point(3, 124);
            this.Commands.Name = "Commands";
            this.Commands.Size = new System.Drawing.Size(62, 13);
            this.Commands.TabIndex = 13;
            this.Commands.Text = "Commands:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Commands);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.CommandList);
            this.Name = "CPlugin";
            this.Size = new System.Drawing.Size(304, 444);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel CommandList;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label Commands;
        private System.Windows.Forms.Button button1;
    }
}
