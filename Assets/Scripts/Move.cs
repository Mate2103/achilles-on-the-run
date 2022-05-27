using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeReference] private GameObject coin;
    [SerializeReference] private float speed;

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 0.3f);
        coin.transform.position = new Vector3(coin.transform.position.x, y - 1.75f, 0);
    }
}
