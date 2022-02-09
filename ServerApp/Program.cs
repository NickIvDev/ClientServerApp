// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp 
{
    
    public class Program
    {
        static int port = 8005; // порт для приема входящих запросов
        static AppDbContext db = new AppDbContext();
        public Program(AppDbContext _db)
        {
            db = _db;
        }
        public static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    // запрос на все данные
                    if (builder.ToString() == "allData")
                    {
                        Console.WriteLine($"Получен запрос на все данные: {DateTime.Now.ToString()}");
                        List<CarModel> carModels = db.CarModels.ToList();
                        builder = new StringBuilder();
                        if (carModels.Count()!=0)
                        {                         
                            for (int i = 0; i < carModels.Count-1; i++)
                            {
                                builder.Append($"{carModels[i].Id}*{carModels[i].Brend}*{carModels[i].Year}*{carModels[i].Engine}*{carModels[i].Dors}");
                                builder.Append("//");
                            }
                            int lastCount = carModels.Count-1;
                            builder.Append($"{carModels[lastCount].Id}*{carModels[lastCount].Brend}*{carModels[lastCount].Year}*{carModels[lastCount].Engine}*{carModels[lastCount].Dors}");
                        }
                        else
                        {
                            builder.Append("notData");
                        }                       
                    }
                    // запрос на данные по Id
                    else
                    {
                        int id = int.Parse(builder.ToString());
                        Console.WriteLine($"Получен запрос по id {id}: {DateTime.Now.ToString()}");

                        CarModel model = db.CarModels.FirstOrDefault(x => x.Id == id);
                        builder = new StringBuilder();
                        if (model != null)
                        {
                            builder.Append($"{model.Id}*{model.Brend}*{model.Year}*{model.Engine}*{model.Dors}");
                        }
                        else
                        {
                            builder.Append("notData");
                        }
                    }

                    //отправляем ответ
                    string dataStr = builder.ToString();
                    data = Encoding.Unicode.GetBytes(dataStr);
                    handler.Send(data);
                    //закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}