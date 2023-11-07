using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlurScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PostProcessVolume pVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
            pVolume.enabled = !pVolume.enabled;
        }
    }
}
