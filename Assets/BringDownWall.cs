using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringDownWall : MonoBehaviour
{
    public Animator Walls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Wall)
    {
        if (Wall.CompareTag("Wall"))
        {
            Walls.SetTrigger("Stepped");
        }
    }
}
