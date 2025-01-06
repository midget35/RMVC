using RMVC;

namespace RMVCApp.Forms {
    public partial class ProgressUI : UserControl {
        public ProgressUI() {
            InitializeComponent();
        }

        public void SetUI(RProgress progress, bool isPrimary) {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => SetUI(progress, isPrimary)));
                return;
            }

            // Set the background color based on primary status
            this.BackColor = isPrimary ? Color.White : DefaultBackColor;

            // Update UI elements with progress information
            percentLabel.Text = $"{progress.Percent} %";
            titleLabel.Text = progress.Heading;
            actionLabel.Text = progress.Message;
            progressBar.Value = progress.Percent;
        }
    }
}
