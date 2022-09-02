using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    void LateUpdate()
    {
        CountItHigher cih = this.gameObject.GetComponent<CountItHigher>();
        if(cih != null)
        {
            float tX = cih.CurrentNum / 10f;
            Vector3 tempLoc = Pos;
            tempLoc.x = tX;
            Pos = tempLoc;
        }
    }
    public Vector3 Pos
    {
        get { return this.transform.position; }
        set { this.transform.position = value; }
    }
}
