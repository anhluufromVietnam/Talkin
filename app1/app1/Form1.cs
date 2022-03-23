
namespace app1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

            var process = new System.Diagnostics.Process();

            process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = fileName };
            process.Start();
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
    }
}