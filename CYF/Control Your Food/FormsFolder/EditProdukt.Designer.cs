
namespace Control_Your_Food.FormsFolder
{
    partial class EditProdukt
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CBILOSCW = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbJakieZuzycie = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbZuzycieW = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownZuzycieCzasowe = new System.Windows.Forms.NumericUpDown();
            this.tbNazwa = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbKategoria = new System.Windows.Forms.ComboBox();
            this.labelMinIlosc = new System.Windows.Forms.Label();
            this.numMinMinimalnaIlosc = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.cbCzyProduktWazny = new System.Windows.Forms.CheckBox();
            this.nIlosc = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.datePickerWaznosci = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZuzycieCzasowe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinMinimalnaIlosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIlosc)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CBILOSCW);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbJakieZuzycie);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbZuzycieW);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.numericUpDownZuzycieCzasowe);
            this.groupBox1.Controls.Add(this.tbNazwa);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbKategoria);
            this.groupBox1.Controls.Add(this.labelMinIlosc);
            this.groupBox1.Controls.Add(this.numMinMinimalnaIlosc);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cbCzyProduktWazny);
            this.groupBox1.Controls.Add(this.nIlosc);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.datePickerWaznosci);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(48, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 448);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(113, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 26);
            this.label9.TabIndex = 34;
            this.label9.Text = "w";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(59, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 26);
            this.label10.TabIndex = 10;
            this.label10.Text = "Zużycie";
            // 
            // CBILOSCW
            // 
            this.CBILOSCW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBILOSCW.BackColor = System.Drawing.Color.Gainsboro;
            this.CBILOSCW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBILOSCW.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.CBILOSCW.Items.AddRange(new object[] {
            "Dzienne",
            "Tygodniowe ",
            "Miesięczne"});
            this.CBILOSCW.Location = new System.Drawing.Point(320, 93);
            this.CBILOSCW.MaximumSize = new System.Drawing.Size(163, 0);
            this.CBILOSCW.Name = "CBILOSCW";
            this.CBILOSCW.Size = new System.Drawing.Size(163, 34);
            this.CBILOSCW.TabIndex = 38;
            this.CBILOSCW.SelectedIndexChanged += new System.EventHandler(this.CBILOSCW_SelectedIndexChanged_1);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(12, 283);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 26);
            this.label11.TabIndex = 17;
            this.label11.Text = "Ilość zużycia ";
            // 
            // cbJakieZuzycie
            // 
            this.cbJakieZuzycie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbJakieZuzycie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJakieZuzycie.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbJakieZuzycie.Items.AddRange(new object[] {
            ""});
            this.cbJakieZuzycie.Location = new System.Drawing.Point(166, 235);
            this.cbJakieZuzycie.Name = "cbJakieZuzycie";
            this.cbJakieZuzycie.Size = new System.Drawing.Size(151, 34);
            this.cbJakieZuzycie.Sorted = true;
            this.cbJakieZuzycie.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(535, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 37);
            this.label12.TabIndex = 33;
            // 
            // cbZuzycieW
            // 
            this.cbZuzycieW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbZuzycieW.BackColor = System.Drawing.Color.Gainsboro;
            this.cbZuzycieW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZuzycieW.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbZuzycieW.Items.AddRange(new object[] {
            "Dzienne",
            "Tygodniowe ",
            "Miesięczne"});
            this.cbZuzycieW.Location = new System.Drawing.Point(166, 322);
            this.cbZuzycieW.Name = "cbZuzycieW";
            this.cbZuzycieW.Size = new System.Drawing.Size(151, 34);
            this.cbZuzycieW.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.CausesValidation = false;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(201, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 26);
            this.label13.TabIndex = 4;
            this.label13.Text = "Nazwa:";
            // 
            // numericUpDownZuzycieCzasowe
            // 
            this.numericUpDownZuzycieCzasowe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownZuzycieCzasowe.BackColor = System.Drawing.Color.Gainsboro;
            this.numericUpDownZuzycieCzasowe.DecimalPlaces = 3;
            this.numericUpDownZuzycieCzasowe.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.numericUpDownZuzycieCzasowe.Location = new System.Drawing.Point(166, 281);
            this.numericUpDownZuzycieCzasowe.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownZuzycieCzasowe.Name = "numericUpDownZuzycieCzasowe";
            this.numericUpDownZuzycieCzasowe.Size = new System.Drawing.Size(151, 33);
            this.numericUpDownZuzycieCzasowe.TabIndex = 26;
            // 
            // tbNazwa
            // 
            this.tbNazwa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNazwa.BackColor = System.Drawing.Color.Gainsboro;
            this.tbNazwa.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbNazwa.Location = new System.Drawing.Point(320, 14);
            this.tbNazwa.Name = "tbNazwa";
            this.tbNazwa.Size = new System.Drawing.Size(314, 33);
            this.tbNazwa.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(200, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 26);
            this.label14.TabIndex = 5;
            this.label14.Text = "Kategoria:";
            // 
            // tbKategoria
            // 
            this.tbKategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbKategoria.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbKategoria.Items.AddRange(new object[] {
            ""});
            this.tbKategoria.Location = new System.Drawing.Point(320, 53);
            this.tbKategoria.Name = "tbKategoria";
            this.tbKategoria.Size = new System.Drawing.Size(314, 34);
            this.tbKategoria.TabIndex = 22;
            // 
            // labelMinIlosc
            // 
            this.labelMinIlosc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMinIlosc.AutoSize = true;
            this.labelMinIlosc.Font = new System.Drawing.Font("Palatino Linotype", 12.25F, System.Drawing.FontStyle.Bold);
            this.labelMinIlosc.Location = new System.Drawing.Point(429, 235);
            this.labelMinIlosc.Name = "labelMinIlosc";
            this.labelMinIlosc.Size = new System.Drawing.Size(385, 69);
            this.labelMinIlosc.TabIndex = 24;
            this.labelMinIlosc.Text = "Wprowadź wartość minimalnął produktu\r\n( gdy ilość produktu zjedzie poniżej min pr" +
    "odukt \r\nznajdzie się na liście zakupów)";
            // 
            // numMinMinimalnaIlosc
            // 
            this.numMinMinimalnaIlosc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numMinMinimalnaIlosc.BackColor = System.Drawing.Color.Gainsboro;
            this.numMinMinimalnaIlosc.DecimalPlaces = 3;
            this.numMinMinimalnaIlosc.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.numMinMinimalnaIlosc.Location = new System.Drawing.Point(433, 334);
            this.numMinMinimalnaIlosc.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMinMinimalnaIlosc.MaximumSize = new System.Drawing.Size(280, 0);
            this.numMinMinimalnaIlosc.Name = "numMinMinimalnaIlosc";
            this.numMinMinimalnaIlosc.Size = new System.Drawing.Size(201, 33);
            this.numMinMinimalnaIlosc.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(201, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 26);
            this.label16.TabIndex = 6;
            this.label16.Text = "Ilość w ";
            // 
            // cbCzyProduktWazny
            // 
            this.cbCzyProduktWazny.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCzyProduktWazny.AutoSize = true;
            this.cbCzyProduktWazny.BackColor = System.Drawing.Color.White;
            this.cbCzyProduktWazny.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbCzyProduktWazny.ForeColor = System.Drawing.Color.Black;
            this.cbCzyProduktWazny.Location = new System.Drawing.Point(433, 191);
            this.cbCzyProduktWazny.Name = "cbCzyProduktWazny";
            this.cbCzyProduktWazny.Size = new System.Drawing.Size(228, 30);
            this.cbCzyProduktWazny.TabIndex = 16;
            this.cbCzyProduktWazny.Text = "Jednorazowy produkt";
            this.cbCzyProduktWazny.UseVisualStyleBackColor = false;
            // 
            // nIlosc
            // 
            this.nIlosc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nIlosc.BackColor = System.Drawing.Color.Gainsboro;
            this.nIlosc.DecimalPlaces = 3;
            this.nIlosc.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.nIlosc.Location = new System.Drawing.Point(489, 93);
            this.nIlosc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nIlosc.Name = "nIlosc";
            this.nIlosc.Size = new System.Drawing.Size(145, 33);
            this.nIlosc.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(97, 139);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(208, 26);
            this.label17.TabIndex = 7;
            this.label17.Text = "Termin ważności mija";
            // 
            // datePickerWaznosci
            // 
            this.datePickerWaznosci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerWaznosci.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.datePickerWaznosci.Location = new System.Drawing.Point(320, 134);
            this.datePickerWaznosci.Name = "datePickerWaznosci";
            this.datePickerWaznosci.Size = new System.Drawing.Size(314, 33);
            this.datePickerWaznosci.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.639175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.62887F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(970, 548);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.UpdateButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(48, 457);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(844, 88);
            this.tableLayoutPanel2.TabIndex = 52;
            // 
            // UpdateButton
            // 
            this.UpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UpdateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.UpdateButton.Location = new System.Drawing.Point(284, 18);
            this.UpdateButton.MaximumSize = new System.Drawing.Size(276, 54);
            this.UpdateButton.MinimumSize = new System.Drawing.Size(176, 34);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(275, 39);
            this.UpdateButton.TabIndex = 31;
            this.UpdateButton.Text = "Zatwierdź";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Control_Your_Food.Properties.Resources.exittt;
            this.button1.Location = new System.Drawing.Point(898, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 47);
            this.button1.TabIndex = 55;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditProdukt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 548);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProdukt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edytuj Produkt";
            this.Load += new System.EventHandler(this.EditProdukt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZuzycieCzasowe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinMinimalnaIlosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIlosc)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbJakieZuzycie;
        private System.Windows.Forms.ComboBox cbZuzycieW;
        private System.Windows.Forms.NumericUpDown numericUpDownZuzycieCzasowe;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbNazwa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox tbKategoria;
        private System.Windows.Forms.Label labelMinIlosc;
        private System.Windows.Forms.NumericUpDown numMinMinimalnaIlosc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbCzyProduktWazny;
        private System.Windows.Forms.NumericUpDown nIlosc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker datePickerWaznosci;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CBILOSCW;
    }
}