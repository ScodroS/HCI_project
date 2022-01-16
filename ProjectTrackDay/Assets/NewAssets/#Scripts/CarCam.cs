using UnityEngine;

public class CarCam : MonoBehaviour
{
    Transform rootNode;
    Transform carCam;
    Transform car;
    Rigidbody carPhysics;
    Vector3 offset;
    //Vector3 offset = new Vector3(0, 0, 0);
    Quaternion offsetRotation;

    [Tooltip("If car speed is below this value, then the camera will default to looking forwards.")]
    public float rotationThreshold = 1f;
    
    [Tooltip("How closely the camera follows the car's position. The lower the value, the more the camera will lag behind.")]
    public float cameraStickiness = 10.0f;
    
    [Tooltip("How closely the camera matches the car's velocity vector. The lower the value, the smoother the camera rotations, but too much results in not being able to see where you're going.")]
    public float cameraRotationSpeed = 5.0f;

    void Awake()
    {
        carCam = Camera.main.GetComponent<Transform>();
        rootNode = GetComponent<Transform>();
        car = rootNode.parent.GetComponent<Transform>();
        carPhysics = car.GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Detach the camera so that it can move freely on its own.
        rootNode.parent = null;
        offset = rootNode.position - car.transform.position;
        offsetRotation = rootNode.rotation * Quaternion.Inverse(car.transform.rotation);
    }

    void FixedUpdate()
    {
        Quaternion look;

        // Moves the camera to match the car's position.
        //rootNode.position = Vector3.Lerp(rootNode.position, car.position-offset, cameraStickiness * Time.fixedDeltaTime);
        rootNode.position = car.position-offset;

        // If the car isn't moving, default to looking forwards. Prevents camera from freaking out with a zero velocity getting put into a Quaternion.LookRotation
        if (carPhysics.velocity.magnitude < rotationThreshold)
            look = Quaternion.LookRotation(car.forward);
        else
            look = Quaternion.LookRotation(carPhysics.velocity.normalized);
        
        // Rotate the camera towards the velocity vector. 
        look = Quaternion.Slerp(rootNode.rotation, look * offsetRotation, cameraRotationSpeed * Time.fixedDeltaTime);   

        rootNode.rotation = look;
    }
}