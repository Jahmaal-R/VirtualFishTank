using UnityEngine;
using System.Collections.Generic;
using static BoidSimulationControl;

public class BoidSimulationControl : MonoBehaviour
{
    public GameObject boidPrefab;
    public int boidsToSpawn = 10;
    private List<Boid> boids;
    public GameObject target;
    GameObject food;

    public void Start()
    {
        BoidSpawn();
        target = GameObject.Find("Food Shaker");
    }

    public enum ControlMode
    {
        Seek,
        Pursue,
        Food,
        Obstacle
    }

    public ControlMode control = ControlMode.Food;

    void SwitchMode()
    {
        switch (control)
        {
            //Debug.
            case ControlMode.Seek:
                {
                    //Debug.Log("Seek working");
                    Seek();
                    break;
                }

            case ControlMode.Pursue:
                {
                    // Debug.Log("Pursue working");
                    Arrive();
                    break;
                }
           // case ControlMode.Food:
              //  {
                    // Debug.Log("Pursue working");
                  //  Food();
                    //break;
               // }
        }
    }

    private void Update()
    {
        SwitchMode();
        Move();
        food = GameObject.Find("Food(Clone)");

    }


    private void Move()
    {
        if (Input.GetKeyDown("1"))
        {

            //ControlMode
            control = ControlMode.Seek;
            //Debug.Log("Working " + control);
        }
        if (Input.GetKeyDown("2"))
        {

            //ControlMode
            control = ControlMode.Pursue;
            // Debug.Log("Working " + control);
        }
        if (Input.GetKeyDown("3"))
        {
            //ControlMode
           // control = ControlMode.Food;
          
        }

    }

    private void BoidSpawn()
    {
        boids = new List<Boid>();

        for (int i = 0; i < boidsToSpawn; i++)
        {
            GameObject newBoid = Instantiate(boidPrefab, new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(3f, 3.1f), Random.Range(-0.1f, 0.1f)), Random.rotation);
            boids.Add(newBoid.GetComponent<Boid>());
        }
    }

    private void Pursue()
    {
        for (int i = 0; i < boids.Count; i++)
        {
            Vector3 acceleration = boids[i].Pursue(target.transform.position, boids[i].maxXLR);

            //seek
            if (Input.GetMouseButton(0))
            {

                Debug.Log("Pursuing");
                boids[i].rigidBody.linearVelocity += acceleration * Time.fixedDeltaTime;
                Debug.DrawRay(boids[i].transform.position, acceleration, Color.green);
            }

            //flee
            else if (Input.GetMouseButton(1))
            {

                Debug.Log("Fleeing");
                boids[i].rigidBody.linearVelocity -= acceleration * Time.fixedDeltaTime;
                Debug.DrawRay(boids[i].transform.position, acceleration, Color.green);
            }
        }

    }

    private void Arrive()
    {
        for (int i = 0; i < boids.Count; i++)
        {
            Vector3 acceleration = boids[i].Arrive(target.transform.position, boids[i].maxXLR);

            //seek
            if (Input.GetMouseButton(0))
            {

                Debug.Log("Arriving");
                boids[i].rigidBody.linearVelocity += acceleration * Time.fixedDeltaTime;
                Debug.DrawRay(boids[i].transform.position, acceleration, Color.green);
            }

            //flee
            else if (Input.GetMouseButton(1))
            {

                Debug.Log("Fleeing");
                boids[i].rigidBody.linearVelocity -= acceleration * Time.fixedDeltaTime;
                Debug.DrawRay(boids[i].transform.position, acceleration, Color.green);
            }
        }

    }


    private void Seek()
    {
        for (int i = 0; i < boids.Count; i++)
        {
            Vector3 accel = boids[i].Seek(target.transform.position, boids[i].maxXLR);

            //seek
            if (Input.GetMouseButton(0))
            {

                Debug.Log("Seeking");
                boids[i].rigidBody.linearVelocity += accel * Time.fixedDeltaTime;
                Debug.DrawRay(boids[i].transform.position, accel, Color.green);
            }

            //flee
            else if (Input.GetMouseButton(1))
            {

                Debug.Log("Leaving");
                boids[i].rigidBody.linearVelocity -= accel * Time.fixedDeltaTime;
                Debug.DrawRay(boids[i].transform.position, accel, Color.green);
            }
        }
    }

  
}

