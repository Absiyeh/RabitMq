using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RebitMQConsumerAPI;
using System.Xml.Linq;

namespace RebitMQConsumerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();


            var queue = channel.QueueDeclare("apique");

         ////// وقتی * بعد و یا قبل کلمه میاد یعنی باید دقیقا یک کلمه قبا یا بعد باشد
         ///وقتی # بعد و یا قبل کلمه میاد یعنی میشه هیچ و یا چند کلمه ثبل و بعد اون کلمه گذاشت



            channel.QueueBind(queue, "topichexchange", "quick.*");
            rabbitclass messageReceiver = new rabbitclass(channel);
            channel.BasicConsume(queue: queue, autoAck: true, consumer: messageReceiver);






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}