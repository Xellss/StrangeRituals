using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
    public int HealthPoints = 100;
    public bool IsEnemy = false;
    public string LevelToLoadOnDeath;

    private int maxHealth;

    void Awake()
    {
        maxHealth = HealthPoints;
    }

    void Update()
    {
        CheckStatus();
    }

    public void AddHealth(int health)
    {
        HealthPoints += health;

        if (HealthPoints > maxHealth)
            HealthPoints = maxHealth;
    }

    public void DecreaseHealth(int damage)
    {
        HealthPoints -= damage;
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (HealthPoints <= 0)
            Dead();
    }

    private void Dead()
    {
        if (IsEnemy)
            Destroy(this.gameObject);
        else
            Application.LoadLevel(LevelToLoadOnDeath);
    }
}
