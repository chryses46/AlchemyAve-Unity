using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum State {MainMenu, Play, Pause};

    public State gameState = State.MainMenu;

    public static StateController instance;
    void Awake()
    {
        instance = this;
    }
}
