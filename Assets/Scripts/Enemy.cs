using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyLaser;
    public Transform shotLocal;
    public GameObject explosionEfect;
    public int shipInpactDamage;
    public float enemyVelocity;
    public int maxLife;
    public int actualLife;
    public int scoreValue;
    public float shotCooldown;
    public float shotTimeLeft;
    public bool enabledEnemy;
    // Start is called before the first frame update
    void Start()
    {
        enabledEnemy = false;
        actualLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        if (enabledEnemy) ShotLaser();
    }

    public void EnableEnemy()
    {
        enabledEnemy = true;
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.up * enemyVelocity * Time.deltaTime);
    }

    private void ShotLaser()
    {
        shotTimeLeft -= Time.deltaTime;
        if (shotTimeLeft <= 0)
        {
            Instantiate(enemyLaser, shotLocal.position, shotLocal.rotation);
            shotTimeLeft = shotCooldown;
        }
    }

    public void ApplyDamage(int damage)
    {
        actualLife -= damage;
        if (actualLife <= 0)
        {
            GameManager.instance.addScore(scoreValue);
            Instantiate(explosionEfect, transform.position, transform.rotation);
            SoundsEffect.instance.explosionSound.Play();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().ApplyDamage(shipInpactDamage);
            Instantiate(explosionEfect, transform.position, transform.rotation);
            SoundsEffect.instance.explosionSound.Play();
            Destroy(this.gameObject);
        }
    }
}
