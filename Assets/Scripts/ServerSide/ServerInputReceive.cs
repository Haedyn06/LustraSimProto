using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

public class ServerInputReceive : MonoBehaviour {
    private IMqttClient mqttClient;
    public LustraDialogue dialogueScript;
    public LustraFollow lustraFollowScript;
    public LustraControlPanel toggleUIScript;

    private string receivedMsg = null;

    async void Start() {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("192.168.1.122")
            .Build();

        mqttClient.ApplicationMessageReceivedAsync += eventArg => {
            string topic = eventArg.ApplicationMessage.Topic;
            string msgResponse = Encoding.UTF8.GetString(eventArg.ApplicationMessage.PayloadSegment);
            //Debug.Log($"Topic: '{topic}'; Message: {msgResponse}");

            if (topic == "lustrasim/lustratalk/response") {
                receivedMsg = msgResponse;
                toggleUIScript.ToggleDialogueUI(true);
                //Lustra
            }

            return Task.CompletedTask;
        };
        await mqttClient.ConnectAsync(options);
        await mqttClient.SubscribeAsync("lustrasim/lustratalk/response");
    }

    void Update() {
        if (!string.IsNullOrEmpty(receivedMsg)) {
            dialogueScript.displayResponse(receivedMsg);
            receivedMsg = null;
        }
    }
}
