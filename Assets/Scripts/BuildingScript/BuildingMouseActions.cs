using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingMouseActions : MonoBehaviour
{
    private Outline outscript;

    /* mouse related variables */
	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    /* Opening pannel related variables */
    public GameObject buildingPanel;
    public Text buildingNameString;
    public string buildingName;
    public GameObject buildingGameObject;

    // Constants
    private float DISTANCE_TO_TIME_RATIO = 3.5f;
    

	void Start ()
	{
		outscript = gameObject.GetComponent<Outline>();
	}

    void OnMouseEnter()
    {
        if(!EventSystem.current.IsPointerOverGameObject()) {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            outscript.OutlineWidth = 10;
        }
    	
    }

    void OnMouseExit()
    {
        if(!EventSystem.current.IsPointerOverGameObject()) {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            outscript.OutlineWidth = 0;
        }
    	
    }

    void OnMouseDown()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        outscript.OutlineWidth = 0;
        if(!EventSystem.current.IsPointerOverGameObject()) {
            buildingPanel.SetActive(true);
            buildingNameString.text = buildingName; 
            travel();
        }
    }

    void travel()
    {
        if (TravelManager.Instance.getLastVisitedBuilding()) {
            Vector3 targetPosition = buildingGameObject.transform.position;
            Vector3 currentBuildingPosition = TravelManager.Instance.getLastVisitedBuilding().transform.position;
            float distance = Vector3.Distance(targetPosition, currentBuildingPosition);
            int timeConsumed = Mathf.FloorToInt(distance / DISTANCE_TO_TIME_RATIO);
            int randomTime = Random.Range(timeConsumed, (timeConsumed * 2) + 1);

            TimeManager.Instance.addMinutes(randomTime);
        } else {
            TimeManager.Instance.addMinutes(15);
        }
        TravelManager.Instance.setLastVisitedBuilding(buildingGameObject);
    }
}
