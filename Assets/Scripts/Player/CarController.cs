using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
        #endregion
    }

    public Rigidbody theRB;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180, gravityForce = 10f ,dragOnground = 3f;

    private float speedInput, turnInput;

    private bool grounded;

    public LayerMask whatIsGround;
    public float groundRayLength = .5f;
    public Transform groundRayPoint;

    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;


    void Start()
    {
        theRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        speedInput = 0;

        //handling moving forward and backward
        if (Input.GetAxis("Vertical") > 0|| SimpleInput.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
            speedInput = SimpleInput.GetAxis("Vertical") * forwardAccel * 1000f;
            if (SoundManager.instance.engineIdle.gameObject.activeInHierarchy)
            {
                //play engine sound if there's speed
                SoundManager.instance.PlaySound(SoundManager.instance.engineIdle);
            }
        }
        else if (Input.GetAxis("Vertical") < 0 || SimpleInput.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f; 
            speedInput = SimpleInput.GetAxis("Vertical") * reverseAccel * 1000f;
        }

        //handling turning and steeling
        turnInput = Input.GetAxis("Horizontal");
        turnInput = SimpleInput.GetAxis("Horizontal");

        if (grounded)
        { 
          transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
          transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * SimpleInput.GetAxis("Vertical"), 0f));
        }

        //steeling wheels 
        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x,
                                                        (turnInput * maxWheelTurn) - 180,
                                                        leftFrontWheel.localRotation.eulerAngles.z);

        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x,
                                                turnInput * maxWheelTurn,
                                                rightFrontWheel.localRotation.eulerAngles.z);

        //cause we are actually moving the sphere's rigidbody, the car model should also keep up with the rigidbody's transform
        transform.position = theRB.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround)) 
        {
            grounded = true;

            //make car rotate based on the surface
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal)* transform.rotation;
        }

        if (grounded) 
        {
            theRB.drag = dragOnground;
            if (Mathf.Abs(speedInput) > 0) 
            {
                //if the car is on the ground, applying force to the rigid body to move the car.
                theRB.AddForce(transform.forward * speedInput);
            }
        }
        else 
        {
            theRB.drag = 0.1f;
            //push downward to ground if the car is in air, not sure whether gonna use this feature
            theRB.AddForce(Vector3.up * -gravityForce * 100f);
        }
        
    }


}
