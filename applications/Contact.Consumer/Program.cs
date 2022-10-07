// See https://aka.ms/new-console-template for more information
using System.Text;
using EFContext.Infrastructure;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello, World!");



        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        

DBContext context = new DBContext();
var factory = new ConnectionFactory();
config.GetSection("RabbitMqConnection").Bind(factory);
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var contact = JsonConvert.DeserializeObject<Contact>(message); 
                    context.Insert(contact);
                };
                channel.BasicConsume(queue: "Contact",
                    autoAck: true, 
                    consumer: consumer);

                Console.ReadKey();
            }

        