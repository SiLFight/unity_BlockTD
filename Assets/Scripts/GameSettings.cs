using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings 
{
    private static GameSettings instance;

    public string GameMode { get; set; }

    public static GameSettings getInstance()
    {
        if (instance == null)
        {
            instance = new GameSettings();
        }
        return instance;
    }

    private GameSettings()
    {
    }
}
