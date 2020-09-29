using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}

    public GameMode gameMode;
    public Vector2 lookSensitivity;
    public float verticalLookMaximum;
    public float verticalLookMinimum;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameMode {
    PVP, VS_AI, tutorial
}