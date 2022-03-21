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

    }
}