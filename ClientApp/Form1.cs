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
                labelError1.Text += "Необходимо ввести марку автомобиля.\n";
            }

            try
            {
                short year = short.Parse(textBoxYear.Text);
            }
            catch (Exception)
            {
                labelError1.Text += "Некоррекно указан год.\n";
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
                    labelError1.Text += "Некоррекно указан объем двигателя.\n";
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
                    labelError1.Text += "Некоррекно указано количество дверей.\n";
                }
            }

            if (labelError1.Text!="")
            {
                labelError1.Text += "\nПовторите ввод и нажмите \"Отправить\".";
                labelError1.ForeColor = Color.DarkOrange;
            }
            else
            {


                labelError1.Text += $"Марка: {textBoxBrend.Text}\n" +
                                    $"Год выпуска: {textBoxYear.Text}\n" +
                                    $"Объем двигателя: {textBoxEngine.Text}\n" +
                                    $"Количество дверей: {textBoxDors.Text}\n" +
                                    $"\nДанные успешно добавлены.";

                textBoxBrend.Text = "";
                textBoxYear.Text = "";
                textBoxEngine.Text = "";
                textBoxDors.Text = "";

                labelError1.ForeColor = Color.Green;
            }

        }
    }
}