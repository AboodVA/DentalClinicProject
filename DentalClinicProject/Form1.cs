namespace DentalClinicProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void goToHomePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePageForm form = new HomePageForm();
            form.Show();
            this.Hide();
             
        }
    }
}