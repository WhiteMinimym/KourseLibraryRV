
namespace KourseLibraryRV
{
    partial class Vudano_Vsiem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vudano_Vsiem));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.vudachiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kourseWorkDataSet = new KourseLibraryRV.KourseWorkDataSet();
            this.vudachiaTableAdapter = new KourseLibraryRV.KourseWorkDataSetTableAdapters.VudachiaTableAdapter();
            this.vudachiaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.autorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.autorTableAdapter = new KourseLibraryRV.KourseWorkDataSetTableAdapters.AutorTableAdapter();
            this.r5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.autor_BookTableAdapter = new KourseLibraryRV.KourseWorkDataSetTableAdapters.Autor_BookTableAdapter();
            this.vudachiaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.kourseWorkDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vudachiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kourseWorkDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vudachiaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vudachiaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kourseWorkDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(370, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(118, 22);
            this.toolStripButton1.Text = "Заполнить таблицу";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // vudachiaBindingSource
            // 
            this.vudachiaBindingSource.DataMember = "Vudachia";
            this.vudachiaBindingSource.DataSource = this.kourseWorkDataSet;
            // 
            // kourseWorkDataSet
            // 
            this.kourseWorkDataSet.DataSetName = "KourseWorkDataSet";
            this.kourseWorkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vudachiaTableAdapter
            // 
            this.vudachiaTableAdapter.ClearBeforeFill = true;
            // 
            // vudachiaBindingSource1
            // 
            this.vudachiaBindingSource1.DataMember = "Vudachia";
            this.vudachiaBindingSource1.DataSource = this.kourseWorkDataSet;
            // 
            // autorBindingSource
            // 
            this.autorBindingSource.DataMember = "Autor";
            this.autorBindingSource.DataSource = this.kourseWorkDataSet;
            // 
            // autorTableAdapter
            // 
            this.autorTableAdapter.ClearBeforeFill = true;
            // 
            // r5BindingSource
            // 
            this.r5BindingSource.DataMember = "R_5";
            this.r5BindingSource.DataSource = this.autorBindingSource;
            // 
            // autor_BookTableAdapter
            // 
            this.autor_BookTableAdapter.ClearBeforeFill = true;
            // 
            // vudachiaBindingSource2
            // 
            this.vudachiaBindingSource2.DataMember = "Vudachia";
            this.vudachiaBindingSource2.DataSource = this.kourseWorkDataSet;
            // 
            // kourseWorkDataSetBindingSource
            // 
            this.kourseWorkDataSetBindingSource.DataSource = this.kourseWorkDataSet;
            this.kourseWorkDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.DataSource = this.kourseWorkDataSetBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(370, 214);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ReadCardNum";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "HowManyBooks";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Vudano_Vsiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 239);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Vudano_Vsiem";
            this.Text = "AllDiagramm";
            this.Load += new System.EventHandler(this.AllDiagramm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vudachiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kourseWorkDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vudachiaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vudachiaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kourseWorkDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private KourseWorkDataSet kourseWorkDataSet;
        private System.Windows.Forms.BindingSource vudachiaBindingSource;
        private KourseWorkDataSetTableAdapters.VudachiaTableAdapter vudachiaTableAdapter;
        private System.Windows.Forms.BindingSource vudachiaBindingSource1;
        private System.Windows.Forms.BindingSource autorBindingSource;
        private KourseWorkDataSetTableAdapters.AutorTableAdapter autorTableAdapter;
        private System.Windows.Forms.BindingSource r5BindingSource;
        private KourseWorkDataSetTableAdapters.Autor_BookTableAdapter autor_BookTableAdapter;
        private System.Windows.Forms.BindingSource vudachiaBindingSource2;
        private System.Windows.Forms.BindingSource kourseWorkDataSetBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}