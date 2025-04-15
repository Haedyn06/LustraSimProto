using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

public class ComDev : MonoBehaviour
{
    private IMqttClient mqttClient;

/*    async void Start() {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder().WithTcpServer("192.168.1.122").Build();

        try {
            await mqttClient.ConnectAsync(options);
            Debug.Log("✅ Connected to MQTT broker");

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("unity/test")
                .WithPayload("Hello from Unity 🛠️")
                .Build();

            await mqttClient.PublishAsync(message);
            Debug.Log("📡 Message sent!");
        } catch (System.Exception ex) {
            Debug.LogError($"❌ MQTT Error: {ex.Message}");
        }
    }*/

    public async void sendMsg() {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder().WithTcpServer("192.168.1.122").Build();

        try {
            await mqttClient.ConnectAsync(options);
            Debug.Log("✅ Connected to MQTT broker");

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("unity/receive")
                .WithPayload("Hello from Unity 🛠️")
                .Build();

            await mqttClient.PublishAsync(message);
            Debug.Log("📡 Message sent!");
        } catch (System.Exception ex) {
            Debug.LogError($"❌ MQTT Error: {ex.Message}");
        }
        //Debug.Log("ProllyWorking!");
    }

    void Update()
    {
        
    }
}
