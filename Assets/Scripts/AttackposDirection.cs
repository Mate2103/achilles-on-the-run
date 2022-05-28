using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackposDirection : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        if (dir < 0)
        {
            transform.position = player.gameObject.transform.position - offset;
        }
        else if (dir >= 0)
        {
            transform.position = player.gameObject.transform.position + offset;
        }

    }
}
