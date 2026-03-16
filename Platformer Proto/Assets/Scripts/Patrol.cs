using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Tooltip("The transform to which the enemy will pace back and forth to.")]
    public Transform[] patrolPoints;

    private int currentPatrolPoint = 0;

    private RefactorEnemy refractorEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        refractorEnemy = GetComponent < RefactorEnemy>();
    }

    public void PatrolManager() 
    {
        Vector3 moveToPoint = patrolPoints[currentPatrolPoint].position;
        transform.position = Vector3.MoveTowards(transform.position, moveToPoint, refractorEnemy.enemyStats.walkSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveToPoint) < 0.01f)
        {
            currentPatrolPoint++;
            if (currentPatrolPoint > patrolPoints.Length - 1)
            {
                currentPatrolPoint = 0;
            }
        }
    }
}
