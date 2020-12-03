using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    private string command;

    public Command(string command)
    {
        this.command = command;
    }

    public void Execute()
    {
        if(command.Equals("fly"))
        {
            Vector3 newPos = new Vector3(10,10,0);
            Debug.Log("Cubes flying...");
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
            foreach(GameObject cube in cubes)
                cube.GetComponent<Rigidbody>().AddForce(Vector3.up*300f);
        }
        else if(command.Equals("push"))
        {
            Debug.Log("Spheres rolling...");
            GameObject[] spheres = GameObject.FindGameObjectsWithTag("Sphere");
            foreach(GameObject sphere in spheres)
                sphere.GetComponent<Rigidbody>().AddForce(Vector3.forward*200f);
        }
        else if(command.Equals("bigger"))
        {
            Vector3 scale = new Vector3(0.5f,0.5f,0.5f);
            Debug.Log("Cars getting big...");
            GameObject[] cars = GameObject.FindGameObjectsWithTag("Lambo");
            foreach(GameObject car in cars)
                car.transform.localScale+=scale;
        }
        else if(command.Equals("smaller"))
        {
            Vector3 scale = new Vector3(0.5f,0.5f,0.5f);
            Debug.Log("Cars getting small...");
            GameObject[] cars = GameObject.FindGameObjectsWithTag("Lambo");
            foreach(GameObject car in cars)
                car.transform.localScale-=scale;
        }
        else if(command.Equals("roll") || command.Equals("role"))
        {
            Vector3 scale = new Vector3(0.5f,0.5f,0.5f);
            Debug.Log("Cars rolling...");
            GameObject[] cars = GameObject.FindGameObjectsWithTag("Lambo");
            foreach(GameObject car in cars)
            {
                car.GetComponent<Rigidbody>().AddForce(Vector3.up*300f);
                car.GetComponent<Rigidbody>().AddForce(Vector3.left*300f);
            }
        }
    }
}
