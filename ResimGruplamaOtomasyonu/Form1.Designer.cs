namespace ResimGruplamaOtomasyonu
{
    partial class Form1
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
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnSqlTest = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            btnResimleriListele = new DevExpress.XtraBars.BarButtonItem();
            btnResimEkle = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            btnResimSil = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            splitAna = new DevExpress.XtraEditors.SplitContainerControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            btnGrupla = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitAna).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitAna.Panel1).BeginInit();
            splitAna.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitAna.Panel2).BeginInit();
            splitAna.Panel2.SuspendLayout();
            splitAna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, btnSqlTest, barButtonItem2, btnResimleriListele, btnResimEkle, barButtonItem1, btnResimSil, btnGrupla });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            ribbonControl1.MaxItemId = 9;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 385;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(1106, 193);
            // 
            // btnSqlTest
            // 
            btnSqlTest.Caption = "SQL Test";
            btnSqlTest.Id = 1;
            btnSqlTest.Name = "btnSqlTest";
            btnSqlTest.ItemClick += btnSqlTest_ItemClick;
            // 
            // barButtonItem2
            // 
            barButtonItem2.Id = 2;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // btnResimleriListele
            // 
            btnResimleriListele.Caption = "Resimleri Listele";
            btnResimleriListele.Id = 3;
            btnResimleriListele.Name = "btnResimleriListele";
            btnResimleriListele.ItemClick += btnResimleriListele_ItemClick;
            // 
            // btnResimEkle
            // 
            btnResimEkle.Caption = "Resim Ekle";
            btnResimEkle.Id = 4;
            btnResimEkle.Name = "btnResimEkle";
            btnResimEkle.ItemClick += btnResimEkle_ItemClick;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Id = 6;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // btnResimSil
            // 
            btnResimSil.Caption = "Seçili Resmi Sil";
            btnResimSil.Id = 7;
            btnResimSil.Name = "btnResimSil";
            btnResimSil.ItemClick += btnResimSil_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnSqlTest);
            ribbonPageGroup1.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup1.ItemLinks.Add(btnResimleriListele);
            ribbonPageGroup1.ItemLinks.Add(btnResimEkle);
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.ItemLinks.Add(btnResimSil);
            ribbonPageGroup1.ItemLinks.Add(btnGrupla);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Veritabanı İşlemleri";
            ribbonPageGroup1.CaptionButtonClick += rpgVeritabani;
            // 
            // splitAna
            // 
            splitAna.Dock = System.Windows.Forms.DockStyle.Fill;
            splitAna.Location = new System.Drawing.Point(0, 193);
            splitAna.Name = "splitAna";
            // 
            // splitAna.Panel1
            // 
            splitAna.Panel1.Controls.Add(gridControl1);
            splitAna.Panel1.Text = "Panel1";
            // 
            // splitAna.Panel2
            // 
            splitAna.Panel2.Controls.Add(pictureEdit1);
            splitAna.Panel2.Text = "Panel2";
            splitAna.Size = new System.Drawing.Size(1106, 547);
            splitAna.SplitterPosition = 520;
            splitAna.TabIndex = 1;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbonControl1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(520, 547);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.Click += gridControl1_Click;
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1, gridColumn2, gridColumn3, gridColumn4, gridColumn5, gridColumn6 });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged_1;
            // 
            // gridColumn1
            // 
            gridColumn1.Caption = "Dosya Adı";
            gridColumn1.FieldName = "DosyaAdi";
            gridColumn1.MinWidth = 25;
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            gridColumn2.Caption = "Dosya Yolu";
            gridColumn2.FieldName = "DosyaYolu";
            gridColumn2.MinWidth = 25;
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            gridColumn3.Caption = "ID";
            gridColumn3.FieldName = "Id";
            gridColumn3.MinWidth = 25;
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "Hash (64)";
            gridColumn4.FieldName = "Hash64";
            gridColumn4.MinWidth = 25;
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Width = 94;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "Grup ID";
            gridColumn5.FieldName = "GrupId";
            gridColumn5.MinWidth = 25;
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Width = 94;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "Eklenme Tarihi";
            gridColumn6.FieldName = "EklenmeTarihi";
            gridColumn6.MinWidth = 25;
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Width = 94;
            // 
            // pictureEdit1
            // 
            pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureEdit1.Location = new System.Drawing.Point(0, 0);
            pictureEdit1.MenuManager = ribbonControl1;
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit1.Properties.NullText = "Önizleme yok";
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEdit1.Size = new System.Drawing.Size(574, 547);
            pictureEdit1.TabIndex = 0;
            pictureEdit1.EditValueChanged += pictureEdit1_EditValueChanged;
            // 
            // btnGrupla
            // 
            btnGrupla.Caption = "Benzerliğe Göre Grupla";
            btnGrupla.Id = 8;
            btnGrupla.Name = "btnGrupla";
            btnGrupla.ItemClick += btnGrupla_ItemClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1106, 740);
            Controls.Add(splitAna);
            Controls.Add(ribbonControl1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form1";
            Ribbon = ribbonControl1;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitAna.Panel1).EndInit();
            splitAna.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitAna.Panel2).EndInit();
            splitAna.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitAna).EndInit();
            splitAna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSqlTest;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnResimleriListele;
        private DevExpress.XtraEditors.SplitContainerControl splitAna;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraBars.BarButtonItem btnResimEkle;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnResimSil;
        private DevExpress.XtraBars.BarButtonItem btnGrupla;
    }
}

