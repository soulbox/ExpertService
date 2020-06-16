namespace ExpertServis.WindowForm.Forms
{
    partial class Footer
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
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btneAdd = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.ImageOptions.Image = global::ExpertServis.WindowForm.Properties.Resources.delete_32x32;
            this.btnDelete.Location = new System.Drawing.Point(215, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 55);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Sil";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.ImageOptions.Image = global::ExpertServis.WindowForm.Properties.Resources.recurrence_32x32;
            this.btnUpdate.Location = new System.Drawing.Point(114, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 55);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Güncelle";
            // 
            // btneAdd
            // 
            this.btneAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btneAdd.Appearance.Options.UseTextOptions = true;
            this.btneAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btneAdd.ImageOptions.Image = global::ExpertServis.WindowForm.Properties.Resources.add_32x321;
            this.btneAdd.Location = new System.Drawing.Point(13, 15);
            this.btneAdd.Name = "btneAdd";
            this.btneAdd.Size = new System.Drawing.Size(95, 55);
            this.btneAdd.TabIndex = 0;
            this.btneAdd.Text = "Ekle";
            this.btneAdd.Click += new System.EventHandler(this.btneAdd_Click);
            // 
            // Footer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btneAdd);
            this.Name = "Footer";
            this.Size = new System.Drawing.Size(330, 82);
            this.Load += new System.EventHandler(this.Footer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btneAdd;
        public DevExpress.XtraEditors.SimpleButton btnUpdate;
        public DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
