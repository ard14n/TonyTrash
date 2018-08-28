using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Gesundheitssystem des Spielermodels, mit Animation bei Gegnerkontakt, sowie "Unverwundbarkeit" nach Treffer, dass Spieler nicht durch Knockback pingpongartig in den Tod geschubst wird.
 * Verwaltung der Schadenswerte der Gegner.
 * Gesundheit des Spielers auffüllen nach aufheben des Heal-Power-Ups.
 * 
 * Marc Rosenkranz - 143025
 * Ardian Jahja
 **/

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
	public PlayerController thePlayer;
	public float invinceLength;
    public float invincCount;
	public Renderer playerRenderer1;
    public Renderer playerRenderer2;
    private float flashCounter;
    public float flashLength = 1;

    void Start () {
        currentHealth = maxHealth;
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Unverwundbarkeit und Animation bei Gegnertreffer

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

    // Manimulaption der Health - Werte und Ausführung des Knockbacks im Movement Script, sowie "sterben" des Spielers durch Ausschalten des Renders.
    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincCount <=0 )
        { 
            currentHealth -= damage;
            thePlayer.Knockback(direction);
			invincCount = invinceLength;
			playerRenderer1.enabled = false;
            playerRenderer2.enabled = false;
			flashCounter = flashLength;
        }
    }

    //Manipulation der Health-Werte durch healamount vom Power-Up.
    public void HealPlayer(int healamount)
    {

        currentHealth += healamount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
       
    }
}
