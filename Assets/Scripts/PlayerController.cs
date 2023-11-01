using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public Rigidbody2D rb;
    public GameObject playerLaser;
    public Transform uniqueShotLocation;
    public bool hasDoubleShot;
    public bool alivePlayer;
    private Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        hasDoubleShot = false;
        alivePlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (alivePlayer)
        {

            ShotLaser();
        }
    }

    private void MovePlayer()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = input.normalized * velocity;
    }

    private void ShotLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!hasDoubleShot)
            {
                Instantiate(playerLaser, uniqueShotLocation.position, uniqueShotLocation.rotation);
            }
            SoundsEffect.instance.playerLaserSound.Play();
        }
    }
}
