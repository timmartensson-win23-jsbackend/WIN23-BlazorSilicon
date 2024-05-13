using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace BlazorWebApp.Services;

public class ServiceBusManager
{
    private readonly IConfiguration _configuration;
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;

    public ServiceBusManager(IConfiguration configuration)
    {
        _configuration = configuration;
        _client = new ServiceBusClient(_configuration.GetConnectionString("ServiceBusConnection"));
        _sender = _client.CreateSender(_configuration.GetValue<string>("ServiceBus:SenderQueueName"));
    }

    public async Task SendMessageAsync(string email)
    {
        var message = new { Email = email };
        var jsonString = JsonConvert.SerializeObject(message);
        var serviceBusMessage = new ServiceBusMessage(jsonString);
        await _sender.SendMessageAsync(serviceBusMessage);
    }
}
