
namespace KourseLibraryRV
{
    partial class Sklad
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.invNBookDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.libNBookDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otmetkaPrisutstviaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.howManyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookFondBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kourseWorkDataSet = new KourseLibraryRV.KourseWorkDataSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.book_FondTableAdapter = new KourseLibraryRV.KourseWorkDataSetTableAdapters.Book_FondTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookFondBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kourseWorkDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Для обновления выключите форму и включите её ещё раз";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invNBookDataGridViewTextBoxColumn,
            this.libNBookDataGridViewTextBoxColumn,
            this.otmetkaPrisutstviaDataGridViewTextBoxColumn,
            this.howManyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bookFondBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 423);
            this.dataGridView1.TabIndex = 11;
            // 
            // invNBookDataGridViewTextBoxColumn
            // 
            this.invNBookDataGridViewTextBoxColumn.DataPropertyName = "InvNBook";
            this.invNBookDataGridViewTextBoxColumn.HeaderText = "InvNBook";
            this.invNBookDataGridViewTextBoxColumn.Name = "invNBookDataGridViewTextBoxColumn";
            // 
            // libNBookDataGridViewTextBoxColumn
            // 
            this.libNBookDataGridViewTextBoxColumn.DataPropertyName = "LibNBook";
            this.libNBookDataGridViewTextBoxColumn.HeaderText = "LibNBook";
            this.libNBookDataGridViewTextBoxColumn.Name = "libNBookDataGridViewTextBoxColumn";
            // 
            // otmetkaPrisutstviaDataGridViewTextBoxColumn
            // 
            this.otmetkaPrisutstviaDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaPrisutstvia";
            this.otmetkaPrisutstviaDataGridViewTextBoxColumn.HeaderText = "OtmetkaPrisutstvia";
            this.otmetkaPrisutstviaDataGridViewTextBoxColumn.Name = "otmetkaPrisutstviaDataGridViewTextBoxColumn";
            // 
            // howManyDataGridViewTextBoxColumn
            // 
            this.howManyDataGridViewTextBoxColumn.DataPropertyName = "HowMany";
            this.howManyDataGridViewTextBoxColumn.HeaderText = "HowMany";
            this.howManyDataGridViewTextBoxColumn.Name = "howManyDataGridViewTextBoxColumn";
            // 
            // bookFondBindingSource
            // 
            this.bookFondBindingSource.DataMember = "Book_Fond";
            this.bookFondBindingSource.DataSource = this.kourseWorkDataSet;
            // 
            // kourseWorkDataSet
            // 
            this.kourseWorkDataSet.DataSetName = "KourseWorkDataSet";
            this.kourseWorkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // book_FondTableAdapter
            // 
            this.book_FondTableAdapter.ClearBeforeFill = true;
            // 
            // Sklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Sklad";
            this.Text = "Sklad";
            this.Load += new System.EventHandler(this.Sklad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookFondBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kourseWorkDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private KourseWorkDataSet kourseWorkDataSet;
        private System.Windows.Forms.BindingSource bookFondBindingSource;
        private KourseWorkDataSetTableAdapters.Book_FondTableAdapter book_FondTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn invNBookDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn libNBookDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otmetkaPrisutstviaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn howManyDataGridViewTextBoxColumn;
    }
}