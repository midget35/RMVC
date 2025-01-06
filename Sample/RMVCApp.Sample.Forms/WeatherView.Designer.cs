namespace RMVCApp.Forms {
    partial class WeatherView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                HandleDisposing();
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            DateColumn = new DataGridViewTextBoxColumn();
            TempCColumn = new DataGridViewTextBoxColumn();
            TempFColumn = new DataGridViewTextBoxColumn();
            SummaryColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 65);
            label2.Name = "label2";
            label2.Size = new Size(245, 15);
            label2.TabIndex = 9;
            label2.Text = "This component demonstrates showing data.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 45);
            label1.TabIndex = 8;
            label1.Text = "Weather";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { DateColumn, TempCColumn, TempFColumn, SummaryColumn });
            dataGridView1.Location = new Point(26, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(420, 154);
            dataGridView1.TabIndex = 10;
            // 
            // DateColumn
            // 
            DateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateColumn.HeaderText = "Date";
            DateColumn.Name = "DateColumn";
            DateColumn.ReadOnly = true;
            // 
            // TempCColumn
            // 
            TempCColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TempCColumn.HeaderText = "Temp. (C)";
            TempCColumn.Name = "TempCColumn";
            TempCColumn.ReadOnly = true;
            // 
            // TempFColumn
            // 
            TempFColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TempFColumn.HeaderText = "Temp. (F)";
            TempFColumn.Name = "TempFColumn";
            TempFColumn.ReadOnly = true;
            // 
            // SummaryColumn
            // 
            SummaryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SummaryColumn.HeaderText = "Summary";
            SummaryColumn.Name = "SummaryColumn";
            SummaryColumn.ReadOnly = true;
            // 
            // WeatherView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WeatherView";
            Size = new Size(473, 278);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn DateColumn;
        private DataGridViewTextBoxColumn TempCColumn;
        private DataGridViewTextBoxColumn TempFColumn;
        private DataGridViewTextBoxColumn SummaryColumn;
    }
}
