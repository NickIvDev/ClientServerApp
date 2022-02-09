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
            string brend = textBoxBrend.Text;
            short year = 0;
            float engine = 0;
            byte dors = 0;

            labelError1.Text = "";
            
            if (brend=="")
            {
                labelError1.Text += "Необходимо ввести марку автомобиля.\n";
            }

            try
            {               
                year = short.Parse(textBoxYear.Text);
                if (year>DateTime.Now.Year || year<1950)
                {
                    throw new Exception();
                }
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
                    engine = float.Parse(textBoxEngine.Text);
                    if (engine<0)
                    {
                        throw new Exception();
                    }
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
                    dors = byte.Parse(textBoxDors.Text);
                    if (dors<0 || dors>5)
                    {
                        throw new Exception();
                    }
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
                GetDataForServer getDataForServer = new GetDataForServer();
                //getDataForServer.GetStuctBytes(brend, year, engine, dors);
                

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

        private void buttonGetForId_Click(object sender, EventArgs e)
        {
            string id = textBoxGetForId.Text;
            int chekId = 1;
            try
            {
                int temp = int.Parse(id);
            }
            catch (Exception)
            {
                chekId = 0;
            }

            if (chekId == 1)
            {
                labelError2.Text = "";
                SendData sendData = new SendData();
                SaveXml saveXml = new SaveXml();
                string[] serverDataArr = sendData.GetDataToServerForId(id);

                labelForServerData.Text = "";
                if (serverDataArr == null)
                {
                    labelForServerData.Text += $"Данные по Id {id} отсутствуют";
                }
                else
                {
                    labelForServerData.Text += "Получены данные:\n";
                    labelForServerData.Text += $"Id: {serverDataArr[0]}\n";
                    labelForServerData.Text += $"Марка: {serverDataArr[1]}\n";
                    labelForServerData.Text += $"Год выпуска: {serverDataArr[2]}\n";
                    labelForServerData.Text += $"Объем двигателя: {serverDataArr[3]}\n";
                    labelForServerData.Text += $"Количество дверей: {serverDataArr[4]}\n";

                    saveXml.SaveXmlForId(serverDataArr);
                }
            }
            else
            {
                labelError2.Text = "Некорректный ввод Id";
            }     
        }

        private void buttonGetAllData_Click(object sender, EventArgs e)
        {
            SendData sendData = new SendData();
            SaveXml saveXml = new SaveXml();
            string[] serverDataArr = sendData.GetAllDataToServer();

            labelForServerData.Text = "";
            if (serverDataArr == null)
            {
                labelForServerData.Text += $"Данные отсутствуют, добавьте данные";
            }
            else
            {
                labelForServerData.Text += "Получены данные:\n";

                for (int i = 0; i < serverDataArr.Length; i++)
                {
                    string[] tempArr = serverDataArr[i].Split("*");
                    labelForServerData.Text += $"Id: {tempArr[0]}\n";
                    labelForServerData.Text += $"Марка: {tempArr[1]}\n";
                    labelForServerData.Text += $"Год выпуска: {tempArr[2]}\n";
                    labelForServerData.Text += $"Объем двигателя: {tempArr[3]}\n";
                    labelForServerData.Text += $"Количество дверей: {tempArr[4]}\n\n";
                }
                saveXml.SaveXmlForAllData(serverDataArr);
            }
        }
    }
}