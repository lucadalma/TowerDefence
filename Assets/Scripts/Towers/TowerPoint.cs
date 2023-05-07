using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoint : MonoBehaviour
{

    public int count = 0;

    [SerializeField]
    public int maxCount;

    public List<Tower> Towers;

    public List<GameObject> listObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Placeable"))
        {
            if (count < maxCount)
            {
                listObjects.Add(other.gameObject);

                if (other.gameObject.GetComponent<Buff>())
                {
                    Buff buff = other.gameObject.GetComponent<Buff>();

                    if (buff.typeBuff == Buff.TypeBuff.Damage)
                    {
                        buff.IncreaseDamage(Towers);
                    }
                    else if (buff.typeBuff == Buff.TypeBuff.Ratio)
                    {
                        buff.IncreaseRatio(Towers);
                    }
                    else
                    {
                        buff.IncreaseRange(Towers);
                    }
                }
                else
                {
                    Towers.Add(other.gameObject.GetComponent<Tower>());
                }
                count++;
            }
            else
            {
                Destroy(other);
            }

        }
    }
}
