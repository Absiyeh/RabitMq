using RabbitMQ.Client;
using System.Text;
using System;

namespace RebitMQConsumerAPI
{
    public class rabbitclass: DefaultBasicConsumer
    {
        private readonly IModel _channel;

        public rabbitclass(IModel channel)
        {
            _channel = channel;
        }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
        {

            var bodys = body.ToArray();
            var message = Encoding.UTF8.GetString(bodys);

            Console.WriteLine($"Product message received: {message}");

            _channel.BasicAck(deliveryTag, false);
        }

    }
}
