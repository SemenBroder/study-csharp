using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TCP_Server
{
    public static void Main()
    {
        TcpListener server = null;
        try
        {
            Int32 port = 12345; //порт сервера
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");//ip-адрес сервера (интерфейс)

            //TcpListener - класс TCP-сервера из .Net Framework Class Library
            server = new TcpListener(localAddr, port);

            // начинаем ожидание подсоединений клиентов на интерфейсе localAddr и порту port
            server.Start();

            // буффер для приема сообщений и соответствующая ему строка для вывода на экран
            Byte[] bytes = new Byte[1000];
            String data;

            //ответ клиенту
            String answer_message;

            //цикл обработки подсоединений клиентов
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                // Ждем соединения клиента
                TcpClient client = server.AcceptTcpClient();
                //Ура! Кто-то подсоединился!
                Console.WriteLine("Connected!");
                // вводим поток stream для чтения и записи через установленное соединение
                NetworkStream stream = client.GetStream();
                int i = stream.Read(bytes, 0, bytes.Length);
                if (i > 0)
                {
                    // преобразуем принятые данные в строку ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    //печатаем то, что получили
                    Console.WriteLine("Received: {0}", data);
                    //анализируем запрос клиента и вычисляем результат

                   


                   
                    if (data.Contains("CALC"))
                    {
                        
                        string[] mystring = data.Split(' ');
                        Double x = new Double();
                        Double y = new Double();

                        x = Convert.ToDouble(mystring[2]);
                        y = Convert.ToDouble(mystring[3]);
                        switch (mystring[1])
                        {
                            case "+":
                                answer_message = Convert.ToString(x + y);

                                break; 

                            case "-":
                                answer_message = Convert.ToString(x - y);

                                break;

                            case "/":
                                answer_message = Convert.ToString(x / y);

                                break;

                            case "*":
                                answer_message = Convert.ToString(x * y);

                                break;

                            default:
                               answer_message = "ERROR";
                                break;
                        }
                    }
                    else
                    {

                        answer_message = "ERROR";


                    }

                    
                    //преобразуем строчку-ответ сервера в массив байт
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(answer_message);
                    // отправляем ответ
                    stream.Write(msg, 0, msg.Length);
                }

                // закрываем соединение
                client.Close();
            }
        }
        catch (SocketException expt)
        {
            Console.WriteLine("SocketException: {0}", expt);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
        }

        Console.WriteLine("\nHit enter to continue...");
        Console.ReadKey();
    }
}