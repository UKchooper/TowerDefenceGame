using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("General")]
    public float range = 15;

    [Header("Use Bullets (default)")]
    public GameObject BulletPrefab;
    public float FireRate = 1f;

    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool UseLaser = false;
    public LineRenderer LineRenderer;

    [Header("Unity Setup Fields")]
    public Transform PartToRotate;
    public Transform FirePoint;
    public float TurnSpeed = 10f;
    public string EnemyTag = "Enemy";

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if(target == null)
        {
            if (UseLaser)
            {
                if (LineRenderer.enabled)
                {
                    LineRenderer.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (UseLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / FireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    private void LockOnTarget()
    {
        //Target lock on
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Laser()
    {
        if (!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
        }

        LineRenderer.SetPosition(0, FirePoint.position);
        LineRenderer.SetPosition(1, target.position);
    }
    private void Shoot()
    {
        GameObject BulletGameObject = (GameObject)Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = BulletGameObject.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
