using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkTiredness : MonoBehaviour
{
   	public GameObject background;
	public GameObject icon;

	private Image backgroundImage;
	private Image iconImage;
	private bool updateLock;

	void Start() {
		backgroundImage = background.GetComponent<Image>();
		iconImage = icon.GetComponent<Image>();
		updateLock = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (StatManager.Instance.getStat("energie") == 0) {
        	iconImage.enabled = true;
        	backgroundImage.enabled = true;
        	updateLock = false;
        } 
        else if (StatManager.Instance.getStat("energie") > 0 && updateLock == false) {
        	print("yo");
        	iconImage.enabled = false;
        	backgroundImage.enabled = false;
        	updateLock = true;
        }
    }
}
