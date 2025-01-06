namespace RMVCApp.Forms {
    partial class ProgressView {
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
            label1 = new Label();
            progressContainer = new FlowLayoutPanel();
            abortBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 1);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Progress View";
            // 
            // progressContainer
            // 
            progressContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressContainer.AutoScroll = true;
            progressContainer.FlowDirection = FlowDirection.TopDown;
            progressContainer.Location = new Point(3, 19);
            progressContainer.Name = "progressContainer";
            progressContainer.Size = new Size(718, 325);
            progressContainer.TabIndex = 2;
            progressContainer.WrapContents = false;
            // 
            // abortBtn
            // 
            abortBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            abortBtn.Location = new Point(518, 350);
            abortBtn.Name = "abortBtn";
            abortBtn.Size = new Size(200, 23);
            abortBtn.TabIndex = 3;
            abortBtn.Text = "Abort Progress";
            abortBtn.UseVisualStyleBackColor = true;
            abortBtn.Click += abortBtn_Click;
            // 
            // ProgressView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(abortBtn);
            Controls.Add(progressContainer);
            Controls.Add(label1);
            Name = "ProgressView";
            Size = new Size(721, 376);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel progressContainer;
        private Button abortBtn;
    }
}
