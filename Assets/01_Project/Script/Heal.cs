using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Appelé quand on reçoit des dégâts
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} a reçu {damage} points de dégâts. HP restant : {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} est détruit !");
        // Ici tu peux ajouter des effets, animations, destruction du gameObject etc.
        Destroy(gameObject);
    }
}
