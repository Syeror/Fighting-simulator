using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float value;
    public PlayerProgress playerProgress;
   
    public void DealDamage(float damage)
    {
      
        
        value -= damage;
        playerProgress.AddExpirence(damage);
    
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }

}
