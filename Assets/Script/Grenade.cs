using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Grenade : MonoBehaviour

{
    public float damage = 50;
    public float Delay = 3.0f;
    public GameObject ExplosionPrefab;
   
    
    
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", Delay);
    }
    private void Explosion()
    {
        Destroy(gameObject);
      var explosion = Instantiate(ExplosionPrefab);
      explosion.transform.position = transform.position;
        explosion.GetComponent<Explosion>().damage = damage;

    }  


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
      
    }
}
