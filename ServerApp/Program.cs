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

                    // отправляем данные для записи в бд
                    if (builder.ToString() != "allData" && builder.ToString().Contains("*"))
                    {
                        Console.WriteLine($"Получены данные для записи в БД: {DateTime.Now.ToString()}");
                        string[] dataForCarModel = builder.ToString().Split('*');
                        CarModel model = new CarModel() 
                        {
                            CountTypes = byte.Parse(dataForCarModel[0]),
                            Brend = dataForCarModel[1],
                            Year = short.Parse(dataForCarModel[2]),
                            Engine = float.Parse(dataForCarModel[3]),
                            Dors = byte.Parse(dataForCarModel[4])
                        };
                        db.CarModels.Add(model);
                        db.SaveChanges();
                        Console.WriteLine($"Данные успешно записаны: {DateTime.Now.ToString()}");
                    }
                    // запрос на все данные
                    else if (builder.ToString() == "allData")
                    {
                        Console.WriteLine($"Получен запрос на все данные: {DateTime.Now.ToString()}");
                        List<CarModel> carModels = db.CarModels.ToList();
                        builder = new StringBuilder();
                        if (carModels.Count()!=0)
                        {                         
                            for (int i = 0; i < carModels.Count-1; i++)
                            {
                                builder.Append($"{carModels[i].Id}*{carModels[i].CountTypes}*{carModels[i].Brend}*{carModels[i].Year}*{carModels[i].Engine}*{carModels[i].Dors}");
                                builder.Append("//");
                            }
                            int lastCount = carModels.Count-1;
                            builder.Append($"{carModels[lastCount].Id}*{carModels[lastCount].CountTypes}*{carModels[lastCount].Brend}*{carModels[lastCount].Year}*{carModels[lastCount].Engine}*{carModels[lastCount].Dors}");
                            //отправляем ответ
                            string dataStr = builder.ToString();
                            data = Encoding.Unicode.GetBytes(dataStr);
                            handler.Send(data);
                        }
                        else
                        {
                            builder.Append("notData");
                            //отправляем ответ
                            string dataStr = builder.ToString();
                            data = Encoding.Unicode.GetBytes(dataStr);
                            handler.Send(data);
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
                            builder.Append($"{model.Id}*{model.CountTypes}*{model.Brend}*{model.Year}*{model.Engine}*{model.Dors}");
                            //отправляем ответ
                            string dataStr = builder.ToString();
                            data = Encoding.Unicode.GetBytes(dataStr);
                            handler.Send(data);
                        }
                        else
                        {
                            builder.Append("notData");
                            //отправляем ответ
                            string dataStr = builder.ToString();
                            data = Encoding.Unicode.GetBytes(dataStr);
                            handler.Send(data);
                        }
                    }

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