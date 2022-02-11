namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxForServerData.ReadOnly = true;
        }

        // обработчик кнопки отправки данных на сервер
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
                SendData sendData = new SendData();

                string dataStrForServer = getDataForServer.GetDataStrForSerever(brend, year, engine, dors);
                sendData.SendDataForServer(dataStrForServer);
                
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

        // обработчик кнопки получения данных по id
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

                textBoxForServerData.Text = "";
                if (serverDataArr == null)
                {
                    textBoxForServerData.Text += $"Данные по Id {id} отсутствуют";
                }
                else
                {
                    textBoxForServerData.Text += "Получены данные:\r\n\r\n";
                    textBoxForServerData.Text += $"Id: {serverDataArr[0]}\r\n";
                    textBoxForServerData.Text += $"Количество типов: {serverDataArr[1]}\r\n";
                    textBoxForServerData.Text += $"Марка: {serverDataArr[2]}\r\n";
                    textBoxForServerData.Text += $"Год выпуска: {serverDataArr[3]}\r\n";
                    if (serverDataArr[4]!="0")
                    {
                        textBoxForServerData.Text += $"Объем двигателя: {serverDataArr[4]}\r\n";
                    }
                    if (serverDataArr[5] != "0")
                    {
                        textBoxForServerData.Text += $"Количество дверей: {serverDataArr[5]}\r\n";
                    }
                    
                    saveXml.SaveXmlForId(serverDataArr);
                }
            }
            else
            {
                labelError2.Text = "Некорректный ввод Id";
            }     
        }

        // обработчик кнопки получения всех данных
        private void buttonGetAllData_Click(object sender, EventArgs e)
        {
            SendData sendData = new SendData();
            SaveXml saveXml = new SaveXml();
            string[] serverDataArr = sendData.GetAllDataToServer();

            textBoxForServerData.Text = "";
            if (serverDataArr == null)
            {
                textBoxForServerData.Text += $"Данные отсутствуют, добавьте данные";
            }
            else
            {
                textBoxForServerData.Text += "Получены данные:\r\n\r\n";

                for (int i = 0; i < serverDataArr.Length; i++)
                {
                    string[] tempArr = serverDataArr[i].Split("*");
                    textBoxForServerData.Text += $"Id: {tempArr[0]}\r\n";
                    textBoxForServerData.Text += $"Количество типов: {tempArr[1]}\r\n";
                    textBoxForServerData.Text += $"Марка: {tempArr[2]}\r\n";
                    textBoxForServerData.Text += $"Год выпуска: {tempArr[3]}\r\n";
                    if (tempArr[4] != "0")
                    {
                        textBoxForServerData.Text += $"Объем двигателя: {tempArr[4]}\r\n";
                    }
                    if (tempArr[5] != "0")
                    {
                        textBoxForServerData.Text += $"Количество дверей: {tempArr[5]}\r\n";
                    }
                    textBoxForServerData.Text += "\r\n";
                }
                saveXml.SaveXmlForAllData(serverDataArr);
            }
        }
    }
}