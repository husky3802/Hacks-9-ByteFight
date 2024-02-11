using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SmartCamMovement : MonoBehaviour
{

    new Camera camera;
    public float testvar = 5f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3((GameObject.Find("Bug").transform.position.x + GameObject.Find("Byte").transform.position.x) / 2, camera.transform.position.y, camera.transform.position.z);
        camera.orthographicSize = Mathf.Max(5f, (GameObject.Find("Bug").transform.position.x + GameObject.Find("Byte").transform.position.x) / 2 + 1f);

    }
}
