using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider hpSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpSlider.maxValue = playerHealth.maxHP;
        hpSlider.value = playerHealth.currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = playerHealth.maxHP;
        hpSlider.value = playerHealth.currentHP;
    }
}
