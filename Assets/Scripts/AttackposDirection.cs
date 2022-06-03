using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackposDirection : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    void Update()
    {
        Vector3 dir = Camera.main.ViewportToScreenPoint(Input.mousePosition);
        if (dir.x < 0)
        {
            transform.position = player.gameObject.transform.position - offset;
        }
        else if (dir.x >= 0)
        {
            transform.position = player.gameObject.transform.position + offset;
        }

    }
}
