
namespace app1
{
    public partial class Form1 : Form
    {
        int p = 0;
        public Form1()
        {
            InitializeComponent();
        }


        System.Diagnostics.Process process = new System.Diagnostics.Process();

        private void label1_Click(object sender, EventArgs e)
        {

        }
        [STAThread]
        private void talkbtn_Click(object sender, EventArgs e)
        {
            string fileName = "talk.vbs";

            string texting = "";

            char spacing = (char)10;

            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                if (richTextBox1.Text[i] == spacing) texting += ". ";
                else texting += richTextBox1.Text[i];
            }

            //richTextBox1.Text = texting;

            File.WriteAllText(fileName,"Createobject(" + '"' + "SAPI.Spvoice" + '"' + ").speak" + '"' + texting + '"');

            if (process.StartInfo.FileName != fileName) process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = fileName };
            process.Start();
            p = 1;
            //p = 0;
        }

        private void richTextBox1_TextChanged(object sender, MouseEventArgs e)
        {
            //richTextBox1.Text = e.Button.ToString();
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                richTextBox1.Text = clipboardText;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                    richTextBox1.Text = clipboardText;
                }
                //richTextBox1.Text = getstri
            }
            else//left or middle click
            {
                //do something here
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //System.Console.WriteLine("ANCAC: ",process.StartInfo);
            try
            {
                if (process.HasExited == true)
                {
                    pictureBox1.Image = app1.Properties.Resources._0;
                }
                if (process.HasExited == false) if (p > 0)
                    {
                        if (p == 1) pictureBox1.Image = app1.Properties.Resources._1;
                        if (p == 2) pictureBox1.Image = app1.Properties.Resources._2;
                        if (p == 3) pictureBox1.Image = app1.Properties.Resources._3;
                        if (p == 4) pictureBox1.Image = app1.Properties.Resources._4;
                        if (p == 5) pictureBox1.Image = app1.Properties.Resources._5;
                        if (p == 6)
                        {
                            pictureBox1.Image = app1.Properties.Resources._6;
                            p = 0;
                        }
                        p++;
                    }
            }
            catch
            {
                pictureBox1.Image = app1.Properties.Resources._0;
            }
        }
    }
}