using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZeus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Zeus").GetComponent<Zeus>().StartBoss();
    }
}
