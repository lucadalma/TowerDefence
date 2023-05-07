using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    GameObject objectSelected;

    public TowerPoint tower;

    void Update()
    {

        if (!objectSelected) return;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            Debug.Log(hit.transform.tag);

            tower = hit.transform.GetComponent<TowerPoint>();

            if (Input.GetMouseButtonDown(0)) 
            {
                if (hit.transform.CompareTag("TowerPoint") || hit.transform.CompareTag("Placeable"))
                {
                     Vector3 TransformParet = hit.transform.position + new Vector3(0, 0.7f, 0);
                     Instantiate(objectSelected, TransformParet, Quaternion.identity);
                }
            }
        }
    }
}
