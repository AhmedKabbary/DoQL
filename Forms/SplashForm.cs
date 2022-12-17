using Timer = System.Windows.Forms.Timer;
namespace DoQL.Forms
{
    public partial class SplashForm : Form
    {
        Timer MyTimer;
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            MyTimer = new Timer();
            MyTimer.Interval = (3000);
            MyTimer.Tick += new EventHandler(OnTimedEvent);
            MyTimer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            MyTimer.Stop();
            DatabasesForm df = new DatabasesForm();
            df.FormClosed += Df_FormClosed;
            df.Show();
            this.Hide();
        }

        private void Df_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
