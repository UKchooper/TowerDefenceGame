using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.Points[0];
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
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = Waypoints.Points[wavePointIndex];
    }
}
