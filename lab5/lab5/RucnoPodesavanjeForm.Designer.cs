namespace lab5
{
    partial class RucnoPodesavanjeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RucnoPodesavanjeForm));
            this.nudVisina = new System.Windows.Forms.NumericUpDown();
            this.nudSirina = new System.Windows.Forms.NumericUpDown();
            this.nudBrMina = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudVisina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSirina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrMina)).BeginInit();
            this.SuspendLayout();
            // 
            // nudVisina
            // 
            this.nudVisina.Location = new System.Drawing.Point(77, 32);
            this.nudVisina.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudVisina.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudVisina.Name = "nudVisina";
            this.nudVisina.Size = new System.Drawing.Size(55, 20);
            this.nudVisina.TabIndex = 0;
            this.nudVisina.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // nudSirina
            // 
            this.nudSirina.Location = new System.Drawing.Point(77, 58);
            this.nudSirina.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudSirina.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudSirina.Name = "nudSirina";
            this.nudSirina.Size = new System.Drawing.Size(55, 20);
            this.nudSirina.TabIndex = 1;
            this.nudSirina.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // nudBrMina
            // 
            this.nudBrMina.Location = new System.Drawing.Point(77, 84);
            this.nudBrMina.Maximum = new decimal(new int[] {
            667,
            0,
            0,
            0});
            this.nudBrMina.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBrMina.Name = "nudBrMina";
            this.nudBrMina.Size = new System.Drawing.Size(55, 20);
            this.nudBrMina.TabIndex = 2;
            this.nudBrMina.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Visina:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Širina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Br. mina:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(159, 34);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(159, 69);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(62, 30);
            this.btnOdustani.TabIndex = 7;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // RucnoPodesavanjeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 146);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudBrMina);
            this.Controls.Add(this.nudSirina);
            this.Controls.Add(this.nudVisina);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RucnoPodesavanjeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ručno Podešavanje";
            ((System.ComponentModel.ISupportInitialize)(this.nudVisina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSirina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrMina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudVisina;
        private System.Windows.Forms.NumericUpDown nudSirina;
        private System.Windows.Forms.NumericUpDown nudBrMina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnOdustani;
    }
}