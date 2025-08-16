using UnityEngine;

public class CharecterStats : MonoBehaviour
{

    public Stat damage;
    public Stat maxHealth;
    public Stat strength;

    [SerializeField] private int currentHealth;
    protected virtual void Start()
    {
        currentHealth = maxHealth.getValue();
    }


    public virtual void doDamage(CharecterStats _targetStat) {
        int totalDamagev = damage.getValue() +  strength.getValue();
        _targetStat.takeDamage(totalDamagev);
    }
    public virtual void takeDamage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {

    }
}
