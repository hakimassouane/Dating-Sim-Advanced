using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatManager : MonoBehaviour
{
  	private static StatManager _instance;

	public static StatManager Instance {
		get {
			if (_instance == null) {
				_instance = new StatManager();
			}
			return _instance;
		}
	}

	private static Slider strengthSlider;
	private static Slider intelSlider;
	private static Slider creaSlider;
	private static Slider beautySlider;
	private static Slider combatSlider;
	private static Slider cultSlider;
	private static Dictionary<string, int> statMap = new Dictionary<string, int>();
	private static Dictionary<string, Slider> statSliderMap = new Dictionary<string, Slider>();

	void Start() {
		initStatMap();
		initStatSliderMap();
	}

	private void initStatMap() {
		statMap.Add("force", 0);
		statMap.Add("intelligence", 0);
		statMap.Add("creativite", 0);
		statMap.Add("beaute", 0);
		statMap.Add("combat", 0);
		statMap.Add("culture", 0);
	}

	private void initStatSliderMap() {
		strengthSlider = GameObject.Find("strengthSlider").GetComponent<Slider>();
		intelSlider = GameObject.Find("intelSlider").GetComponent<Slider>();
		creaSlider = GameObject.Find("creaSlider").GetComponent<Slider>();
		beautySlider = GameObject.Find("beautySlider").GetComponent<Slider>();
		combatSlider = GameObject.Find("combatSlider").GetComponent<Slider>();
		cultSlider = GameObject.Find("cultSlider").GetComponent<Slider>();

		statSliderMap.Add("force", strengthSlider);
		statSliderMap.Add("intelligence", intelSlider);
		statSliderMap.Add("creativite", creaSlider);
		statSliderMap.Add("beaute", beautySlider);
		statSliderMap.Add("combat", combatSlider);
		statSliderMap.Add("culture", cultSlider);
	}

	public void addStat(string statNameAndAmount) {
		string[] split = statNameAndAmount.Split(';');
		string name = split[0];
		int amount = Int32.Parse(split[1]);

		statMap[name] += amount;
		if (statMap[name] > 100) {
			statMap[name] = 100;
		}
		else if (statMap[name] < 0) {
			statMap[name] = 0;
		}
		updateStatUI(name);
	}

	public int getStat(string statName) {
		return statMap[statName];
	}

	public void updateStatUI(string statName) {
		Slider currentSlider = statSliderMap[statName];
		
		currentSlider.value = statMap[statName];
	}
}
