using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public GameObject enemyLaserImpact;
    public float laserVelocity;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveLaser();
    }

    private void MoveLaser()
    {
        transform.Translate(Vector3.up * laserVelocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().ApplyDamage(damage);
            Instantiate(enemyLaserImpact, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
