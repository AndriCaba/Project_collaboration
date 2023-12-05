using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NextLevelSpawner : MonoBehaviour
{
    public Animator NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        // Trigger the animation
        NextLevel.SetTrigger("WhenKilled");
    }
}
