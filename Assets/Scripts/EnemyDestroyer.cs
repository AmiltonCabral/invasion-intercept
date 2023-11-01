using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameObj = other.gameObject;
        if (gameObj.CompareTag("Enemy"))
        {
            Destroy(gameObj);
        }
    }
}
