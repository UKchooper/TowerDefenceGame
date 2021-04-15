using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;
    public int Health = 100;
    public int Value = 50;
    public GameObject DeathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.Points[0];
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if(Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += Value;

        GameObject effect = (GameObject)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * Speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavePointIndex >= Waypoints.Points.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = Waypoints.Points[wavePointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
