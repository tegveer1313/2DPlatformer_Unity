using UnityEngine;

public class Health : MonoBehaviour
{
    float maxHealth = 100f;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  
    }
}
