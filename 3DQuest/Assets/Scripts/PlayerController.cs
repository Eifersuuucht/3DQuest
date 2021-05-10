using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    //SerializeField forces private fields to be shown in Unity
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float lookSensitivity = 1f;
    [SerializeField]
    float powerUpSpeed = 0f;
    
    PlayerMotor motor;
    

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //calculate movement velocity as a 3D vector, GetAxisRaw is without smoothing, GetAxis is with smoothing
        float _xMov = Input.GetAxisRaw("Horizontal"); //GetAxisRaw returns value of x axis without smoothing
        float _zMov = Input.GetAxisRaw("Vertical");//GetAxisRaw returns value of z axis without smoothing

        Vector3 _movHorizontal = transform.right * _xMov; //transform.right is(1, 0, 0)(x)  transform.up is(0, 1, 0)(y)
        Vector3 _movVertical = transform.forward * _zMov; //transform.forward (0, 0, 1)(z)

        //Check whether LShift was pressed for PowerUp or not
        if (Input.GetKey(KeyCode.LeftShift))
        {
            powerUpSpeed = 3f;

        }else
        {
            powerUpSpeed = 0f;
        }
        
        //Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * (speed + powerUpSpeed); //normalized makes Vector3 magnitude 1
 
        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector
        float _yRot = Input.GetAxisRaw("Mouse X");//it's just a turning around of the sphere

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;


        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");//it's just a turning around of the sphere

        float _cameraRotationX = _xRot * lookSensitivity;

        
        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);

    }
}
