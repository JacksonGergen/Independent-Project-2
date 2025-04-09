using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform Player;
    public Transform PatrolRoute;
    public List<Transform> locations;
    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    private int _lives = 3;
    public int enemyLives
    {
        get 
        { 
            return _lives;
        }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down!");
            }
        }
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
        {
            return;
        }
        _agent.destination = locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _agent.destination = Player.position;
            Debug.Log("Player detected - attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range - resume patrol.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            enemyLives -= 1;
            Debug.LogFormat("Enemy has {0} lives remaining", enemyLives);
        }
    }
}
