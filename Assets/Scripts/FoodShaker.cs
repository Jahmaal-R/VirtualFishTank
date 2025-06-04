using UnityEngine;

public class FoodShaker : MonoBehaviour
{
    
    public Camera cam;
    RaycastHit hit;
    Collider water;
    public GameObject food;


    void Start()
    {
        water = GameObject.Find("Water Surface").GetComponent<Collider>();
        //boidSim = GameObject.Find("BoidSpawner").GetComponent<BoidSimulation>();
    }

    void Update()
    {
        MoveToMouse();
        SpawnFood();
        LockToTank();

    }

    private void LockToTank()
    {
        if (transform.position.y >= 3.5)
        {
            transform.position = new Vector3(transform.position.x, 3.49f, transform.position.z);
        }
        else if (transform.position.y <= 3.48)
        {
            transform.position = new Vector3(transform.position.x, 3.49f, transform.position.z);
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

        void SpawnFood()
    {
        if (Input.GetKey("3") && Input.GetMouseButtonDown(0))
        {
            Instantiate(food, transform.position, Quaternion.identity);
        }

    }

    void MoveToMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 5, Color.blue);

        transform.position = (Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 4));

        if (Physics.Raycast(ray, out hit))
        {
           
            if (hit.collider == water)
            {
              
            }
            else
            {
               // transform.position = (Vector3.MoveTowards(transform.position, ray.direction, Time.deltaTime * 4));
            }
        }
    }
}
