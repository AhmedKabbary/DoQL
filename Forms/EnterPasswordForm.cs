namespace DoQL.Forms
{
    public partial class EnterPasswordForm : Form
    {
        public string Password { get; set; }

        public EnterPasswordForm()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Password = txtPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
