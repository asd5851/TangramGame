using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCreator : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Create();                                                                                                   
    }
    void Start()
    {
        #if DEBUG_MODE
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
        #else
        GFunc.LoadScene(GData.SCENE_NAME_TITLE);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
