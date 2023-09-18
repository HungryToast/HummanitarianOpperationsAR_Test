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
    int listSize;
    [SerializeField] GameObject numberPrefab;
    Numbers numbersScript;

    [SerializeField] GameObject numberSelector;

    [SerializeField] ARRaycastManager aRRaycastManager;
   

    private int currentNumberIndex;
    private int currentNum;

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
        listSize = numList.Count;   

       aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    public void OnPickNumber() 
    { 
        
    }

    public void ChangeNumber()
    {
        //Due to a known bug the lise size has to be created as a variable instead of directly using the numList.Count as I originally did

        if (numList.Count > 0) 
        { 
            currentNumberIndex = Random.Range(0,listSize);
            print("Current List Index = " + currentNumberIndex);
            currentNum = numList[currentNumberIndex];
            SpawnNumber();
            numbersScript.SetNumber(currentNum);

        }
    }

    public void OnRemoveNumber()
    {
        if (numList.Count > 0) 
        { 
            numList.Remove(currentNum);
            listSize--; 
            Destroy(numbersScript.gameObject);
        } 
        
    }

    void SpawnNumber()
    {
        numbersScript = GameObject.Instantiate(numberPrefab).GetComponent<Numbers>();
        MoveNumberToRandomPosition();
        numbersScript.SetChildren();
    }
    
    void MoveNumberToRandomPosition()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Vector2 randomScreenPoint = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));

        if (aRRaycastManager.Raycast(randomScreenPoint, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            numberPrefab.gameObject.transform.position = hitPose.position;
        }

    }

    public int GetCurrentNumber()
    {
        return currentNum;
    }


  
}
