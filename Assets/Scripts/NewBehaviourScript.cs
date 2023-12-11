using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    List<int> ints;

    void Start()
    {
        ints = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        Debug.Log(ints.FindIndex(x => x == 2));
    }
}
