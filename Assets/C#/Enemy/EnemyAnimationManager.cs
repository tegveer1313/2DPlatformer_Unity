using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private Animator enemyAnimator;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void MovementAnimations(float horizontalVelocity)
    {
        if (horizontalVelocity > 0.1f || horizontalVelocity < -0.1f)
        {
            enemyAnimator.SetInteger("MovementState", 2);
        }
        else
        {
            enemyAnimator.SetInteger("MovementState", 0);
        }
    }

    public void AttackAnimation()
    {
        enemyAnimator.SetTrigger("Attack");
    }
}
