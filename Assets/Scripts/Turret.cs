using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float shootDistance = 1f;
    [SerializeField] private float shootCooldown = 1f;
    [SerializeField] private int damage = 1;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Transform projectileSpawnpoint;
    [SerializeField] private Transform gun;
    [SerializeField] private int cost = 10;

    public int Cost { get => cost; }

    private Transform currTarget = null;
    private bool canShoot = true;

    private void Update()
    {
        // get all objects spawned
        List<GameObject> spawnedObjects = GameManager.SpawnSystem.SpawnedObjects;

        // find closest one
        float shortestDist = float.MaxValue;
        GameObject closestObject = null;
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj == null) continue;
            float currDist = Vector2.Distance(transform.position, obj.transform.position);
            if (currDist < shortestDist)
            {
                shortestDist = currDist;
                closestObject = obj;
            }
        }

        // check if in range
        if (shortestDist < shootDistance)
        {
            // if so, aim towards target
            currTarget = closestObject.transform;

            // if off cooldown, shoot towards target
            if (canShoot)
            {
                Projectile proj = Instantiate(projectilePrefab, projectileSpawnpoint.position, Quaternion.identity);
                Vector2 dirToTarget = (currTarget.position - transform.position).normalized;
                proj.GetComponent<Rigidbody2D>().velocity = dirToTarget * projectileSpeed;
                proj.Damage = damage;
                StartCoroutine(ShootCooldown());
            }
        }
    }

    private void FixedUpdate()
    {
        if (currTarget != null)
        {
            Vector2 dirToTarget = (currTarget.position - transform.position).normalized;
            gun.rotation = Quaternion.FromToRotation(Vector3.left, dirToTarget);
        }
    }

    private IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
