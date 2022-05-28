using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    private int coins = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinsText.text =  $"Menekult segely: {coins} drachma";

            GameObject.FindGameObjectWithTag("Zeus").GetComponent<Zeus>().StartBoss();
            GameObject.FindGameObjectWithTag("Zeus").GetComponent<Zeus>().TakeDamage(52);
        }
    }
}
