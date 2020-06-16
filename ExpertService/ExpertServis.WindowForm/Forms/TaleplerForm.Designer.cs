namespace ExpertServis.WindowForm.Forms
{
    partial class TaleplerForm
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
            this.chckHesapla = new DevExpress.XtraEditors.CheckEdit();
            this.lisTalepTipi = new DevExpress.XtraEditors.ListBoxControl();
            this.footer1 = new ExpertServis.WindowForm.Forms.Footer();
            ((System.ComponentModel.ISupportInitialize)(this.chckHesapla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lisTalepTipi)).BeginInit();
            this.SuspendLayout();
            // 
            // chckHesapla
            // 
            this.chckHesapla.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chckHesapla.Location = new System.Drawing.Point(140, 16);
            this.chckHesapla.Name = "chckHesapla";
            this.chckHesapla.Properties.Caption = "Hesaplansın mı?";
            this.chckHesapla.Size = new System.Drawing.Size(180, 18);
            this.chckHesapla.TabIndex = 2;
            // 
            // lisTalepTipi
            // 
            this.lisTalepTipi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lisTalepTipi.Location = new System.Drawing.Point(140, 40);
            this.lisTalepTipi.Name = "lisTalepTipi";
            this.lisTalepTipi.Size = new System.Drawing.Size(212, 271);
            this.lisTalepTipi.TabIndex = 3;
            // 
            // footer1
            // 
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 317);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(500, 53);
            this.footer1.TabIndex = 1;
            // 
            // TaleplerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lisTalepTipi);
            this.Controls.Add(this.chckHesapla);
            this.Controls.Add(this.footer1);
            this.Name = "TaleplerForm";
            this.Size = new System.Drawing.Size(500, 370);
            this.Load += new System.EventHandler(this.TaleplerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chckHesapla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lisTalepTipi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Footer footer1;
        private DevExpress.XtraEditors.CheckEdit chckHesapla;
        private DevExpress.XtraEditors.ListBoxControl lisTalepTipi;
    }
}
