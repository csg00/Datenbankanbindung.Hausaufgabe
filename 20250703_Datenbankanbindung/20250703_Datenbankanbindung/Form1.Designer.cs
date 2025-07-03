namespace _20250703_Datenbankanbindung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bn_details = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bn_zurueck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // bn_details
            // 
            this.bn_details.Location = new System.Drawing.Point(32, 98);
            this.bn_details.Name = "bn_details";
            this.bn_details.Size = new System.Drawing.Size(115, 23);
            this.bn_details.TabIndex = 1;
            this.bn_details.Text = "Details";
            this.bn_details.UseVisualStyleBackColor = true;
            this.bn_details.Click += new System.EventHandler(this.bn_details_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(293, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(191, 370);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // bn_zurueck
            // 
            this.bn_zurueck.Location = new System.Drawing.Point(37, 373);
            this.bn_zurueck.Name = "bn_zurueck";
            this.bn_zurueck.Size = new System.Drawing.Size(99, 26);
            this.bn_zurueck.TabIndex = 3;
            this.bn_zurueck.Text = "Zurück";
            this.bn_zurueck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bn_zurueck);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bn_details);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bn_details;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bn_zurueck;
    }
}

