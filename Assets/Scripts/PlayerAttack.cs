using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    private float timeToAttack;
    public float startTimeToAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    void Update()
    {
        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].tag == "Archer")
                {
                    enemiesToDamage[i].GetComponent<ArcherBehaviour>().TakeHit(damage);
                }
                else if (enemiesToDamage[i].tag == "Zeus")
                {
                    enemiesToDamage[i].GetComponent<Zeus>().TakeDamage(20);
                }

            }
        }

        timeToAttack = startTimeToAttack;

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
