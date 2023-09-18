using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    List<GameObject> numbers;

    private void Awake()
    {
        numbers = new List<GameObject>();
    }

    public void SetChildren()
    {
        foreach (Transform number in this.transform)
        {
            numbers.Add(number.gameObject);
        }
        foreach (GameObject number in numbers)
        {
            number.SetActive(false);
        }
    }

   public void SetNumber(int number)
    {
        if (numbers.Count > 0) 
        { 
            numbers[number-1].SetActive(true);
        }
    }
}
