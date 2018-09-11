using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** Gesundheitssystem des Spielermodels, mit Animation bei Gegnerkontakt, sowie "Unverwundbarkeit" nach Treffer, dass Spieler nicht durch Knockback pingpongartig in den Tod geschubst wird.
 * Verwaltung der Schadenswerte der Gegner.
 * Gesundheit des Spielers auffüllen nach aufheben des Heal-Power-Ups.
 * 
 * Marc Rosenkranz - 143025
 * Ardian Jahja
 **/

public class Health : MonoBehaviour {

    public int maxHealth;
    public static int currentHealth;

    public PlayerController thePlayer;

    public float invinceLength;
    public float invincCount;

    public Renderer playerRenderer1;
    public Renderer playerRenderer2;
    private float flashCounter;
    public float flashLength = 1;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public GameObject totEffect;

    public Slider healthbar;

    

    // Use this for initialization
    void Start () {
        
        currentHealth = maxHealth;
        healthbar.value = 5;
        respawnPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (invincCount > 0)
        {
            invincCount -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if ( flashCounter <= 0)
            {
                playerRenderer1.enabled = !playerRenderer1.enabled;
                playerRenderer2.enabled = !playerRenderer2.enabled;
                flashCounter = flashLength;
            }
            if(invincCount <= 0)
            {
                playerRenderer1.enabled = true;
                playerRenderer2.enabled = true;
            }
        }
	}

    public void Respawn()
    {
      
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
       
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(totEffect, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;
        healthbar.value = CalcHealth();

        invincCount = invinceLength;
        playerRenderer1.enabled = false;
        playerRenderer2.enabled = false;
        flashCounter = flashLength;


    }

    

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincCount <= 0 )
        { 
            currentHealth -= damage;
            healthbar.value = CalcHealth();

            if (currentHealth <= 0)
            {
                Respawn();

            } else {
                thePlayer.Knockback(direction);
                invincCount = invinceLength;

                playerRenderer1.enabled = false;
                playerRenderer2.enabled = false;

                flashCounter = flashLength;
            }
        }

            
    }

    public void HealPlayer(int healamount)
    {

        currentHealth += healamount;
        healthbar.value = CalcHealth();
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
       
    }

    public void SetSpawnpoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public float CalcHealth()
    { 
        return (float)currentHealth / 5;
    }
}
