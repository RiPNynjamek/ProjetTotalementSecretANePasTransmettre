using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using WebService.Interfaces;

namespace WebService.Business
{
    public class Communication<T> : ICommunicateJob<T>
    {
        private Thread workerThread;
        public bool DoWork(List<T> objet)
        {
            return true;
        }

        public void ReceiveMessage()
        {
            try
            {

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "result",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            Debug.WriteLine("Received : " + message);
                            DecryptXOR<T>.IsDecrypted = true;
                            DecryptXOR<T>.FinalMessage = message;
                        };
                        channel.BasicConsume(queue: "result",
                                                noAck: true,
                                                consumer: consumer);
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogFile(e.GetType().ToString(), e.InnerException.Message, e.Message);
                throw;
            }
            
        }

        public void Receive()
        {
            Communication<T> workerObject = new Communication<T>();
            workerThread = new Thread(workerObject.ReceiveMessage);
            workerThread.Start();
        }

        public void Send(string message)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "decrypt",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                                             routingKey: "decrypt",
                                             basicProperties: null,
                                             body: body);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogFile(e.GetType().ToString(), e.InnerException.Message, e.Message);
                throw;
            }
        }
    }
}