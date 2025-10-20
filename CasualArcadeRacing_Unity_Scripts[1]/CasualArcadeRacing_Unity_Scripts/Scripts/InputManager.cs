using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public enum ControlScheme { Tilt, Buttons }
    public ControlScheme control = ControlScheme.Buttons;

    float steer = 0f;
    float accel = 0f;
    bool brake = false;
    bool nitroPressed = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        nitroPressed = false;
        if (control == ControlScheme.Tilt)
        {
            steer = Input.acceleration.x;
            accel = Input.touchCount > 0 ? 1f : 0f;
            brake = Input.GetKey(KeyCode.Space);
            if (Input.GetKeyDown(KeyCode.LeftShift)) nitroPressed = true;
        }
        else
        {
            steer = Input.GetAxis("Horizontal");
            accel = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ? 1f : 0f;
            brake = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
            if (Input.GetKeyDown(KeyCode.LeftShift)) nitroPressed = true;
        }
    }

    public float GetSteer() => Mathf.Clamp(steer, -1f, 1f);
    public float GetAccelerate() => Mathf.Clamp01(accel);
    public bool GetBrake() => brake;
    public bool GetNitroPressed() => nitroPressed;

    public void OnSteer(float value) { steer = Mathf.Clamp(value, -1f, 1f); }
    public void OnAccelerateDown() { accel = 1f; }
    public void OnAccelerateUp() { accel = 0f; }
    public void OnBrakeDown() { brake = true; }
    public void OnBrakeUp() { brake = false; }
    public void OnNitro() { nitroPressed = true; }
}
