using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealthBar>().TakeHit(4);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 31)
        {
            Destroy(gameObject);
        }
    }
    


    public Vector3 fv;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(fv, ForceMode2D.Impulse);
    }

    void Update()
    {
        this.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg, Vector3.forward);
    }
}
