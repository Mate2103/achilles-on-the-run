using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public float MaxHealth;
    private float CurrentHealt;
    void Start()
    {
        //slider.gameObject.active = true;
        slider.wholeNumbers = true;
        CurrentHealt = MaxHealth;
    }
    //public void SetHealth(float health, float maxHealth)
    //{
    //    slider.value = health;
    //    slider.maxValue = maxHealth;
    //}


    public void TakeHit(float damage)
    {
        CurrentHealt -= damage;

        
        slider.value = CurrentHealt;
        slider.maxValue = MaxHealth;

        if (CurrentHealt <= 0)
        {
            print("dead");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().SetBackToSpawn();
            CurrentHealt = MaxHealth;
            slider.value = CurrentHealt;
        }
    }



}
