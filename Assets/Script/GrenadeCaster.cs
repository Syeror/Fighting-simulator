using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float Damage = 50;
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourseTransform;
    public float Force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
          var grenade =  Instantiate(GrenadePrefab);        
            grenade.transform.position = GrenadeSourseTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourseTransform.forward*Force);
            grenade.GetComponent<Grenade>().damage = Damage;
        }
    }
}
