using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    public Slider healthBar;
    private void Start()//初始化(测试用)
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthBar.value = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth - damage <= 0)
        {
            currentHealth = 0;
        }
        else
            currentHealth -= damage;
        UpdateHealth();
    }

    public void Heal(float heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
            currentHealth += heal;
        UpdateHealth();
    }
}
