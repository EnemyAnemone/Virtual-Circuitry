using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public SteamVR_TrackedController _controller;

	public bool menuVisible = false;
	public GameObject menu;

	void Start () {
		
	}
	
	void Update () {
		
	}

	private void OnEnable() {
		_controller = GetComponent<SteamVR_TrackedController>();
		_controller.TriggerClicked += HandleTriggerClicked;
		_controller.MenuButtonClicked += HandleMenuButtonClicked;
		_controller.Ungripped += HandleUngripped;
	}

	private void OnDisable() {
		_controller = null;
		_controller.TriggerClicked -= HandleTriggerClicked;
		_controller.MenuButtonClicked -= HandleMenuButtonClicked;
		_controller.Ungripped -= HandleUngripped;
	}

	private void HandleTriggerClicked(object sender, ClickedEventArgs e) {
		
	}

	private void HandleMenuButtonClicked(object sender, ClickedEventArgs e) {
		if(menuVisible) {
			hideMenu();
		} else {
			revealMenu();
		}
		menuVisible = !menuVisible;
	}

	private void HandleUngripped(object sender, ClickedEventArgs e) {
	
	}

	public void hideMenu() {
		menu.SetActive(false);
	}

	public void revealMenu() {
		menu.SetActive(true);
	}

}
