namespace GK1_PROJ4_FINAL
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void optionsRbutton_Click(object sender, EventArgs e)
        {
            ((RadioButton)sender).Checked = !((RadioButton)sender).Checked;
        }
    }
}