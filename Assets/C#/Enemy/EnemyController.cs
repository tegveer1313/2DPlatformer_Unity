using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    //[SerializeField] private float gorundCheckRadius = 0.1f;
    //[SerializeField] private Transform grounCheck;
    //[SerializeField] private LayerMask groungLayer;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform shootObj;


    Transform currentPoint;
    EnemyAnimationManager eAM;
    Rigidbody2D enemyRB;
    Attack attack;
    Health health;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        attack = GetComponent<Attack>();
        health = GetComponent<Health>();
        currentPoint = pointB;
        eAM = GetComponent<EnemyAnimationManager>();
    }

    private void Update()
    {
        if(health.currentHealth >= 0)
        {
            if (!IsPlayerInRange())
            {
                Vector2 point = currentPoint.position - transform.position;
        
                if(currentPoint == pointB.transform)
                {
                    enemyRB.velocity = new Vector2(movementSpeed, 0f);
                }
                else
                {
                    enemyRB.velocity = new Vector2(-movementSpeed, 0f);
                }


                ChangePoints();
                FlipCharacter();
        
            
            }
            else
            {
                eAM.AttackAnimation();
                //attack.Fire(shootObj.position);
            }

            eAM.MovementAnimations(enemyRB.velocity.x);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void ChangePoints()
    {
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    void FlipCharacter()
    {
        if (enemyRB.velocity.x > 0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (enemyRB.velocity.x < 0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    bool IsPlayerInRange()
    {
        return Physics2D.OverlapCircle(transform.position, 2.7f, playerLayer);
    }
}
