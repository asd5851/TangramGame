using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GSingleton<GameManager>
{
    public Dictionary<string,  GameObject> gameObjs = default;

    public override void Awake()
    {
        base.Awake();
    }       // Awake
    protected override void Init()
    {
        base.Init();
        gameObjs = new Dictionary<string, GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
