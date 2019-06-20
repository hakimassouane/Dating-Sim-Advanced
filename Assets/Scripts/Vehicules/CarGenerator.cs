using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
	public GameObject[] carModel;
	private float counter = 0f;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 5) {
        	generateCar();
        	counter = 0;
        }
    }

    void generateCar() {
    	Instantiate(carModel[Random.Range(0, carModel.Length)], transform.position, transform.rotation);
    }
}
