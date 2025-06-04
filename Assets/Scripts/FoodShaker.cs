using UnityEngine;

public class FoodShaker : MonoBehaviour
{
    
    public Camera cam;
    RaycastHit hit;
    Collider foodCol;
    public GameObject food;


    void Start()
    {
        foodCol = GameObject.Find("Food collider").GetComponent<Collider>();
        //boidSim = GameObject.Find("BoidSpawner").GetComponent<BoidSimulation>();
    }

    void Update()
    {
        MoveToMouse();
        SpawnFood();


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
        Debug.DrawRay(ray.origin, ray.direction * 5, Color.green);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == foodCol)
            {
                transform.position = (Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 4));
            }
            else
            {
                transform.position = (Vector3.MoveTowards(transform.position, ray.direction, Time.deltaTime * 4));
            }
        }
    }
}
