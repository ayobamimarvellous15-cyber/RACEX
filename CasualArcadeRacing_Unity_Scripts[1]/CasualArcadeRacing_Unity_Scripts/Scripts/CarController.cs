using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("Tuning")]
    public float acceleration = 800f;
    public float steering = 2.0f;
    public float maxSpeed = 40f;
    public float brakeForce = 1200f;
    public float nitroMultiplier = 1.8f;
    public float nitroDuration = 2.0f;

    [HideInInspector] public float currentSpeed;
    Rigidbody rb;
    float inputSteer;
    float inputAccel;
    bool isBraking;
    bool isNitroActive = false;
    float nitroTimer = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void Update()
    {
        inputSteer = InputManager.Instance.GetSteer();
        inputAccel = InputManager.Instance.GetAccelerate();
        isBraking = InputManager.Instance.GetBrake();

        if (InputManager.Instance.GetNitroPressed() && !isNitroActive)
        {
            UseNitro();
        }

        if (isNitroActive)
        {
            nitroTimer -= Time.deltaTime;
            if (nitroTimer <= 0f) EndNitro();
        }

        currentSpeed = rb.velocity.magnitude;
    }

    void FixedUpdate()
    {
        Vector3 forward = transform.forward;
        float appliedAccel = inputAccel;
        if (isNitroActive) appliedAccel *= nitroMultiplier;

        if (rb.velocity.magnitude < maxSpeed * (isNitroActive ? nitroMultiplier : 1f))
            rb.AddForce(forward * appliedAccel * acceleration * Time.fixedDeltaTime);

        if (isBraking)
        {
            rb.AddForce(-rb.velocity.normalized * brakeForce * Time.fixedDeltaTime);
        }

        float turn = inputSteer * steering * (rb.velocity.magnitude / maxSpeed);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turn, 0));

        if (Mathf.Abs(inputSteer) > 0.3f && inputAccel > 0.2f)
        {
            rb.AddForce(transform.right * -inputSteer * 50f * Time.fixedDeltaTime);
        }
    }

    public void UseNitro()
    {
        isNitroActive = true;
        nitroTimer = nitroDuration;
        AudioManager.Instance?.PlayNitro();
    }

    void EndNitro()
    {
        isNitroActive = false;
    }
}
