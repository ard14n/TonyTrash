using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour {

    private Transform player;
    private Transform weather;
	
    public float weatherHeight = 15f;
    public float rainyLightIntensity = 0.05f;
    public float sunnyIntensity = 1;
    public float fogChangeSpeed = 0.1f;


	// Use this for initialization
	void Start () {

        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        player = playerGameObject.transform;

        GameObject weatherGameObject = GameObject.FindGameObjectWithTag("Weather");
        weather = weatherGameObject.transform;

        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.001f;

        DarkenScene();
        
	}

    // Update is called once per frame
    void Update() {
       
        weather.transform.position = new Vector3(player.position.x, player.position.y+weatherHeight, player.position.z);
        
    }

    
    private void DarkenScene() {

        GetComponent<Light>().intensity = rainyLightIntensity;

    }
    
    
    


    

    
}
