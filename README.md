# OmniVirt VR Player: 360° Video Player for Unity (iOS & Android)

![Screenshot](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/screenshot3.jpg)

**OmniVirt** makes the leading player for 360° video experiences across mobile and desktop. Upload your 360° content to OmniVirt and serve it into your app with few easy steps.

# Usage

**OmniVirt VR Player** for Unity provides you a really easy way to embed 360° content on your iOS and Android game with just few lines of code.

## Get Started

1. **Sign up** for an account at [OmniVirt](https://www.omnivirt.com)
2. **Upload** your VR / 360° photo or video on [OmniVirt](https://www.omnivirt.com/).
3. Keep the **Content ID** assigned to your content for further use.

Content is now ready. It is time to work on Unity editor.

## Add the OmniVirt SDK to your project

1) Download [OmniVirtSDK.unitypackage](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/OmniVirtSDK.unitypackage)

2) Import it to your Unity project via **Assets -> Import Package -> Custom Package** menu.

![Import](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/importpackage.jpg)

Your project will now contain all necessary files to run OmniVirt VR Player.

## Switch Platform

Currently OmniVirt VR Player for Unity is supported only on iOS and Android. So to make it works, you need to switch platform to either iOS or Android first. To do so, click at **File -> Build Settings**, choose your target platform (iOS or Android) and then click **Switch Platform**.

![Switch Platform](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/switchplatform.jpg)

Please note that if you do not switch the platform, your code will not be able to compile.

## Prepare a script

You can now let you VR content played in your game with just a single line of code !

First, create an empty GameObject in the scene.

![GameObject](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/emptygameobject.jpg)

And then, create a C# script and rename it to `VRPlayerControl`.

![VRPlayerController](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/newcsscript.jpg)

**Drag** the script and **drop** it a created GameObject to assign it to the scene.

![DragDropScript](https://github.com/OmniVirt/OmniVirtVRPlayer-Unity-Example/raw/master/Screenshots/dragdropscript.jpg)

## Launch a VR Player

Open `VRPlayerControl.cs` file and add the following line in the header area.

```csharp
using OmniVirt;
```

Add the following code snippet in the `Start()` function.

```csharp
VRPlayer.Launch (CONTENT_ID,
                    true,     // Autoplay
                    Mode.Off  // Cardboard Mode
                    );
```

And replace `CONTENT_ID` with a **Content ID** got from step above, for example,

```csharp
public class VRPlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VRPlayer.Launch (24, true, Mode.Off);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
```

And ... done ! It is this easy ! You can now build project and run to test the VR Player.

## Extra: Earn Money

Would like to earn money from your 360° content? You can create an **Ad Space** on [OmniVirt](www.omnivirt.com) and pass the **Ad Space ID** acquired to the command like shown below to enable ad on the player.

```csharp
VRPlayer.Launch (CONTENT_ID,
                    true,       // Autoplay
                    Mode.Off,   // Cardboard Mode
                    ADSPACE_ID  // Replace with your Ad Space ID
                    );
```

Once you set it up correctly, user will sometime see an ad among the player and that will turn into your revenue !

## Player Callback

Any change on the player could be detected by registering a callback function in the pattern like this.

```csharp
void Start () {
    VRPlayer vrPlayer = VRPlayer.Launch (24, true, Mode.Off);
    // Register a Callback
    vrPlayer.PlayerEnded += OnVRPlayerEnded;
}

// Video Playing Completion Event
void OnVRPlayerEnded(object player, System.EventArgs args) {

}
```

These are the list of callback functions available.

- **`PlayerLoaded(object, PlayerLoadedEventArgs)`**

  Called when VR Player has been loaded successfully.

- **`PlayerStarted(object, System.EventArgs)`**

  Called when VR Player has started playing.

- **`PlayerPaused(object, System.EventArgs)`**

  Called when VR Player has been paused.

- **`PlayerEnded(object, System.EventArgs)`**

  Called when VR Player has finished playing.

- **`PlayerSkipped(object, System.EventArgs)`**

  Called when video has been skipped for the next one.

- **`PlayerDurationChanged(object, PlayerDurationChangedEventArgs)`**

  Called when video duration has been changed.

- **`PlayerProgressChanged(object, PlayerProgressChangedEventArgs)`**

  Called when video progress has been changed.

- **`PlayerBufferChanged(object, PlayerBufferChangedEventArgs)`**

  Called when video has been buffered.

- **`PlayerSeekChanged(object, PlayerSeekChangedEventArgs)`**

  Called when video has been seeked.

- **`PlayerCardboardChanged(object, PlayerCardboardChangedEventArgs)`**

  Called when Cardboard mode has been changed.

- **`PlayerVolumeChanged(object, PlayerAudioChangedEventArgs)`**

  Called when volume level has been changed.

- **`PlayerQualityChanged(object, PlayerQualityChangedEventArgs)`**

  Called when video quality has been changed.

- **`PlayerExpanded(object, System.EventArgs)`**

  Called when VR player has been expanded fullscreen.

- **`PlayerCollapsed(object, System.EventArgs)`**

  Called when VR player has been force destroyed.

- **`PlayerLatitudeChanged(object, PlayerLatitudeChangedEventArgs)`**

  Called when video angle in y-axis has been changed.

- **`PlayerLongitudeChanged(object, PlayerLongitudeChangedEventArgs)`**

  Called when video angle in x-axis has been changed.

- **`PlayerSwitched(object, PlayerSwitchedEventArgs)`**

  Called when video scene has been switched.

# Questions?

Please feel free to email us at [contact@omnivirt.com](mailto:contact@omnivirt.com) !
