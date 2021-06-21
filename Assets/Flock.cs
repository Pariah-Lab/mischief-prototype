using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [Header("Simulation Settings")] //these should not be changed at runtime
    public Boid boidPrefab;
    public int numBoids = 3;
    public float spawnRadius = 0.2f;
    public float boundaryRadius = 10.0f;

    [Header("Boid Settings")]
    public float maxVelocity = 0.05f;
    public float maxSteeringForce = 0.03f;
    public float seperationDistance = 1.0f;
    public float neighborDistance = 3.0f;
    [Range(0f, 360f)]
    public float fieldOfView = 300f;

    [Header("Force Multipliers")]
    public float seperationMultiplier = 1.0f;
    public float alignmentMultiplier = 1.0f;
    public float cohesionMultiplier = 1.0f;
    public float boundaryMultiplier = 1.0f;

    public Boid[] boids { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Flock Called");
        boids = new Boid[numBoids];

        for (int i = 0; i < boids.Length; i++)
        {


            boids[i] = Instantiate(boidPrefab, new Vector3 (i * 0.2f, 0, 0), transform.rotation, transform);
            Debug.Log("Instantiated boid - " + i + " at position: " + transform.position);
            boids[i].SetupSimulation(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Boid boid in boids)
        {
            boid.UpdateSimulation();
        }
    }
}
