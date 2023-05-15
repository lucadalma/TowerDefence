using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    //enum per i tipi di buff
    public enum TypeBuff 
    {
        Damage,
        Range,
        Ratio
    }

    public TypeBuff typeBuff;
   
    //Funzione che aumenta il danno
    public void IncreaseDamage(List<Tower> _towers) 
    {
        foreach (Tower tower in _towers)
        {
            tower.damage += 10;
        }
    }

    //Funzione che aumenta la frequenza di fuoco
    public void IncreaseRatio(List<Tower> _towers)
    {
        foreach (Tower tower in _towers)
        {
            tower.shootRate -= 2f;
        }
    }


    //Fiunzione che aumenta il range
    public void IncreaseRange(List<Tower> _towers) 
    {
        foreach (Tower tower in _towers)
        {
            CapsuleCollider collider = tower.gameObject.GetComponent<CapsuleCollider>();
            collider.radius += 2;
        }
    
    }
}
