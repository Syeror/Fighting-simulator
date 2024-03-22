using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float Speed;
    private Vector3 _MoveVector;
    private bool ChekerOncolisionAnotherobject;
    public float cooldown;
    private float cooldownTimer;

    public float lifetime;
    public float  Damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
      Invoke("DestroyFireball" , lifetime);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void FixedUpdate()
    {

        MoveFixedUpdate();
    }
    private void  MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    
     private void DestroyFireball()
      {
      Destroy(gameObject);
      }
    private void OnCollisionEnter(Collision collision)
    {

        DamageEnemy(collision);
        DestroyFireball();
    }

    private void DamageEnemy(Collision  collision )
    {
        var enemyHealth = collision.gameObject.GetComponent<enemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
    }
}
