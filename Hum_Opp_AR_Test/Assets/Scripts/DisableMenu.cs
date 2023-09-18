using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenu : MonoBehaviour
{
    [SerializeField] GameObject menuToDisable;

    private void Awake()
    {
        menuToDisable.SetActive(false);
    }
}
