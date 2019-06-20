using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanActionButtons : MonoBehaviour
{
    public void cleanButtons() {
    	foreach(Transform child in transform)
    	{
    		if (child.gameObject.name != "QuitBuildingButton") {
    			GameObject.Destroy(child.gameObject);
    		}
    	}
    }
}
