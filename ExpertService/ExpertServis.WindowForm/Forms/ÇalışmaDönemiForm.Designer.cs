namespace ExpertServis.WindowForm.Forms
{
    partial class ÇalışmaDönemiForm
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.chckKıdem = new DevExpress.XtraEditors.CheckEdit();
            this.chckİhbar = new DevExpress.XtraEditors.CheckEdit();
            this.chckFazlaMesai = new DevExpress.XtraEditors.CheckEdit();
            this.footer1 = new ExpertServis.WindowForm.Forms.Footer();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.dateFinish = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chckKıdem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckİhbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckFazlaMesai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl5.Location = new System.Drawing.Point(53, 40);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(116, 13);
            this.labelControl5.TabIndex = 60;
            this.labelControl5.Text = "İşe Başlama Tarihi :";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl6.Location = new System.Drawing.Point(63, 64);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(106, 13);
            this.labelControl6.TabIndex = 61;
            this.labelControl6.Text = "İşten Çıkış Tarihi :";
            // 
            // chckKıdem
            // 
            this.chckKıdem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chckKıdem.Location = new System.Drawing.Point(175, 93);
            this.chckKıdem.Name = "chckKıdem";
            this.chckKıdem.Properties.Caption = "Kıdem tazminatı alındı mı?";
            this.chckKıdem.Size = new System.Drawing.Size(188, 18);
            this.chckKıdem.TabIndex = 64;
            // 
            // chckİhbar
            // 
            this.chckİhbar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chckİhbar.Location = new System.Drawing.Point(175, 117);
            this.chckİhbar.Name = "chckİhbar";
            this.chckİhbar.Properties.Caption = "İhbar tazminatı alındı mı?";
            this.chckİhbar.Size = new System.Drawing.Size(188, 18);
            this.chckİhbar.TabIndex = 65;
            // 
            // chckFazlaMesai
            // 
            this.chckFazlaMesai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chckFazlaMesai.Location = new System.Drawing.Point(175, 141);
            this.chckFazlaMesai.Name = "chckFazlaMesai";
            this.chckFazlaMesai.Properties.Caption = "Fazla Mesai Alındı mı?";
            this.chckFazlaMesai.Size = new System.Drawing.Size(188, 18);
            this.chckFazlaMesai.TabIndex = 67;
            // 
            // footer1
            // 
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 205);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(458, 58);
            this.footer1.TabIndex = 66;
            // 
            // dateStart
            // 
            this.dateStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(175, 37);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Size = new System.Drawing.Size(163, 20);
            this.dateStart.TabIndex = 68;
            // 
            // dateFinish
            // 
            this.dateFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateFinish.EditValue = null;
            this.dateFinish.Location = new System.Drawing.Point(175, 61);
            this.dateFinish.Name = "dateFinish";
            this.dateFinish.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFinish.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFinish.Size = new System.Drawing.Size(163, 20);
            this.dateFinish.TabIndex = 69;
            // 
            // ÇalışmaDönemiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateFinish);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.chckFazlaMesai);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.chckİhbar);
            this.Controls.Add(this.chckKıdem);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl6);
            this.Name = "ÇalışmaDönemiForm";
            this.Size = new System.Drawing.Size(458, 263);
            this.Load += new System.EventHandler(this.ÇalışmaDönemiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chckKıdem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckİhbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chckFazlaMesai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit chckKıdem;
        private DevExpress.XtraEditors.CheckEdit chckİhbar;
        private Footer footer1;
        private DevExpress.XtraEditors.CheckEdit chckFazlaMesai;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.DateEdit dateFinish;
    }
}
