namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxForServerData.ReadOnly = true;
        }

        // ���������� ������ �������� ������ �� ������
        private void buttonSendDataToServer_Click(object sender, EventArgs e)
        {
            string brend = textBoxBrend.Text;
            short year = 0;
            float engine = 0;
            byte dors = 0;

            labelError1.Text = "";
            
            if (brend=="")
            {
                labelError1.Text += "���������� ������ ����� ����������.\n";
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
                    engine = float.Parse(textBoxEngine.Text);
                    if (engine<0)
                    {
                        throw new Exception();
                    }
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
                    dors = byte.Parse(textBoxDors.Text);
                    if (dors<0 || dors>5)
                    {
                        throw new Exception();
                    }
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
                GetDataForServer getDataForServer = new GetDataForServer();
                SendData sendData = new SendData();

                string dataStrForServer = getDataForServer.GetDataStrForSerever(brend, year, engine, dors);
                sendData.SendDataForServer(dataStrForServer);
                
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

        // ���������� ������ ��������� ������ �� id
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
                    textBoxForServerData.Text += $"������ �� Id {id} �����������";
                }
                else
                {
                    textBoxForServerData.Text += "�������� ������:\r\n\r\n";
                    textBoxForServerData.Text += $"Id: {serverDataArr[0]}\r\n";
                    textBoxForServerData.Text += $"���������� �����: {serverDataArr[1]}\r\n";
                    textBoxForServerData.Text += $"�����: {serverDataArr[2]}\r\n";
                    textBoxForServerData.Text += $"��� �������: {serverDataArr[3]}\r\n";
                    if (serverDataArr[4]!="0")
                    {
                        textBoxForServerData.Text += $"����� ���������: {serverDataArr[4]}\r\n";
                    }
                    if (serverDataArr[5] != "0")
                    {
                        textBoxForServerData.Text += $"���������� ������: {serverDataArr[5]}\r\n";
                    }
                    
                    saveXml.SaveXmlForId(serverDataArr);
                }
            }
            else
            {
                labelError2.Text = "������������ ���� Id";
            }     
        }

        // ���������� ������ ��������� ���� ������
        private void buttonGetAllData_Click(object sender, EventArgs e)
        {
            SendData sendData = new SendData();
            SaveXml saveXml = new SaveXml();
            string[] serverDataArr = sendData.GetAllDataToServer();

            textBoxForServerData.Text = "";
            if (serverDataArr == null)
            {
                textBoxForServerData.Text += $"������ �����������, �������� ������";
            }
            else
            {
                textBoxForServerData.Text += "�������� ������:\r\n\r\n";

                for (int i = 0; i < serverDataArr.Length; i++)
                {
                    string[] tempArr = serverDataArr[i].Split("*");
                    textBoxForServerData.Text += $"Id: {tempArr[0]}\r\n";
                    textBoxForServerData.Text += $"���������� �����: {tempArr[1]}\r\n";
                    textBoxForServerData.Text += $"�����: {tempArr[2]}\r\n";
                    textBoxForServerData.Text += $"��� �������: {tempArr[3]}\r\n";
                    if (tempArr[4] != "0")
                    {
                        textBoxForServerData.Text += $"����� ���������: {tempArr[4]}\r\n";
                    }
                    if (tempArr[5] != "0")
                    {
                        textBoxForServerData.Text += $"���������� ������: {tempArr[5]}\r\n";
                    }
                    textBoxForServerData.Text += "\r\n";
                }
                saveXml.SaveXmlForAllData(serverDataArr);
            }
        }
    }
}