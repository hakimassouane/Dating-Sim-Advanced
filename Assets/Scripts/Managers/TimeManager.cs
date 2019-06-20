using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	private static TimeManager _instance;

	public static TimeManager Instance {
		get {
			if (_instance == null) {
				_instance = new TimeManager();
			}
			return _instance;
		}
	}

	// Time variables
	private static string[] months;
	private static int currentYear = 2019;
	private static int currentMonth = 8;
	private static int currentDay = 1;
	// in minutes
	private static int currentTime = 420;

	// UI variables
	private static Text dateText;

	// Initialize method
	void Start() {
		months = new string[] {
		"Janvier",
		"Fevrier",
		"Mars",
		"Avril",
		"Mai",
		"Juin",
		"Juillet",
		"Aout",
		"Septembre",
		"Octobre",
		"Novembre",
		"Decembre"
		};

		dateText = GameObject.Find("Date").GetComponent<Text>();
	}

	public void addYear(int amount) {
		currentYear += amount;
		updateDateUI();
	}

	public void addMonth(int amount) {
		int addedMonthCount = 0;

		while (addedMonthCount < amount) {
			addedMonthCount += 1;
			if (currentMonth + 1 > 12) {
				currentMonth = 0;
				addYear(1);
			}
			currentMonth += 1;
		}
		updateDateUI();
	}

	public void addWeek(int amount) {
		addDay(amount * 7);
	}

	public void addDay(int amount) {
		int addedDaysCount = 0;
		while (addedDaysCount < amount) {
			addedDaysCount += 1;
			if (currentDay + 1 > 30) {
				currentDay = 0;
				addMonth(1);
	  	 	}
		 	currentDay += 1;
		}
		updateDateUI();
	}

	public void addHours(int amount) {
		int addedTimeCount = 0;
		while (addedTimeCount < 60 * amount) {
			addedTimeCount += 1;
			if (currentTime + 1 > 1440) {
				currentTime = 0;
	  	 	}
		 	currentTime += 1;
		}
		updateDateUI();
	}

	public void addMinutes(int amount) {
		int addedTimeCount = 0;
		while (addedTimeCount < amount) {
			addedTimeCount += 1;
			if (currentTime + 1 > 1440) {
				currentTime = 0;
				addDay(1);
	  	 	}
		 	currentTime += 1;
		}
		updateDateUI();
	}


	public void updateDateUI() {
		string dateStringTemplate = currentDay + " " + months[currentMonth] + " " + currentYear + " " + TimeSpan.FromMinutes(currentTime).ToString(@"hh\:mm");

		dateText.text = dateStringTemplate;
	}
}
