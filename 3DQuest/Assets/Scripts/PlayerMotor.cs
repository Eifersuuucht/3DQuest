using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {


    public Camera cam;

    Vector3 velocity = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    float cameraRotationX = 0f;
    float currentCameraRotationX = 0f;
    Rigidbody rb;
    float cameraRotationLimit = 45f;

    void Start()
    {
        //<> is a generic function, Getcomponent fetches the rigidbody from unity to vs, or I can simply declare rb as public
        //and drag every rigidbody to the specific field under the name of the code
        rb = GetComponent<Rigidbody>();
    }

    //Gets a movement of a vector, variables with underscore is variables declared in methods
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Gets a rotation of a vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Gets a rotation of a vector for the camera
    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    //Runs every physics Iteration, fixedUpdate has fixed time of calling the funtion, Update not
    public void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Performed movement on a velocity variable
    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            //Smooth transition
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
       
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));//Quaternion is obligatory for rotation
        if(cam != null)
        {
            //set our rotation and clamp it
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            //Apply our rotation to the transform of camera
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);
        }
        
    }
    

}
