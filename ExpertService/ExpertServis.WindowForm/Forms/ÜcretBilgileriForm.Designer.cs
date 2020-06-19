namespace ExpertServis.WindowForm.Forms
{
    partial class ÜcretBilgileriForm
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
            this.listeUcretler = new DevExpress.XtraEditors.ListBoxControl();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.footer1 = new ExpertServis.WindowForm.Forms.Footer();
            ((System.ComponentModel.ISupportInitialize)(this.listeUcretler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // listeUcretler
            // 
            this.listeUcretler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeUcretler.Location = new System.Drawing.Point(146, 11);
            this.listeUcretler.Name = "listeUcretler";
            this.listeUcretler.Size = new System.Drawing.Size(212, 271);
            this.listeUcretler.TabIndex = 4;
            // 
            // txtTutar
            // 
            this.txtTutar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTutar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTutar.Location = new System.Drawing.Point(191, 286);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Properties.Mask.EditMask = "c2";
            this.txtTutar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTutar.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTutar.Size = new System.Drawing.Size(167, 20);
            this.txtTutar.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Location = new System.Drawing.Point(146, 289);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Tutar :";
            // 
            // footer1
            // 
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 356);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(523, 80);
            this.footer1.TabIndex = 5;
            // 
            // ÜcretBilgileriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.listeUcretler);
            this.Name = "ÜcretBilgileriForm";
            this.Size = new System.Drawing.Size(523, 436);
            this.Load += new System.EventHandler(this.ÜcretBilgileriForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listeUcretler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listeUcretler;
        private Footer footer1;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
