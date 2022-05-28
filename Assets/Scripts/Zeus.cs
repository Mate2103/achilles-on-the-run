using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zeus : MonoBehaviour
{
    private float health;
    public float maxHealth;
    private bool isBossFight;
    public Slider slider;

    public ArrowBehaviour Lightning1;
    public ArrowBehaviour Lightning2;

    public Transform LaunchOffset;
    public Transform LaunchOffset2;

    private Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        slider.GetComponentInParent<SpriteRenderer>().enabled = false;
        slider.gameObject.SetActive(false);
        health = maxHealth;
        slider.value = health;
        slider.maxValue = maxHealth;
    }
    void Update()
    {
        animator.SetFloat("Health", health);
    }
    public void TakeDamage(float damage)
    {
        if (isBossFight)
        {
            health -= damage;
            slider.value = health;
            if (health <= 0) ZeusDeath();
        }
    }
    public void ZeusDeath()
    {
        
    }
    public void StartBoss()
    {
        animator.SetBool("isBossFight", true);
        isBossFight = true;

        slider.gameObject.SetActive(true);
        slider.GetComponentInParent<SpriteRenderer>().enabled = true;

        InvokeRepeating("Shoot", 1.0f, 1.2f);
    }
    public void Shoot()
    {
        if (health > maxHealth / 2)
            Instantiate(Lightning1, LaunchOffset.position, transform.rotation);
        else if (health <= maxHealth / 2)
        {
            Instantiate(Lightning2, LaunchOffset.position, transform.rotation);
            Lightning2.fv = new Vector3(21, 3.2f, 0);
            Lightning2.GetComponent<SpriteRenderer>().flipX = true;

            Instantiate(Lightning2, LaunchOffset2.position, transform.rotation);
            Lightning2.fv = new Vector3(-21, 3.2f, 0);
            Lightning2.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
