using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 70f;
    public GameObject ImpactEffect;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        //Destroy(target.gameObject);
        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }
}
