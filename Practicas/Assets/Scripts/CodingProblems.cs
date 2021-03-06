﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingProblems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       int[] array = {1, 3, 5 ,7 , 9, 2};
       int pares = countNumPar(array);
       Debug.Log(pares);
    }

    public int countNumPar(int[] array){
        int contador = 0;
        for(int i = 0; i < array.Length; i++){
            int temp = array[i];
            int esPar = 0;
            while(temp > 0){
                temp /= 10;
                esPar++;
            }
            if((esPar%2) == 0)
                contador++;
        }
        return contador;
    }

    public int[] SumaDos(int[] nums, int target)
    {
        int[] res = new int[2];

        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = 0; j < nums.Length; j++)
            {
                if(i != j)
                {
                    if((nums[i]+nums[j]) == target)
                    {
                        res[0] = nums[i];
                        res[1] = nums[j];
                        return res;
                    }
                }
            }
        }
        return res;
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
