using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;

    const float MAXHEALTH = 100f;
    float health;
    // Start is called before the first frame update
    private void Start()
    {
        health = MAXHEALTH;
        
    }


    // Update is called once per frame
    void Update()
    {
        void Die()
        {
            GetComponent<Player>().enabled = false;
            GetComponent<Animator>().SetBool("Dead", true);
        }
    }
    void Die()
    {
        GetComponent<Player>().enabled = false;
    }
  
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }

        // UPDATE THE SLIDER
        healthSlider.value = health / MAXHEALTH;
    }
}
