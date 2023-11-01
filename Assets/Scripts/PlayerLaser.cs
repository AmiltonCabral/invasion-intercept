using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public GameObject playerLaserImpact;
    public float laserVelocity;
    public int laserDamage;

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().ApplyDamage(laserDamage);
            Instantiate(playerLaserImpact, transform.position, transform.rotation);
            SoundsEffect.instance.impactSound.Play();
            Destroy(this.gameObject);
        }
    }
}
