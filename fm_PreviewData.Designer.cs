namespace DatabaseManageBar
{
    partial class fm_PreviewData
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
            this.cbb_TableNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_TableNames
            // 
            this.cbb_TableNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TableNames.FormattingEnabled = true;
            this.cbb_TableNames.Location = new System.Drawing.Point(147, 30);
            this.cbb_TableNames.Name = "cbb_TableNames";
            this.cbb_TableNames.Size = new System.Drawing.Size(198, 20);
            this.cbb_TableNames.TabIndex = 17;
            this.cbb_TableNames.SelectedIndexChanged += new System.EventHandler(this.cbb_TableNames_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "选择要导入的表格：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(674, 405);
            this.dataGridView1.TabIndex = 18;
            // 
            // fm_PreviewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 488);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbb_TableNames);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "fm_PreviewData";
            this.Text = "预览数据";
            this.Load += new System.EventHandler(this.fm_PreviewData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_TableNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}