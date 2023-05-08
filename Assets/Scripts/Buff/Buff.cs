using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public enum TypeBuff 
    {
        Damage,
        Range,
        Ratio
    }

    public TypeBuff typeBuff;
   

    public void IncreaseDamage(List<Tower> _towers) 
    {
        foreach (Tower tower in _towers)
        {
            tower.damage += 10;
        }
    }

    public void IncreaseRatio(List<Tower> _towers)
    {
        foreach (Tower tower in _towers)
        {
            tower.shootRate -= 2f;
        }
    }

    public void IncreaseRange(List<Tower> _towers) 
    {
        foreach (Tower tower in _towers)
        {
            CapsuleCollider collider = tower.gameObject.GetComponent<CapsuleCollider>();
            collider.radius += 2;
        }
    
    }
}
