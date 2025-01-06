namespace RMVCApp.Forms {
    partial class NavigationView {
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
            appNameLabel = new Label();
            homeLink = new LinkLabel();
            counterLink = new LinkLabel();
            weatherLink = new LinkLabel();
            SuspendLayout();
            // 
            // appNameLabel
            // 
            appNameLabel.AutoSize = true;
            appNameLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appNameLabel.Location = new Point(0, 0);
            appNameLabel.Name = "appNameLabel";
            appNameLabel.Size = new Size(193, 45);
            appNameLabel.TabIndex = 7;
            appNameLabel.Text = "[App Name]";
            // 
            // homeLink
            // 
            homeLink.AutoSize = true;
            homeLink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeLink.Location = new Point(25, 60);
            homeLink.Name = "homeLink";
            homeLink.Size = new Size(52, 21);
            homeLink.TabIndex = 8;
            homeLink.TabStop = true;
            homeLink.Text = "Home";
            homeLink.LinkClicked += homeLink_LinkClicked;
            // 
            // counterLink
            // 
            counterLink.AutoSize = true;
            counterLink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            counterLink.Location = new Point(25, 98);
            counterLink.Name = "counterLink";
            counterLink.Size = new Size(66, 21);
            counterLink.TabIndex = 9;
            counterLink.TabStop = true;
            counterLink.Text = "Counter";
            counterLink.LinkClicked += counterLink_LinkClicked;
            // 
            // weatherLink
            // 
            weatherLink.AutoSize = true;
            weatherLink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            weatherLink.Location = new Point(25, 136);
            weatherLink.Name = "weatherLink";
            weatherLink.Size = new Size(68, 21);
            weatherLink.TabIndex = 10;
            weatherLink.TabStop = true;
            weatherLink.Text = "Weather";
            weatherLink.LinkClicked += weatherLink_LinkClicked;
            // 
            // NavigationView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(weatherLink);
            Controls.Add(counterLink);
            Controls.Add(homeLink);
            Controls.Add(appNameLabel);
            Name = "NavigationView";
            Size = new Size(214, 432);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appNameLabel;
        private LinkLabel homeLink;
        private LinkLabel counterLink;
        private LinkLabel weatherLink;
    }
}
