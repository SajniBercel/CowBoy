namespace CowBoyBeta2_0
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Game = new Form1();
            Game.Visible = true;
            if (!checkBox1.Checked)
                Game.WindowSize = new Size(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()));
            else
                Game.WindowState = FormWindowState.Maximized;
            Game.Setup();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = !checkBox1.Checked;
            numericUpDown2.Enabled = !checkBox1.Checked;
        }
    }
}
