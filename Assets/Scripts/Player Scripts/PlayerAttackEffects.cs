using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{
    public GameObject groundImpactSpawn, groundImpactPrefab;
    public GameObject kickFXSpawn, kickFXPrefab;
    public GameObject fireTornadoSpawn, fireTornadoPrefab;
    public GameObject fireShieldSpawn, fireShieldPrefab;
    public GameObject healFXPrefab;
    public GameObject thunderFXPrefab;

    void GroundImpact()
    {
        Instantiate(groundImpactPrefab, groundImpactSpawn.transform.position, Quaternion.identity);
    }

    void Kick()
    {
        Instantiate(kickFXPrefab, kickFXSpawn.transform.position, Quaternion.identity);
    }

    void FireTornado()
    {
        Instantiate(fireTornadoPrefab, fireTornadoSpawn.transform.position, Quaternion.identity);
    }

    void FireShield()
    {
        GameObject fireObject = Instantiate(fireShieldPrefab, fireShieldSpawn.transform.position, Quaternion.identity) as GameObject;
        fireObject.transform.SetParent(transform);
    }

    void Heal()
    {
        Vector3 temporary = transform.position;
        temporary.y += 2f;
        GameObject healObject = Instantiate(healFXPrefab, temporary, Quaternion.identity) as GameObject;
        healObject.transform.SetParent(transform);
    }

    void ThunderAttack()
    {
        for(int i = 0; i < 8; i++)
        {
            Vector3 position = Vector3.zero;

            if(i == 0)
            {
                position = new Vector3(transform.position.x - 4f, transform.position.y + 2f, transform.position.z);
            } else if (i == 1)
            {
                position = new Vector3(transform.position.x + 4f, transform.position.y + 2f, transform.position.z);
            } else if (i == 2)
            {
                position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z - 4f);
            } else if (i == 3)
            {
                position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 4f);
            } else if (i == 4)
            {
                position = new Vector3(transform.position.x + 2.5f, transform.position.y + 2f, transform.position.z + 2.5f);
            } else if (i == 5)
            {
                position = new Vector3(transform.position.x - 2.5f, transform.position.y + 2f, transform.position.z + 2.5f);
            } else if (i == 6)
            {
                position = new Vector3(transform.position.x - 2.5f, transform.position.y + 2f, transform.position.z - 2.5f);
            } else if (i == 7)
            {
                position = new Vector3(transform.position.x + 2.5f, transform.position.y + 2f, transform.position.z + 2.5f);
            }

            Instantiate(thunderFXPrefab, position, Quaternion.identity);
        }
    }
}