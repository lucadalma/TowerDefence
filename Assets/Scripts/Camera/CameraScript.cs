using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int countPlacement = 0;

    public GameObject objectSelected;

    UIManager uIManager;

    private void Start()
    {
        uIManager = FindAnyObjectByType<UIManager>();
        objectSelected = null;
    }

    private void Update()
    {
        if (countPlacement > 5) 
        {
            uIManager.InGameCanvas.SetActive(false);
        }
    }
}
