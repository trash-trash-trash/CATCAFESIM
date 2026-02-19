using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    public float wanderRadius = 15f;
    public float minWaitTime = 4f;
    public float maxWaitTime = 16f;

    public NavMeshAgent agent;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();

        SnapToNavMesh();
        StartCoroutine(WanderRoutine());
    }


    private void SnapToNavMesh()
    {
        if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 2f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
        }
        else
        {
            Debug.LogWarning("Cat could not find NavMesh nearby.");
        }
    }
    
    private IEnumerator WanderRoutine()
    {
        while (true)
        {
            Vector3 target = GetRandomNavMeshPoint(transform.position, wanderRadius);

            if (target != Vector3.zero)
            {
                agent.SetDestination(target);

                // Wait until reached
                yield return new WaitUntil(() =>
                    !agent.pathPending &&
                    agent.remainingDistance <= agent.stoppingDistance &&
                    (!agent.hasPath || agent.velocity.sqrMagnitude == 0f));
            }

            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private Vector3 GetRandomNavMeshPoint(Vector3 origin, float radius)
    {
        for (int i = 0; i < 10; i++) // try 10 times
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += origin;

            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }

        return Vector3.zero;
    }
    
    
    void OnDisable()
    {
        StopAllCoroutines();
    }
}
