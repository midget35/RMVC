namespace RMVCApp.Forms {
    partial class MainView {
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
            tabControl1 = new TabControl();
            homePage = new TabPage();
            homeView = new HomeView();
            counterPage = new TabPage();
            counterView = new CounterView();
            weatherPage = new TabPage();
            weatherView1 = new WeatherView();
            navigationView1 = new NavigationView();
            tabControl1.SuspendLayout();
            homePage.SuspendLayout();
            counterPage.SuspendLayout();
            weatherPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(homePage);
            tabControl1.Controls.Add(counterPage);
            tabControl1.Controls.Add(weatherPage);
            tabControl1.Location = new Point(258, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(480, 400);
            tabControl1.TabIndex = 0;
            // 
            // homePage
            // 
            homePage.Controls.Add(homeView);
            homePage.Location = new Point(4, 24);
            homePage.Name = "homePage";
            homePage.Padding = new Padding(3);
            homePage.Size = new Size(472, 372);
            homePage.TabIndex = 0;
            homePage.Text = "Home";
            homePage.UseVisualStyleBackColor = true;
            // 
            // homeView1
            // 
            homeView.Dock = DockStyle.Fill;
            homeView.Location = new Point(3, 3);
            homeView.Name = "homeView1";
            homeView.Size = new Size(466, 366);
            homeView.TabIndex = 0;
            // 
            // counterPage
            // 
            counterPage.Controls.Add(counterView);
            counterPage.Location = new Point(4, 24);
            counterPage.Name = "counterPage";
            counterPage.Padding = new Padding(3);
            counterPage.Size = new Size(472, 372);
            counterPage.TabIndex = 1;
            counterPage.Text = "Counter";
            counterPage.UseVisualStyleBackColor = true;
            // 
            // counterView
            // 
            counterView.Dock = DockStyle.Fill;
            counterView.Location = new Point(3, 3);
            counterView.Name = "counterView";
            counterView.Size = new Size(466, 366);
            counterView.TabIndex = 0;
            // 
            // weatherPage
            // 
            weatherPage.Controls.Add(weatherView1);
            weatherPage.Location = new Point(4, 24);
            weatherPage.Name = "weatherPage";
            weatherPage.Size = new Size(472, 372);
            weatherPage.TabIndex = 2;
            weatherPage.Text = "Weather";
            weatherPage.UseVisualStyleBackColor = true;
            // 
            // weatherView1
            // 
            weatherView1.Dock = DockStyle.Fill;
            weatherView1.Location = new Point(0, 0);
            weatherView1.Name = "weatherView1";
            weatherView1.Size = new Size(472, 372);
            weatherView1.TabIndex = 0;
            // 
            // navigationView1
            // 
            navigationView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            navigationView1.BorderStyle = BorderStyle.FixedSingle;
            navigationView1.Location = new Point(3, 3);
            navigationView1.Name = "navigationView1";
            navigationView1.Size = new Size(249, 396);
            navigationView1.TabIndex = 1;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(navigationView1);
            Controls.Add(tabControl1);
            Name = "MainView";
            Size = new Size(741, 406);
            tabControl1.ResumeLayout(false);
            homePage.ResumeLayout(false);
            counterPage.ResumeLayout(false);
            weatherPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage homePage;
        private TabPage counterPage;
        private TabPage weatherPage;
        private CounterView counterView;
        private WeatherView weatherView1;
        private HomeView homeView;
        private NavigationView navigationView1;
    }
}
