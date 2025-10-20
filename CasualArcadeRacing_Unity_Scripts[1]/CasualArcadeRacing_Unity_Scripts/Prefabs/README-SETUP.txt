PREFABS & UI SETUP (Unity 2022/2023)
----------------------------------
These are text placeholders describing how to create the prefabs and UI in Unity.
Follow these steps in the Unity Editor to make the demo scene work quickly.

1) Create folders:
   - Assets/Scripts  <- copy .cs files here
   - Assets/Prefabs
   - Assets/Scenes
   - Assets/Audio
   - Assets/Materials
   - Assets/UI

2) Create a Player Car Prefab:
   - Create an empty GameObject named 'PlayerCar'.
   - Add a Cube (child) scaled to look like a car body.
   - Add Rigidbody component to PlayerCar, set mass=1200, drag=0.1.
   - Add BoxCollider sized to the body.
   - Attach 'CarController.cs' to PlayerCar.
   - Add 'CameraFollow.cs' to Main Camera and assign target to PlayerCar transform.
   - Drag PlayerCar from Hierarchy to Assets/Prefabs to save as prefab.

3) Create HUD (Canvas):
   - Create Canvas -> add Text (SpeedText), Text (CoinsText), Slider (NitroSlider), Text (CountdownText).
   - Create UIManager empty GameObject and attach 'UIManager.cs', then link the UI fields.
   - Save HUD as HUD.prefab in Assets/Prefabs.

4) Create Track scene:
   - Create a plane or simple terrain for the track. Add some cubes to form walls/obstacles.
   - Create an empty GameObject 'TrackManager' and attach 'TrackManager.cs' (script included earlier if needed).
   - Add a FinishLine object with collider and tag 'FinishLine' and attach Telemetry.cs if you want lap logic.
   - Save scene as Assets/Scenes/Track_Example.unity

5) Audio:
   - Put placeholder audio files in Assets/Audio and link them in AudioManager prefab.
   - Save AudioManager as prefab.

6) Run:
   - Open the scene, press Play. The PlayerCar can be driven via keyboard (WASD) or UI buttons.
