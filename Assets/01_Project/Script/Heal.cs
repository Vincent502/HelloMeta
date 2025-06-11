using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Appel� quand on re�oit des d�g�ts
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} a re�u {damage} points de d�g�ts. HP restant : {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} est d�truit !");
        // Ici tu peux ajouter des effets, animations, destruction du gameObject etc.
        Destroy(gameObject);
    }
}
