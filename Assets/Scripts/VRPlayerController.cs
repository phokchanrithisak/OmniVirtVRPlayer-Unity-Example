using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OmniVirt;

public class VRPlayerController : MonoBehaviour {

	public Button PlayButton;
	public GameObject Crate;
	public Image LogoImage;

	VRPlayer vrPlayer;

	// Use this for initialization
	void Start () {
		// Bind PlayButton's Click Event with OnPlayButtonClicked
		PlayButton.onClick.AddListener (OnPlayButtonClicked);
	}

	void OnPlayButtonClicked() {
		// Disable Play Button
		PlayButton.interactable = false;

		// Launch VR Player
		vrPlayer = VRPlayer.Launch (24, true, Mode.Off);

		// Register Callback for Video Playing Completion Event
		vrPlayer.PlayerEnded += OnVRPlayerEnded;
		// Register Callback for Video Player Closed Event
		vrPlayer.PlayerCollapsed += OnVRPlayerCollapsed;
	}

	/*************************
	 * Callback for VR Player
	 *************************/

	// Video Playing Completion Event
	void OnVRPlayerEnded(object player, System.EventArgs args) {
		// Close VR Player
		CloseVRPlayer ();

		// Re-enable Play Button
		PlayButton.interactable = true;
	}

	// Video Player Closed Event
	void OnVRPlayerCollapsed(object player, System.EventArgs args) {
		// Close VR Player
		CloseVRPlayer ();

		// Re-enable Play Button
		PlayButton.interactable = true;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustUIByOrientation ();

		// Rotate Crate
		Crate.transform.Rotate (1, 1.5f, 0.5f);

		// Handle Back Button
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (vrPlayer != null)
				return;
			Application.Quit ();
		}
	}

	void CloseVRPlayer() {
		// Close VR Player
		if (vrPlayer != null) {
			vrPlayer.Unload ();
			vrPlayer.Close ();
			vrPlayer = null;
		}
	}

	void AdjustUIByOrientation() {
		RectTransform rectTransform;

		if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight) {
			LogoImage.rectTransform.sizeDelta = new Vector2(1394 * 0.6f, 473 * 0.6f);
			LogoImage.rectTransform.anchorMin = new Vector2 (0, 1);
			LogoImage.rectTransform.anchorMax = new Vector2 (0, 1);
			LogoImage.rectTransform.anchoredPosition = new Vector2 (220, -100);

			rectTransform = PlayButton.gameObject.transform as RectTransform;
			rectTransform.sizeDelta = new Vector2(345, 90);
			rectTransform.anchorMin = new Vector2 (0.5f, 0);
			rectTransform.anchorMax = new Vector2 (0.5f, 0);
			rectTransform.anchoredPosition = new Vector2 (0, 100);

			Crate.transform.position = new Vector3 (90, 80, 0);
			Crate.transform.localScale = new Vector3 (120, 120, 120);
		} else if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown) {
			LogoImage.rectTransform.sizeDelta = new Vector2(1394.0f, 473.0f);
			LogoImage.rectTransform.anchorMin = new Vector2 (0.5f, 1);
			LogoImage.rectTransform.anchorMax = new Vector2 (0.5f, 1);
			LogoImage.rectTransform.anchoredPosition = new Vector2 (-8, -190);

			rectTransform = PlayButton.gameObject.transform as RectTransform;
			rectTransform.sizeDelta = new Vector2(460, 120);
			rectTransform.anchorMin = new Vector2 (0.5f, 0);
			rectTransform.anchorMax = new Vector2 (0.5f, 0);
			rectTransform.anchoredPosition = new Vector2 (0, 160);

			Crate.transform.position = new Vector3 (0, 0, 0);
			Crate.transform.localScale = new Vector3 (50, 50, 50);
		}
	}

}
