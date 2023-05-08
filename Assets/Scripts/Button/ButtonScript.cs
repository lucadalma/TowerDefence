using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    [SerializeField]
    public GameObject objectButton;

    CameraScript camera1;

    private void Start()
    {
        camera1 = FindAnyObjectByType<CameraScript>();
    }

    public void SelectObject() 
    {
        camera1.objectSelected = objectButton;
        Debug.Log(camera1.objectSelected);
    }

}
