using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPosition : MonoBehaviour
{
    private bool isLocked = false;

    public void moveLeft(int amount){
    	StartCoroutine(smoothMoveLeft(amount, 0.35f));
    }

    public void moveRight(int amount){
    	StartCoroutine(smoothMoveRight(amount, 0.35f));
    }

    public IEnumerator smoothMoveLeft(int amount, float overTime)
	{
        if (isLocked == false) {
            isLocked = true;
            Vector3 targetPosition = new Vector3(gameObject.transform.position.x - amount, gameObject.transform.position.y, gameObject.transform.position.z);
            float startTime = Time.time;
            while(Time.time < startTime + overTime)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, (Time.time - startTime)/overTime);
                yield return null;
            }
            gameObject.transform.position = targetPosition;
            isLocked = false;
        }
		
	}

    public IEnumerator smoothMoveRight(int amount, float overTime) {
        if (isLocked == false) {
            isLocked = true;
            Vector3 targetPosition = new Vector3(gameObject.transform.position.x + amount, gameObject.transform.position.y, gameObject.transform.position.z);
            float startTime = Time.time;
            while(Time.time < startTime + overTime)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, (Time.time - startTime)/overTime);
                yield return null;
            }
            gameObject.transform.position = targetPosition;
            isLocked = false;
        }
    	
    }
}
