using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject boundaryObject1;
    public GameObject boundaryObject2;
    public GameObject boundaryObject3;
    public GameObject boundaryObject4;

    // Start is called before the first frame update
    void Start()
    {
        GameObject object1 = Instantiate(prefab);
        GameObject object2 = Instantiate(prefab);

        object1.GetComponent<MainObject>().boundaryObject1 = boundaryObject1;
        object1.GetComponent<MainObject>().boundaryObject2 = boundaryObject2;
        object2.GetComponent<MainObject>().boundaryObject1 = boundaryObject3;
        object2.GetComponent<MainObject>().boundaryObject2 = boundaryObject4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
