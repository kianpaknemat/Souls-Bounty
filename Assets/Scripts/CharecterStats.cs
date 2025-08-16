using UnityEngine;

public class CharecterStats : MonoBehaviour
{

    public Stat damage;
    public Stat maxHealth;

    [SerializeField] private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth.getValue();
    }

    public void takeDamage(int _damage)
    {
        currentHealth -= _damage;
    }
}
