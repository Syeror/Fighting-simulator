using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourseTransform; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
          var Grenade =  Instantiate(GrenadePrefab);
        }
    }
}
