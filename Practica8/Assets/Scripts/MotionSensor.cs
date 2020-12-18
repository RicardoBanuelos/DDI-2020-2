using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class MotionSensor : MonoBehaviour
{
    public string brokerIpAddress = "127.0.0.1";
	public int brokerPort = 1883;
	public string motionTopic = "casa/patio/movimiento";
    private MqttClient client;
    string lastMessage;
    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Trespassing");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("SI"), 
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Clear");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("NO"), 
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }

    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
