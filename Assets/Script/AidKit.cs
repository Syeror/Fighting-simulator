using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    public float HealAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (PlayerHealth != null )
        {
           PlayerHealth.AddHealth(HealAmount);
            Destroy(gameObject);
        }
       
    }
  

}
