using UnityEngine;

public class Food : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        LockToTank();
    }

    private void LockToTank()
    {
        if (transform.position.y >= 3.5)
        {
            transform.position = new Vector3(transform.position.x, 3.49f, transform.position.z);
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

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "boid")
        {
            Destroy(gameObject);
        }
    }
}
