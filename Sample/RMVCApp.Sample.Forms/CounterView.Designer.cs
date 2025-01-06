namespace RMVCApp.Forms {
    partial class CounterView {
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
            currentCountLabel = new Label();
            SuspendLayout();
            // 
            // testButton
            // 
            testButton.Location = new Point(26, 105);
            testButton.Name = "testButton";
            testButton.Size = new Size(75, 23);
            testButton.TabIndex = 5;
            testButton.Text = "Click me";
            testButton.UseVisualStyleBackColor = true;
            testButton.Click += testButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 65);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Current Count:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 45);
            label1.TabIndex = 3;
            label1.Text = "Counter";
            // 
            // currentCountLabel
            // 
            currentCountLabel.AutoSize = true;
            currentCountLabel.Location = new Point(118, 65);
            currentCountLabel.Name = "currentCountLabel";
            currentCountLabel.Size = new Size(13, 15);
            currentCountLabel.TabIndex = 6;
            currentCountLabel.Text = "0";
            // 
            // CounterView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(currentCountLabel);
            Controls.Add(testButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CounterView";
            Size = new Size(681, 392);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button testButton;
        private Label label2;
        private Label label1;
        private Label currentCountLabel;
    }
}
