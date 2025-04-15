using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
public class ServerInputSend : MonoBehaviour
{
    private IMqttClient mqttClient;

    public async void sendMsgServer(string userMsg) {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder().WithTcpServer("192.168.1.122").Build();

        try {
            await mqttClient.ConnectAsync(options);
            Debug.Log("Connected to MQTT broker");

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("lustrasim/lustratalk/input")
                .WithPayload(userMsg)
                .Build();

            await mqttClient.PublishAsync(message);
            Debug.Log("Message sent!");
        } catch (System.Exception ex) {
            Debug.LogError($"❌ MQTT Error: {ex.Message}");
        }
    }
}
