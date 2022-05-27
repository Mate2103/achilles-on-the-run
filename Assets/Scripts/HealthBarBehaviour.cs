using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private Color Low;
    [SerializeField] private Color High;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Camera main;

    private void Start()
    {
        Slider.wholeNumbers = true;
    }
    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Color c = Color.Lerp(Low, High, Slider.normalizedValue);
        c.a = 1;
        Slider.fillRect.GetComponentInChildren<Image>().color = c;

    }

    void Update()
    {
        Slider.transform.position = main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
