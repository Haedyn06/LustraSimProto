using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ServerInputReceive : MonoBehaviour {
    private IMqttClient mqttClient;
    public LustraDialogue dialogueScript;
    public LustraFollow lustraFollowScript;
    public LustraControlPanel toggleUIScript;
    public ResponsePackage chatlogPack;
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
                List<ResponsePackage> chatlogList = JsonConvert.DeserializeObject<List<ResponsePackage>>(msgResponse);
                chatlogPack = chatlogList[0];
                receivedMsg = chatlogPack.response;
                toggleUIScript.ToggleDialogueUI(true);
            }

            return Task.CompletedTask;
        };
        await mqttClient.ConnectAsync(options);
        await mqttClient.SubscribeAsync("lustrasim/lustratalk/response");
    }

    void Update() {
        if (!string.IsNullOrEmpty(receivedMsg)) {
            dialogueScript.displayResponse(receivedMsg + " <Space to Close>");
            receivedMsg = null;
        }
    }
}
