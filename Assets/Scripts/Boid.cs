using UnityEngine;

public class Boid : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float maxSpeed = 2f;
    public float maxXlR = 3f;



    private void Awake ()
    {
        StartBoids();
    }

    void StartBoids()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.linearVelocity = Random.insideUnitSphere;
        GetComponent<Renderer>().material.SetColor("_BaseColor", Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1));
    }

    public void FixedUpdate()
    {
        AlignToVelocity();
        MaxSpeed();
       
    }

    public void Update()
    {
        LockToTank();
    }

    public Vector3 Seek(Vector3 target, float magnitude)
    {
        Vector3 toTarget = target - transform.position;

        Vector3 toTargetNormalized = toTarget.normalized;

        Vector3 accel = toTargetNormalized * magnitude;

        return accel;
    }

    public Vector3 Feed(Vector3 food, float magnitude)
    {
        Vector3 toFood = food - transform.position;

        Vector3 toFoodNormalized = toFood.normalized;

        Vector3 accel = toFoodNormalized * magnitude;

        if (toFoodNormalized.magnitude > 5)
        {
            accel = accel - toFoodNormalized;
        }

        return accel;
    }


    public Vector3 Pursue(Vector3 target, float magnitude)
    {
        Vector3 speed = rigidBody.linearVelocity;

        Vector3 pos = transform.position;

        Vector3 toTarget = pos - target;

        Vector3 desiredVel = toTarget.normalized * maxSpeed;

        Vector3 deltaVel = desiredVel - speed;

        Vector3 acceleration = deltaVel.normalized * maxXlR;

        return acceleration;
    }

    private void MaxSpeed()
    {
        float speed = rigidBody.linearVelocity.magnitude;
       // Debug.Log("Speed is " + speed + ". Max speed is " + maxSpeed + "!");
        if (speed > maxSpeed)
        {
            rigidBody.linearVelocity = rigidBody.linearVelocity * maxSpeed / speed;
        }
    }

    public void AlignToVelocity()
    {
        //Funny line.
        Debug.DrawRay(transform.position, rigidBody.linearVelocity, Color.red);


        transform.forward = Vector3.RotateTowards(transform.forward, rigidBody.linearVelocity.normalized, Mathf.Deg2Rad * 1000 * Time.deltaTime, 100);
    }

    private void LockToTank()
    {
        if (transform.position.y >= 3.5)
        {
            transform.position = new Vector3 (transform.position.x, 3.49f, transform.position.z);
        }
        else if (transform.position.y <= 2.2)
        {
            transform.position = new Vector3(transform.position.x, 2.21f, transform.position.z);
        }
        else if (transform.position.x >= 1.4f)
        {
            transform.position = new Vector3(1.39f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -1.4f)
        {
            transform.position = new Vector3(-1.39f, transform.position.y, transform.position.z);
        }
        else if (transform.position.z <= -0.9f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.89f);
        }
        else if (transform.position.z >= 0.9f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.89f);
        }
    }

}
