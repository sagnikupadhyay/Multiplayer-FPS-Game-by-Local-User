using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float sensitivity = 4f;    

    private PlayerMotor motor;   

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
       
    }
    
    void Update()
    {
        float _xmov = Input.GetAxisRaw("Horizontal");
        float _zmov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xmov;
        Vector3 _movVertical = transform.forward * _zmov;
        
        //final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3d vector.(use for turning around)
        float _yrot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yrot, 0f) * sensitivity;

        //apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3d vector.(use for turning up and down)
        float _xrot = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xrot * sensitivity;
             
        //apply camera rotation
        motor.RotateCamera(_cameraRotationX);
       
    }
    
}
