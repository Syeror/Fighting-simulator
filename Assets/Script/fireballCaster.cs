using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballCaster : MonoBehaviour
{
    public float Damage = 10;
    public fireball FireballPrefab;
    public Transform FireballSourseControll;
   
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(FireballPrefab);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

           var Fireball = Instantiate(FireballPrefab, FireballSourseControll.position, FireballSourseControll.rotation);
            Fireball.Damage = Damage;
        }
    }
}
