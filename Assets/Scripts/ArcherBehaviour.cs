using UnityEngine;
using System.Threading;

public class ArcherBehaviour : MonoBehaviour
{
    private float Hitpoints;
    [SerializeField] private float MaxHitponts = 10;
    [SerializeField] private HealthBarBehaviour HealthBar;

    public ArrowBehaviour ArrowPrefab;
    public Transform LaunchOffset;

    void Start()
    {
        Hitpoints = MaxHitponts;
        HealthBar.SetHealth(Hitpoints, MaxHitponts);
        InvokeRepeating("ShootArrow", 0.5f, 2.2f);
    }
    private void ShootArrow()
    {
        Instantiate(ArrowPrefab, LaunchOffset.position, transform.rotation);
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.SetHealth(Hitpoints, MaxHitponts);
        if (Hitpoints <= 0) Destroy(gameObject);
    }
}
