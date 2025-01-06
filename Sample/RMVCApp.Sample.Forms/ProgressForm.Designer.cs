namespace RMVCApp.Forms {
    partial class ProgressForm {
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
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            progressView = new ProgressView();
            SuspendLayout();
            // 
            // progressView
            // 
            progressView.Dock = DockStyle.Fill;
            progressView.Location = new Point(0, 0);
            progressView.Name = "progressView";
            progressView.Size = new Size(784, 461);
            progressView.TabIndex = 0;
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            ControlBox = false;
            Controls.Add(progressView);
            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(800, 500);
            Name = "ProgressForm";
            Text = "ProgressForm";
            ResumeLayout(false);
        }

        #endregion

        private ProgressView progressView;
    }
}