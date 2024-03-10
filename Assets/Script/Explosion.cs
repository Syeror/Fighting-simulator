using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 50;
    public float MaxSize = 5;
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.zero * Time.deltaTime * Speed;

        if (transform.localScale.x > MaxSize)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.GetComponent<PlayerHealth>();
        if (PlayerHealth != null )
        {
            PlayerHealth.DealDamage(damage);
        }
        var EnemyHealth = other.GetComponent<enemyHealth>();
        if (EnemyHealth != null )
        {
            EnemyHealth.DealDamage(damage);
        }
    }
}
