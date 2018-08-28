using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Ardian Jahja - 342047
 * 
 * Das Array powerUpInventory stell das Inventar dar
 * [0] ist LifePowerUp
 * [1] ist BombPowerUp
 * [2] ist MegaJumpPowerUp
 * [3] ist MagnetPowerUp 
 * 
 */


public class Inventory : MonoBehaviour
{

    private int[] powerUpInventory;
    private PowerUpManager puManager;


    // Use this for initialization
    void Start() {

        powerUpInventory = new int[4];

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {

            Debug.Log("Health pressed");

            if (powerUpInventory[0] > 0) {

                puManager = GetComponent<PowerUpManager>();
                puManager.UseHealthPU();

            } else {

                Debug.Log("Keine Health-Powerups vorhanden");

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {

            if (powerUpInventory[1] > 0) {

                Debug.Log("Draw RadiusKillCircle");
                puManager = GetComponent<PowerUpManager>();
                puManager.DrawRadiusKillCircle();

            } else {
                Debug.Log("Keine Bomben-PowerUps vorhanden");
            }
           

        } else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            
            if (powerUpInventory[1] > 0) {

                Debug.Log("RadiusKill Enemies within Circle");
                puManager = GetComponent<PowerUpManager>();
                puManager.UseBombPU();

            } else {

                Debug.Log("Keine Bomben-PowerUps vorhanden");

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {

            Debug.Log("MegaJump pressed");

            if (powerUpInventory[2] > 0) {

                puManager = GetComponent<PowerUpManager>();
                puManager.UseMegaJumpPU();

            } else {

                Debug.Log("Keine MegaJump-Powerups vorhanden");

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {

            Debug.Log("Magnet PU pressed");

            if (powerUpInventory[3] > 0) {

                puManager = GetComponent<PowerUpManager>();
                puManager.UseMagnetPU();

            } else {

                Debug.Log("Keine Magnet-Powerups vorhanden");

            }
        }

    }

    /* Funktionen zum Hinzufügen des Inventars */
    public void AddLife() {

        powerUpInventory[0] += 1;
        Debug.Log("LifePU +1");

    }

    public void AddBomb() {

        powerUpInventory[1] += 1;
        Debug.Log("BombPU +1");

    }

    public void AddMegaJump() {

        powerUpInventory[2] += 1;
        Debug.Log("MegaJumpPU +1");

    }

    public void AddMagnet() {

        powerUpInventory[3] += 1;
        Debug.Log("MagnetPU +1");

    }

    /* Funktionen zum Anzeigen des Inventars */
    public void showLife() {

        Debug.Log(powerUpInventory[1]);

    }

    public void showBombs() {

        Debug.Log(powerUpInventory[0]);

    }

    public void showMegaJump() {

        Debug.Log(powerUpInventory[3]);

    }

    public void showMagnet() {

        Debug.Log(powerUpInventory[1]);

    }

    /* Funktionen zum Entfernen aus dem Inventar */
    public void RemoveLife() {

        powerUpInventory[0] -= 1;

    }

    public void RemoveBomb() {

        powerUpInventory[1] -= 1;

    }

    public void RemoveMegaJump() {

        powerUpInventory[2] -= 1;

    }

    public void RemoveMagnet() {

        powerUpInventory[3] -= 1;

    }
}
