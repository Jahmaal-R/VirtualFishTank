using UnityEngine;
using System.Collections.Generic;
using static BoidSimulationControl;

public class BoidSimulationControl : MonoBehaviour
{
    public GameObject boidPrefab;
    public int boidsToSpawn = 10;
     private List<Boid> boids;

    public void Start()
    {
        BoidSpawn();
    }

    public enum ControlMode
    {
        Seek,
        Pursue,
        Food,
        Obstacle
    }

    public ControlMode controlMode = ControlMode.Seek;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ControlMode controlMode = ControlMode.Seek;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ControlMode controlMode = ControlMode.Pursue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ControlMode controlMode = ControlMode.Food;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ControlMode controlMode = ControlMode.Obstacle;
        }
    }

    private void BoidSpawn()
    {
        boids = new List<Boid>();

        for (int i = 0; i < boidsToSpawn; i++)
        {
            GameObject newBoid = Instantiate(boidPrefab, new Vector3(Random.Range(-0.7f, 0.7f), Random.Range(-0.7f, 0.7f), Random.Range(-0.4f, 0.4f)), Random.rotation);
            boids.Add(newBoid.GetComponent<Boid>());
        }
    }
}

