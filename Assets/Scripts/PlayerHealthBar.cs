using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        slider.gameObject.active = true;
        slider.wholeNumbers = true;
    }
    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;
        print($"{health}");
    }


   
}
