using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    //private GameObject archer;
    //private GameObject target;

    //public float speed = 10.0f;

    //private float targetX, archerX;

    //private float dist;
    //private float nextX;
    //private float baseY;
    //private float height;
    //private void Start()
    //{
    //    archer = GameObject.FindGameObjectWithTag("Archer");
    //    target = GameObject.FindGameObjectWithTag("Player");
    //}
    //private void Update()
    //{
    //    archerX = archer.transform.position.x+3;
    //    targetX = target.transform.position.x;

    //    dist = targetX - archerX;
    //    nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
    //    baseY = Mathf.Lerp(archer.transform.position.y, target.transform.position.y, (nextX - archerX) / dist);
    //    height = 2 * (nextX - archerX) * (nextX - targetX) / (-0.25f * dist * dist);

    //    Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
    //    transform.rotation = LookAtTarget(movePosition - transform.position);
    //    transform.position = movePosition;

    //    if (transform.position == target.transform.position)
    //    {
    //        //deal damage
    //    }
    //}
    //public static Quaternion LookAtTarget(Vector2 rotation)
    //{
    //    return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, -rotation.x) * Mathf.Rad2Deg);
    //}




    //public float speed = 50.0f;
    private Rigidbody2D rb;
    public float MaxHealth;
    private float CurrentHealt;
    private GameObject player;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeHit(4);
        }
        else if (collision.gameObject.layer == 31)
        {
            Destroy(gameObject);
        }
    }
    public void TakeHit(float damage)
    {
        CurrentHealt -= damage;
        player.GetComponent<PlayerHealthBar>().SetHealth(CurrentHealt, MaxHealth);
        if (CurrentHealt <= 0) player.GetComponent<Movement>().SetBackToSpawn(MaxHealth);
    }


    public Vector3 fv;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        //this.transform.Rotate(new Vector3(0, 0, 360.0f - Vector3.Angle(this.transform.right, fv.normalized)));
        rb.AddForce(fv, ForceMode2D.Impulse);
    }

    void Update()
    {
        this.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg, Vector3.forward);
    }
}
