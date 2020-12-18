using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class DashBoardClient : MonoBehaviour {
	public string brokerIpAddress = "127.0.0.1";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala/temperatura";
	public string lightTopic = "casa/sala/luz";
    public string intruderTopic = "casa/patio/movimiento";
    public string carAlarmTopic = "casa/garage/carro";
	private MqttClient client;
	public Text temperatureText;
    public Text intruderText;
    public Text carAlarmText;
	public GameObject directionalLight;
	string lastMessage;
    string temperature = "0";
    string intruder = "NO";
    string carAlarm = "OFF";
	volatile bool lightState = false;
    public CarAlarm cA;
	// Use this for initialization
	void Start () {
		// create client instance 
		client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
		
		// register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
		
		// subscribe to the topic "/home/temperature" with QoS 2 
		client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  
        client.Subscribe(new string[] { intruderTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
        client.Subscribe(new string[] { "casa/garage/carro" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
	}
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		if(e.Topic.Equals(lightTopic))
		{
			if(lastMessage.Equals("lightOn"))
			{
				lightState = true;
			}
			else if(lastMessage.Equals("lightOff"))
			{
				lightState = false;
			}
		}
        else if(e.Topic.Equals(temperatureTopic))
			temperature = lastMessage;
        else if(e.Topic.Equals(intruderTopic))
            intruder = lastMessage;
        else if(e.Topic.Equals("casa/garage/carro"))
            carAlarm = lastMessage;
	}

	void Update()
	{
		temperatureText.text = temperature;
        intruderText.text = intruder;
        carAlarmText.text = carAlarm;
		if (lightState != directionalLight.activeSelf)
			directionalLight.SetActive(lightState);
	}

	void OnGUI(){
		if ( GUI.Button (new Rect (20,40,100,20), "Encender Luz")) {
			Debug.Log("sending...");
			client.Publish("casa/sala/luz", System.Text.Encoding.UTF8.GetBytes("lightOn"), 
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
		}
        if ( GUI.Button (new Rect (20,70,100,20), "Apagar Luz")) {
			Debug.Log("sending...");
			client.Publish("casa/sala/luz", System.Text.Encoding.UTF8.GetBytes("lightOff"), 
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
		}
        if(cA.playing)
        {
            if ( GUI.Button (new Rect (20,100,100,20), "Alarma carro")) 
            {
                cA.playing = false;
                cA.audio.Pause();
                Debug.Log("sending...");
                client.Publish("casa/garage/carro", System.Text.Encoding.UTF8.GetBytes("OFF"), 
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                Debug.Log("sent");
		    }
        }
	}

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
