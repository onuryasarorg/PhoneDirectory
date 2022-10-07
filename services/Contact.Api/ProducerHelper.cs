using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Contact.Api;

public class ProducerHelper
{
    private static readonly ConnectionFactory factory = new ConnectionFactory();
    ProducerHelper()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        config.GetSection("RabbitMqConnection").Bind(factory);
    }
    
    public async static Task CreateContact(Models.Contact model)
    {
         await SendQueue(model, "Create");
    }

    public async static Task UpdateContact(Models.Contact model)
    {
        await SendQueue(model, "Update");
    }

    public async static Task DeleteContact(Guid id)
    {
        await SendQueue(id, "Delete");
    }

    private async static Task SendQueue<TModel>(TModel model, string channelName)
    {
        using (IConnection connection = factory.CreateConnection())
        using (IModel channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: channelName,
                durable: false, 
                exclusive: false, 
                autoDelete: false,
                arguments: null);

            string message = JsonConvert.SerializeObject(model);
            var body = Encoding.UTF8.GetBytes(message);

            await Task.Run(()=> channel.BasicPublish(exchange: "",
                routingKey: channelName,
                body: body));
        }
    }
}