using UnityEngine;

public class Boid : MonoBehaviour
{
    public Rigidbody rigidBody;

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

    public void Update()
    {
        AlignToVelocity();
    }

    public void AlignToVelocity()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, rigidBody.linearVelocity.normalized, Mathf.Deg2Rad * 1000 * Time.deltaTime, 100);
    }



}
