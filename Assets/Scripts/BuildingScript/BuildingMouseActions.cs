using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingMouseActions : MonoBehaviour
{
	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject buildingPanel;
    public Text buildingNameString;
    public string buildingName;

    private Outline outscript;

	void Start ()
	{
		outscript = gameObject.GetComponent<Outline>();
	}

    void OnMouseEnter()
    {
        print("mouse enter");
        if(!EventSystem.current.IsPointerOverGameObject()) {
            
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            outscript.OutlineWidth = 10;
        }
    	
    }

    void OnMouseExit()
    {
        if(!EventSystem.current.IsPointerOverGameObject()) {
            print("mouse exit");
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            outscript.OutlineWidth = 0;
        }
    	
    }

    void OnMouseDown()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        outscript.OutlineWidth = 0;
        print("mouse down");
        if(!EventSystem.current.IsPointerOverGameObject()) {

            buildingPanel.SetActive(true);
            buildingNameString.text = buildingName; 
        }

    }
}
