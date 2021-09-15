using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm_Button : MonoBehaviour
{
    [SerializeField]
    GameObject InforWindow;
    // Start is called before the first frame update
    void Start()
    {
        InforWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        InforWindow.SetActive(false);
    }
}
