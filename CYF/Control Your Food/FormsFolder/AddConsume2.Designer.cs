
namespace Control_Your_Food.FormsFolder
{
    partial class AddConsume2
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
            this.IloscWComboBox = new System.Windows.Forms.ComboBox();
            this.IloscWLabel = new System.Windows.Forms.Label();
            this.WartośćWybranaPicker = new System.Windows.Forms.NumericUpDown();
            this.DodajZuzycieButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.WartośćWybranaPicker)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IloscWComboBox
            // 
            this.IloscWComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IloscWComboBox.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.IloscWComboBox.FormattingEnabled = true;
            this.IloscWComboBox.Items.AddRange(new object[] {
            ""});
            this.IloscWComboBox.Location = new System.Drawing.Point(143, 15);
            this.IloscWComboBox.Name = "IloscWComboBox";
            this.IloscWComboBox.Size = new System.Drawing.Size(159, 34);
            this.IloscWComboBox.TabIndex = 25;
            // 
            // IloscWLabel
            // 
            this.IloscWLabel.AutoSize = true;
            this.IloscWLabel.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.IloscWLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IloscWLabel.Location = new System.Drawing.Point(2, 18);
            this.IloscWLabel.Name = "IloscWLabel";
            this.IloscWLabel.Size = new System.Drawing.Size(113, 26);
            this.IloscWLabel.TabIndex = 23;
            this.IloscWLabel.Text = "Zużycie w  ";
            // 
            // WartośćWybranaPicker
            // 
            this.WartośćWybranaPicker.BackColor = System.Drawing.Color.Gainsboro;
            this.WartośćWybranaPicker.DecimalPlaces = 3;
            this.WartośćWybranaPicker.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.WartośćWybranaPicker.Location = new System.Drawing.Point(359, 15);
            this.WartośćWybranaPicker.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.WartośćWybranaPicker.Name = "WartośćWybranaPicker";
            this.WartośćWybranaPicker.Size = new System.Drawing.Size(247, 33);
            this.WartośćWybranaPicker.TabIndex = 24;
            this.WartośćWybranaPicker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DodajZuzycieButton
            // 
            this.DodajZuzycieButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DodajZuzycieButton.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.DodajZuzycieButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DodajZuzycieButton.Location = new System.Drawing.Point(232, 87);
            this.DodajZuzycieButton.Name = "DodajZuzycieButton";
            this.DodajZuzycieButton.Size = new System.Drawing.Size(201, 50);
            this.DodajZuzycieButton.TabIndex = 26;
            this.DodajZuzycieButton.Text = "Dodaj Zuzycie";
            this.DodajZuzycieButton.UseVisualStyleBackColor = true;
            this.DodajZuzycieButton.Click += new System.EventHandler(this.DodajZuzycieButton_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Control_Your_Food.Properties.Resources.exittt;
            this.button1.Location = new System.Drawing.Point(735, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 66);
            this.button1.TabIndex = 44;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.773386F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.22662F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 656F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.91753F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.08247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 316F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.846154F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(71, 116);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.71165F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.28834F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(650, 310);
            this.tableLayoutPanel2.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IloscWComboBox);
            this.panel1.Controls.Add(this.WartośćWybranaPicker);
            this.panel1.Controls.Add(this.DodajZuzycieButton);
            this.panel1.Controls.Add(this.IloscWLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 207);
            this.panel1.TabIndex = 46;
            // 
            // AddConsume2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddConsume2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj zużycie.";
            this.Load += new System.EventHandler(this.AddConsume2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WartośćWybranaPicker)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox IloscWComboBox;
        private System.Windows.Forms.Label IloscWLabel;
        private System.Windows.Forms.NumericUpDown WartośćWybranaPicker;
        private System.Windows.Forms.Button DodajZuzycieButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}