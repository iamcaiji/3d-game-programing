using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    void Start()
    {
        cube = Instantiate(Resources.Load<GameObject>("Cube"), new Vector3(0, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(0,1,0), new Vector3(1,3,0), 7 * Time.deltaTime);
    }
}
