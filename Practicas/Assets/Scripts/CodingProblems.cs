using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingProblems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] student = new string[5];
        student[0] = "Andrade Aldair";
        student[1] = "Banuelos Ricardo";
        student[2] = "Cazares Paulo";
        student[3] = "Deidad Diana";
        student[4] = "Esparza Pablo";

        if(checkStudent(student,"Andrade Aldair")){
            Debug.Log("Inscrito");
        }
        else{
            Debug.Log("No inscrito");
        }
    }

    /*public int[] smallerNumberCounter(int[] nums){
        int[] output = new int[nums.Length];
        int counter;
        for(int i = 0; i < nums.Length; i++){
            counter = 0;
            for(int j = 0; j < nums.Length; j++){
                if(nums[j] < nums[i])
                    counter++;
            }
            output[i] = counter;
        }
        return output;
    }*/

    public bool checkStudent(string[] students, string student){
        int izquierda = 0;
        int derecha = students.Length - 1;

        while(izquierda <= derecha){
            int mid = (izquierda+derecha)/2;
            if(student.Equals(students[mid])){
                return true;
            }else if(student.CompareTo(students[mid]) < 0){
                derecha = mid -1;
            }else{
                izquierda = mid+1;
            }
        }
        return false;
    }
}
