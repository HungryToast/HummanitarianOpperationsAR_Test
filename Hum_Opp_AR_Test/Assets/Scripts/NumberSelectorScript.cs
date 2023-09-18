using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSelectorScript : MonoBehaviour
{
    List<GameObject> numbersSelectorList = new List<GameObject>();
    [SerializeField]List<Mesh> numbersMesh;
    [SerializeField] NumbersGame numbersGameScript;


    private void Awake()
    {
        List<Mesh> localMeshList = numbersMesh;
        numbersGameScript = FindObjectOfType<NumbersGame>();


        foreach (Transform t in this.transform)
        {
            numbersSelectorList.Add(t.gameObject);
            t.gameObject.tag = null;
        }



        int randomIndex = Random.Range(0, numbersSelectorList.Count);
        numbersSelectorList[randomIndex-1].GetComponent<MeshFilter>().mesh = localMeshList[numbersGameScript.GetCurrentNumber() - 1];
        numbersSelectorList[randomIndex].tag = "CorrectNumber";

        numbersSelectorList.RemoveAt(randomIndex);
        localMeshList.RemoveAt(numbersGameScript.GetCurrentNumber() - 1);

        for (int i = 0; i < numbersSelectorList.Count; i++)
        {
            int r = Random.Range(0,numbersSelectorList.Count);

            numbersSelectorList[i].GetComponent<MeshFilter>().mesh = localMeshList[r - 1];
            numbersSelectorList[i].tag = "IncorrectNumber";

            numbersSelectorList.RemoveAt(r);
            localMeshList.RemoveAt(r);

        }
        
    }
}
