using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;
using UnityEngine.Audio;

using System;

public class CarAlarm : MonoBehaviour
{
    public string brokerIpAddress = "127.0.0.1";
	public int brokerPort = 1883;
	public string carAlarmTopic = "casa/garage/carro";
    public AudioSource audio;
    private MqttClient client;
    string lastMessage;
    public  bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
        client.Publish(carAlarmTopic, System.Text.Encoding.UTF8.GetBytes("OFF"), 
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !playing)
        {
            playing = true;
            Debug.Log("Alarm goes off");
            client.Publish(carAlarmTopic, System.Text.Encoding.UTF8.GetBytes("ON!"), 
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            audio.Play();
        }
    }

    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
