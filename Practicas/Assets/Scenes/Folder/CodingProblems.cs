using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingProblems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] input = {1,2,3,4};
        int[] output = new int[4];
        Debug.Log("Solving problem...");
        output = smallerNumberCounter(input);
    }

    public int[] smallerNumberCounter(int[] nums){
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
    }
}
