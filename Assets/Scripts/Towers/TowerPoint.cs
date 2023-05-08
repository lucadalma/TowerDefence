using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TowerPoint : MonoBehaviour
{

    public int count = 0;

    [SerializeField]
    public int maxCount;

    public List<Tower> Towers;

    public List<GameObject> listObjects;

    [SerializeField]
    CameraScript camera1;



    GameObject TowerAdd;


    public void AddComponentToTower() 
    {
        if (!camera1.objectSelected) return;

        if (listObjects.Count > 0)
        {
            GameObject obj = listObjects.Last();
            Debug.Log("Secondo" + obj.transform.position);
            Vector3 TransformParet = transform.localPosition + new Vector3(0, count, 0);
            TowerAdd = Instantiate(camera1.objectSelected, TransformParet, Quaternion.identity);

            camera1.objectSelected = null;

            count++;

            if (camera1.objectSelected.GetComponent<Tower>())
            {
                Towers.Add(TowerAdd.GetComponent<Tower>());
            }
            else
            {
                Debug.Log("check buff");
                CheckBuffs();
            }
        }
        else if(!camera1.objectSelected.GetComponent<Buff>())
        {
            Vector3 TransformParet = transform.localPosition + new Vector3(0, 1, 0);
            Debug.Log("Primo");
            TowerAdd = Instantiate(camera1.objectSelected, TransformParet, Quaternion.identity);

            camera1.objectSelected = null;

            count++;

            if (camera1.objectSelected.GetComponent<Tower>())
            {
                Towers.Add(TowerAdd.GetComponent<Tower>());
            }
            else
            {
                Debug.Log("check buff");
                CheckBuffs();
            }

        }

        if (!TowerAdd) return;

        listObjects.Add(TowerAdd);

    }

    public void CheckBuffs() 
    {
        foreach (GameObject _object in listObjects)
        {
            Buff buff = _object.GetComponent<Buff>();

            Debug.Log(_object.transform.name);

            if (buff) 
            {
                if (buff.typeBuff == Buff.TypeBuff.Damage)
                {
                    Debug.Log("Damage");
                    buff.IncreaseDamage(Towers);
                }
                else if (buff.typeBuff == Buff.TypeBuff.Ratio)
                {
                    Debug.Log("Ratio increase");
                    buff.IncreaseRatio(Towers);
                }
                else 
                {
                    Debug.Log("Range increase");
                    buff.IncreaseRange(Towers);
                }
            }
        }    
    }
}
