using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountItHigher : MonoBehaviour
{
    private int _num = 0;

    void Update()
    {
        print(NextNum); 
    }

    public int NextNum
    { 
        get { _num++; return _num; }
    }

    public int CurrentNum
    {
        get { return _num; }
        set { _num = value; }
    }


}
