using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LoadingBar_Handler : MonoBehaviour
{   
    
    [SerializeField]
    private GameObject SlidingBar;
    private float Process;
    [SerializeField]
    private string next_Scene;
    Menuloader SceneHandler = new Menuloader();


    void Start()
    {
        Process = SlidingBar.GetComponent<Scrollbar>().size;
    }
   
    // Update is called once per frame
    void Update()
    {
        SceneHandler.LoadingSceneAsync(next_Scene);
    }
}
