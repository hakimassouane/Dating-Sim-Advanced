using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMouseActions : MonoBehaviour
{
	private Outline outscript;
	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

	void Start ()
	{
		outscript = gameObject.GetComponent<Outline>();
	}

    void OnMouseOver()
    {
    	Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    	outscript.OutlineWidth = 10;
    }

    void OnMouseExit()
    {
    	Cursor.SetCursor(null, Vector2.zero, cursorMode);
    	outscript.OutlineWidth = 0;
    }
}
