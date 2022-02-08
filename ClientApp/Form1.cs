namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSendDataToServer_Click(object sender, EventArgs e)
        {
            labelError1.Text = "";


            string brend = textBoxBrend.Text;
            if (brend=="")
            {
                labelError1.Text += "���������� ������ ����� ����������.\n";
            }

            try
            {
                short year = short.Parse(textBoxYear.Text);
            }
            catch (Exception)
            {
                labelError1.Text += "���������� ������ ���.\n";
            }

            if (textBoxEngine.Text!="")
            {
                if (textBoxEngine.Text.Contains("."))
                {
                    textBoxEngine.Text = textBoxEngine.Text.Replace(".",",");
                }
                try
                {
                    float engine = float.Parse(textBoxEngine.Text);
                }
                catch (Exception)
                {
                    labelError1.Text += "���������� ������ ����� ���������.\n";
                }
            }

            if (textBoxDors.Text!="")
            {
                try
                {
                    byte dors = byte.Parse(textBoxDors.Text);
                }
                catch (Exception)
                {
                    labelError1.Text += "���������� ������� ���������� ������.\n";
                }
            }

            if (labelError1.Text!="")
            {
                labelError1.Text += "\n��������� ���� � ������� \"���������\".";
                labelError1.ForeColor = Color.DarkOrange;
            }
            else
            {


                labelError1.Text += $"�����: {textBoxBrend.Text}\n" +
                                    $"��� �������: {textBoxYear.Text}\n" +
                                    $"����� ���������: {textBoxEngine.Text}\n" +
                                    $"���������� ������: {textBoxDors.Text}\n" +
                                    $"\n������ ������� ���������.";

                textBoxBrend.Text = "";
                textBoxYear.Text = "";
                textBoxEngine.Text = "";
                textBoxDors.Text = "";

                labelError1.ForeColor = Color.Green;
            }

        }
    }
}