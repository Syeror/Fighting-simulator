using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float value;
   
    public void DealDamage(float damage)
    {

        value -= damage;
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }

}
