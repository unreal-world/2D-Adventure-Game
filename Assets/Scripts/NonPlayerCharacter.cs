using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public string dialogue = "Hello, I'm your friend!";
    public static NonPlayerCharacter instance { get; private set; }

    void Awake()
    {
        instance = this;
    }

}
