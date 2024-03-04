using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public float ViewAngle;
    private NavMeshAgent _navMeshAgent;
    public List<Transform> PatrolPoints;
    public PlayerController Player;
    private bool _isPlayerNoticed;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
    }

    void Update()
    {
        IsPlayerNoticedUpdate();
        PatrolUpdate();
        PursuitUpdate();
    }

    private void PickNewPatrolPoint()
    {
        if (!_isPlayerNoticed)
        {
            _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
        }
    }

    private void IsPlayerNoticedUpdate()
    {
        var direction = Player.transform.position - transform.position;

        if (Vector3.Angle(transform.up, direction) < ViewAngle)
        {
            RaycastHit hit;
            _isPlayerNoticed = false;

            if (Physics.Raycast(transform.position, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PursuitUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();
        }
    }

   
}
