using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class enemyAl : MonoBehaviour
{
    public float ViewAngle;
    private NavMeshAgent _navMeshAgent;
    public List<Transform> PatrolPoint;
    public PlayerController Player;
    private bool _isPlayerNoticed;
    public float damage = 15 ;
    private PlayerHealth _PlayerHealth;
    void Start()
    {
        inComponentLink();
        PickNewPatrolPoint();
    }


    private void inComponentLink()
    {
        _PlayerHealth =Player.GetComponent<PlayerHealth>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

    }
    // Update is called once per frame
    void Update()
    {
      
            IsplayerNoticedUpdate();
            pursuitUpdate();
            PickNewPatrolPoint();
            AttackUpdate();
        

      

            
        
    }
    private void PickNewPatrolPoint()
    {
        if (!_isPlayerNoticed)
        {
            Debug.Log(PatrolPoint);
          _navMeshAgent.destination = PatrolPoint[Random.Range(0, PatrolPoint.Count)].position;
        }
    }
    private void IsplayerNoticedUpdate()
    {
        var Direction = Player.transform.position - transform.position;
      
        Debug.DrawRay(transform.position, Direction);


        if (Vector3.Angle(transform.forward , Direction) < ViewAngle)
        {
           
            RaycastHit hit;
            _isPlayerNoticed = false;
         
           
            if (Physics.Raycast(transform.position + Vector3.up, Direction, out hit,999999))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                   
                }

            }
        }
    }
    private void pursuitUpdate()
    { 
     if(_isPlayerNoticed)
        {
           _navMeshAgent.destination = Player.transform.position;

        }    
    
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
           PickNewPatrolPoint();
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {

            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _PlayerHealth.DealDamage( damage * Time.deltaTime );

                
            }
        }
    }
}
        
