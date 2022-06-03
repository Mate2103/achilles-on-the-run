using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public void EnterGame()
    {
        gameObject.GetComponentInParent<Renderer>().enabled = false;
        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().mute = false;
    }
}
