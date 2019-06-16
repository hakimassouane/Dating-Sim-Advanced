using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleScript : MonoBehaviour
{

	private const float REAL_SECONDS_PER_INGAME_DAY = 15f;
	private const float ROTATE_TIME = 360;
	private const float SECONDS_IN_MINUTES = 60;
	private int currentDay = 1;

	private float day;
	public Text dateText;
	public Light sunLight;
	public Light pointLight;
	public Material daySkybox;
	public Material nightSkybox;

    // Start is called before the first frame update
    void Start()
    {
       sunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    	// Rotate sunLight
    	this.gameObject.transform.Rotate((ROTATE_TIME / REAL_SECONDS_PER_INGAME_DAY) / SECONDS_IN_MINUTES,0,0);
    	// Update day duration
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        // Check if half of the day has been reached
        if (day > 0.5) {
        	pointLight.intensity = 10;
        }
       
        
        if (day > 1) {
        	print("a day has passed");
        	day = 0;
        	currentDay += 1;
        	dateText.text = "Jour " + currentDay;
        	pointLight.intensity = 0;
        }
    }
}
