using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Zeus : MonoBehaviour
{
    private float health;
    public float maxHealth;
    private bool isBossFight = false;
    public Slider slider;

    public ArrowBehaviour Lightning1;
    public ArrowBehaviour Lightning2;

    public Transform LaunchOffset;
    public Transform LaunchOffset2;

    private Animator animator;

    private bool canStart = false;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        slider.GetComponentInParent<SpriteRenderer>().enabled = false;
        slider.gameObject.SetActive(false);
        text.SetActive(false);
        text.transform.GetChild(0).gameObject.SetActive(false);

        health = maxHealth;
        slider.value = health;
        slider.maxValue = maxHealth;
    }
    void Update()
    {
        animator.SetFloat("Health", health);
        if (health < maxHealth && !isBossFight)
        {
            StartBoss();
        }
    }
    public GameObject text;
    public void WriteText()
    {
        if (!isBossFight)
        {
            text.SetActive(true);
            text.transform.GetChild(0).gameObject.SetActive(true);
            canStart = true;
        }
    }
    public void TakeDamage(float damage)
    {
        if (canStart || isBossFight)
        {
            health -= damage;
            slider.value = health;
            if (health <= 0) { StartCoroutine(ZeusDeath()); }
            canStart = false;
        }
    }
    IEnumerator ZeusDeath()
    {
        isBossFight = false;
        CancelInvoke("Shoot");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        print("d");
        yield return new WaitForSeconds(3.0f);
        print("s");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartBoss()
    {
        text.SetActive(false);
        text.transform.GetChild(0).gameObject.SetActive(false);

        animator.SetBool("isBossFight", true);
        isBossFight = true;

        slider.gameObject.SetActive(true);
        slider.GetComponentInParent<SpriteRenderer>().enabled = true;

        InvokeRepeating("Shoot", 1.0f, 1.2f);
    }
    public void Shoot()
    {
        if (isBossFight)
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
}
