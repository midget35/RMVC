namespace RMVCApp.Forms {
    partial class HomeView {
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
            testButton = new Button();
            label2 = new Label();
            label1 = new Label();
            rmvcProgressBtn = new Button();
            SuspendLayout();
            // 
            // testButton
            // 
            testButton.Location = new Point(26, 105);
            testButton.Name = "testButton";
            testButton.Size = new Size(75, 23);
            testButton.TabIndex = 8;
            testButton.Text = "RMVC Test";
            testButton.UseVisualStyleBackColor = true;
            testButton.Click += testButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 65);
            label2.Name = "label2";
            label2.Size = new Size(149, 15);
            label2.TabIndex = 7;
            label2.Text = "Welcome to your new app.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(200, 45);
            label1.TabIndex = 6;
            label1.Text = "Hello, world!";
            // 
            // rmvcProgressBtn
            // 
            rmvcProgressBtn.Location = new Point(26, 134);
            rmvcProgressBtn.Name = "rmvcProgressBtn";
            rmvcProgressBtn.Size = new Size(124, 23);
            rmvcProgressBtn.TabIndex = 9;
            rmvcProgressBtn.Text = "RMVC Progress Test";
            rmvcProgressBtn.UseVisualStyleBackColor = true;
            rmvcProgressBtn.Click += rmvcProgressBtn_Click;
            // 
            // HomeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rmvcProgressBtn);
            Controls.Add(testButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HomeView";
            Size = new Size(413, 311);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button testButton;
        private Label label2;
        private Label label1;
        private Button rmvcProgressBtn;
    }
}
