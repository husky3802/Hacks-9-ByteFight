using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_controller : MonoBehaviour
{

    Transform cam;  
    Vector3 camStartPos;
    float distance;
    GameObject[] backgrounds;
    Material[] materials;
    float[] backSpeed;

    float farthestBack;

    [Range(0.01f,0.05f)]
    public float parallaxSpeed;

    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount =  transform.childCount;
        materials = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];    

        for (int i = 0; i < backCount; i++) 
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount) 
    {
        for (int i = 0; i < backCount; i++) //find the farthest back
        {
            if ( (backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++) //set the background speed
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z-cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate() 
    {
        distance = cam.position.x- camStartPos.x;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
