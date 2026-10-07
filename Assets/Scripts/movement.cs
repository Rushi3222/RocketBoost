using UnityEngine;
using UnityEngine.InputSystem;


public class movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputAction Thrust;
    [SerializeField] InputAction Rotation;

    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thrustProcess();
        RotationPrecess();
    }


    private void OnEnable()
    {
        Thrust.Enable();
        Rotation.Enable();
        
    }

    void thrustProcess()
    {
        if (Thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength);
        }
    }

    void RotationPrecess()
    {
        float rotation = Rotation.ReadValue<float>();
        if(rotation < 0)
        {
            transform.Rotate(Vector3.forward * rotationStrength * Time.fixedDeltaTime);
        }
        else if (rotation > 0)
        {
            transform.Rotate(-Vector3.forward * rotationStrength * Time.fixedDeltaTime);
        }
    }

}