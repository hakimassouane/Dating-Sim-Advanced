using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelManager : MonoBehaviour
{
	private static TravelManager _instance;

	public static TravelManager Instance {
		get {
			if (_instance == null) {
				_instance = new TravelManager();
			}
			return _instance;
		}
	}

	public static GameObject lastVisitedBuilding = null;

	public GameObject getLastVisitedBuilding() {
		return lastVisitedBuilding;
	}

	public void setLastVisitedBuilding(GameObject newBuilding) {
		lastVisitedBuilding = newBuilding;
	}
}
