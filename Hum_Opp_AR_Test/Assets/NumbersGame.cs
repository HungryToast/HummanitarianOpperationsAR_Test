using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class NumbersGame : MonoBehaviour
{
    int maxNum;
    List<int> numList;
    [SerializeField] GameObject numberPrefab;

    [SerializeField] ARRaycastManager raycastManager;

    private int currentNumber;

    private void Awake()
    {
        //In order to keep true to the brief the maxNum count will only be up to 10
        maxNum = 10;

        //initilaise list used for counting
        numList = new List<int>();
        for (int i = 0; i < maxNum; i++)
        {
            numList.Add(i+1);
        }


        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
          
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numList.Count > 0)
        {
            PickNumber();
            RemoveNumber();
        }
    }

    void SpawnNumber()
    {


    }

    void PickNumber()
    {
        currentNumber = numList[Random.Range(0,numList.Count)];
        print (currentNumber + 1);
    }

    void RemoveNumber()
    {
        numList.RemoveAt(currentNumber);
    }
}
