using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    public Slider healthBar;

    public void UpdateHealth()
    {
        healthBar.value = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealth();
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        UpdateHealth();
    }
}
