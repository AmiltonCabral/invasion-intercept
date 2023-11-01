using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Slider playerLifeSlider;
    public int maxLife;
    public int actualLife;
    public bool hasShield;
    // Start is called before the first frame update
    void Start()
    {
        actualLife = maxLife;
        playerLifeSlider.maxValue = maxLife;
        playerLifeSlider.value = actualLife;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage(int damage)
    {
        if (!hasShield)
        {
            actualLife -= damage;
            playerLifeSlider.value = actualLife;
        }
        if (actualLife <= 0)
        {
            FindObjectOfType<PlayerController>().alivePlayer = false;
            GameManager.instance.GameOver();
            Debug.Log("Game over");
        }
    }
}
