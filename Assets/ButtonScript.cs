using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    public Button Button; 
    // Update is called once per frame
    void Update()
    {
        Button.onClick.AddListener(CloseUI);
    }
    void CloseUI() {


        UI.SetActive(false);

    }
}
