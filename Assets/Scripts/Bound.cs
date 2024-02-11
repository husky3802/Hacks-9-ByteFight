using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bound : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Byte")
        {
            SceneManager.LoadSceneAsync(3);
        } else if (other.tag == "Bug")
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}
