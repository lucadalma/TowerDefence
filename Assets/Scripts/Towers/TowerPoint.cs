using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TowerPoint : MonoBehaviour
{

    public int count;

    [SerializeField]
    public int maxCount;

    public List<Tower> Towers;
    public List<Buff> Buffs;

    public List<GameObject> listObjects;

    [SerializeField]
    CameraScript camera1;

    GameObject TowerAdd;

    public void AddComponentToTower() 
    {
        if (!camera1.objectSelected) return;

        if (listObjects.Count > 0)
        {
            count++;
            Vector3 TransformParet = transform.localPosition + new Vector3(0, count, 0);
            Debug.Log("Secondo" + count);
            TowerAdd = Instantiate(camera1.objectSelected, TransformParet, Quaternion.identity);

            camera1.countPlacement++;

            if (TowerAdd.GetComponent<Buff>())
            {
                Buffs.Add(TowerAdd.GetComponent<Buff>());
            }
            else 
            {
                Towers.Add(TowerAdd.GetComponent<Tower>());
            }

            listObjects.Add(TowerAdd);

            if (TowerAdd.GetComponent<Buff>())
            {
                CheckBuffs(listObjects, TowerAdd.transform.name);
            }
            else 
            {
                AddBuffToOneTower(TowerAdd.GetComponent<Tower>());
            }

            camera1.objectSelected = null;

        }
        else if(!camera1.objectSelected.GetComponent<Buff>())
        {
            Vector3 TransformParet = transform.localPosition + new Vector3(0, 1, 0);
            Debug.Log("Primo");
            TowerAdd = Instantiate(camera1.objectSelected, TransformParet, Quaternion.identity);

            count++;
            camera1.countPlacement++;

            listObjects.Add(TowerAdd);

            if (TowerAdd.GetComponent<Buff>())
            {
                Buffs.Add(TowerAdd.GetComponent<Buff>());
            }
            else
            {
                Towers.Add(TowerAdd.GetComponent<Tower>());
            }

            if (TowerAdd.GetComponent<Buff>())
            {
                CheckBuffs(listObjects, TowerAdd.transform.name);
            }
            else
            {
                AddBuffToOneTower(TowerAdd.GetComponent<Tower>());
            }

            camera1.objectSelected = null;

        }



    }

    public void CheckBuffs(List<GameObject> _objects, string _name) 
    {
        foreach (GameObject _object in _objects)
        {
            Buff buff = _object.GetComponent<Buff>();

            if (buff && buff.transform.name == _name) 
            {
                if (buff.typeBuff == Buff.TypeBuff.Damage)
                {
                    Debug.Log("Damage Icrease");
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

    public void AddBuffToOneTower(Tower _tower) 
    {
        List<Tower> _towers = new List<Tower>();

        _towers.Add(_tower);

        foreach (GameObject _object in listObjects)
        {
            Buff buff = _object.GetComponent<Buff>();

            if (buff)
            {
                if (buff.typeBuff == Buff.TypeBuff.Damage)
                {
                    Debug.Log("Tower damage increase");
                    buff.IncreaseDamage(_towers);
                }
                else if (buff.typeBuff == Buff.TypeBuff.Ratio)
                {
                    Debug.Log("Tower Ratio increase");
                    buff.IncreaseRatio(_towers);
                }
                else
                {
                    Debug.Log("Tower Range increase");
                    buff.IncreaseRange(_towers);
                }
            }
        }
    }
}
