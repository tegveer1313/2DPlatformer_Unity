using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private InputManager playerInputManger;
    [SerializeField] private PlayerAnimationManager animationManager;

    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth >= 0)
        {
            playerInputManger.AllMovements();
            animationManager.MovementAnimations(playerInputManger.playerRB.velocity.x);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
