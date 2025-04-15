using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

public class GetReq : MonoBehaviour
{
    private IMqttClient mqttClient;

    async void Start() {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("192.168.1.122")
            .Build();

        mqttClient.ApplicationMessageReceivedAsync += e => {
            string topic = e.ApplicationMessage.Topic;
            string payload = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment);
            Debug.Log($"📥 Received on topic '{e.ApplicationMessage.Topic}': {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)}");
            return Task.CompletedTask;
        };

        await mqttClient.ConnectAsync(options);
        Debug.Log("✅ Subscribed and waiting...");

        await mqttClient.SubscribeAsync("unity/send");
    }
}
