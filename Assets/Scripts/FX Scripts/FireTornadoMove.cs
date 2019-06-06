using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornadoMove : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.5f;
    public float damageCount = 10f;
    public GameObject fireExplosion;

    private EnemyHealth enemyHealth;
    private bool collided;

    private float speed = 3f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }

    void Update()
    {
        Move();
        CheckForDamage();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    void CheckForDamage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (Collider c in hits)
        {
            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;
        }
        if (collided)
        {
            enemyHealth.TakeDamage(damageCount);
            Vector3 temporaryPosition = transform.position;
            temporaryPosition.y += 2f;
            Instantiate(fireExplosion, temporaryPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}