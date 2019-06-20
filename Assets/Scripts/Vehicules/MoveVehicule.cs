using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicule : MonoBehaviour
{
	private Vector3 newPosition;
	private Vector3 startPosition;
	private Vector3 endPosition;
	public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        startPosition = newPosition;
        endPosition = new Vector3(startPosition.x + 250, startPosition.y, startPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
    	print(startPosition);
    	transform.position = Vector3.MoveTowards(startPosition, endPosition, 0.5f);
    	startPosition = transform.position;
    	if (transform.position == endPosition) {
    		Destroy(gameObject);
    	}
    }
}
