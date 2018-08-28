using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    private GameObject gameManager;
    private GameObject player;
    private bool megaJumpActive = false;
    private GameObject magnet;
    private SphereCollider spherecol;
    private bool magnetTriggered;

    
    /*RadiusKill Variablen*/
    public float radius = 0.02f;

    
    /*Life PowerUp*/
    public void UseHealthPU() {
		
        gameManager = GameObject.Find("GameManager");
        Debug.Log("Leben bevor Nutzung des PU" + gameManager.GetComponent<Health>().GetCurrentHealth());

        if (gameManager.GetComponent<Health>().GetCurrentHealth() < 5) {
            gameManager.GetComponent<Health>().HealPlayer(1);
            GameObject.Find("Player").GetComponent<Inventory>().RemoveLife();

        } else {
            Debug.Log("Player hat schon volles Leben");
        }
        
        Debug.Log("Leben nach Nutzung des PU" + gameManager.GetComponent<Health>().GetCurrentHealth());

    }

    /*MegaJump PowerUp*/
    public void UseMegaJumpPU() {   

        if (megaJumpActive == false) {
			
            ActivateMegaJump();
            GameObject.Find("Player").GetComponent<Inventory>().RemoveMegaJump();
			
        } else {
			
            Debug.Log("MegaJump ist schon aktiviert");
			
        }
        
    }

    /*Magnet PowerUp*/
    public void UseMagnetPU() {
		
        if(magnetTriggered == false) {
			
            ActivateMagnet();
            GameObject.Find("Player").GetComponent<Inventory>().RemoveMagnet();
			
        } else {
            Debug.Log("Magnet ist schon aktiviert");
        }
        
    }

    /*Bomb PowerUp*/
    public void UseBombPU() {
		
        RadiusKill();
        GameObject.Find("Player").GetComponent<Inventory>().RemoveBomb();
		
    }

    public void ActivateMegaJump() {
		
        Debug.Log("MegaJump ist aktiviert");
        megaJumpActive = true;
        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().setJumpForce(100);
        Invoke("DeactivateMegaJump", 5);
		
    }

    public void DeactivateMegaJump(){
		
        player.GetComponent<PlayerController>().setJumpForce(70);
        Debug.Log("MegaJump ist deaktiviert");
        megaJumpActive = false;
        
    }

    public void ActivateMagnet() {
		
        magnet = GameObject.Find("Magnet");
        spherecol = magnet.GetComponent<SphereCollider>();
        magnetTriggered = true;
        spherecol.enabled = true;
        Debug.Log("Magnet ist an");
        Invoke("DeactivateMagnet", 5);
		
    }

    public void DeactivateMagnet() {
		
        spherecol.enabled = false;
        Debug.Log("Magnet ist aus");
        magnetTriggered = false;
		
    }

    public void RadiusKill() {
		
        GameObject player = GameObject.Find("Player");
        GameObject destroysphere = GameObject.Find("RadiusKillCircle");
        Destroy(destroysphere);
        Vector3 enemyposition;

        Collider[] enemies = Physics.OverlapSphere(player.transform.position,30f);

        foreach (Collider element in enemies) {
			
            if (element.gameObject.tag == "Enemy") {
                Debug.Log("Zerstöre Gegner");
                enemyposition = element.gameObject.transform.position;
                //LightDestroyEffect(enemyposition);
                Destroy(element.gameObject);
            }
			
        }
        
    }

    void OnDrawGizmos() {

        GameObject player = GameObject.Find("Player");
        Gizmos.color = Color.red;

        if (player != null){
            Gizmos.DrawWireSphere(player.transform.position, 30f);
        }
        
    }


    public void DrawRadiusKillCircle(){
		
        GameObject player = GameObject.Find("Player");
        GameObject destroysphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer r_sphere = destroysphere.GetComponent<Renderer>();
        Color color = Color.red;
        color.a = 0.6f;

        destroysphere.name = "RadiusKillCircle";
        destroysphere.transform.SetParent(player.transform);
        destroysphere.transform.localPosition = new Vector3(0f, -0.8f, 0f);
        destroysphere.transform.localScale = new Vector3(30f, 0f, 30f);
        r_sphere.material.color = color;
        r_sphere.material.shader = Shader.Find("Transparent/Diffuse");
		
    }

    /*private void LightDestroyEffect(Vector3 pos, GameObject enemy)
    {
       
        ParticleSystem parsys;
        
        
        
        //lighting.transform.localScale = new Vector3(transform.localScale.x + transform.localScale.x * scalingFactor * Time.deltaTime, transform.localScale.y + transform.localScale.y * scalingFactor * Time.deltaTime, transform.localScale.z + transform.localScale.z * scalingFactor * Time.deltaTime);
    }*/

    
}
