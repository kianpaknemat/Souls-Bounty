using UnityEngine;

public class CharecterStats : MonoBehaviour
{

    public Stat damage;
    public Stat maxHealth;
    public Stat stregth;

    [SerializeField] private int currentHealth;
    protected virtual void Start()
    {
        currentHealth = maxHealth.getValue();
    }


    public virtual void doDamage(CharecterStats _targetStat) {
        int totalDamagev = damage.getValue() +  stregth.getValue();
        _targetStat.takeDamage(totalDamagev);
    }
    public virtual void takeDamage(int _damage)
    {
        currentHealth -= _damage;
    }
}
