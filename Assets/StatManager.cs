using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


	Dictionary<string, int> statMap = new Dictionary<string, int>();

	void Start() {
		initStatMap();
	}

	private void initStatMap() {
		statMap.Add("beaute", 0);
		statMap.Add("force", 0);
		statMap.Add("intelligence", 0);
		statMap.Add("combat", 0);
		statMap.Add("creativite", 0);
		statMap.Add("culture", 0);
	}


	public void addStat(string statNameAndAmount) {
		string[] split = statNameAndAmount.Split(';');
		string name = split[0];
		int amount = Int32.Parse(split[1]);

		print(name + " " +  amount);

		statMap[name] += amount;

		
		print(name + " is now : " + statMap[name]);
	}



	/* public int getStat(string statName) {

	} */
}
