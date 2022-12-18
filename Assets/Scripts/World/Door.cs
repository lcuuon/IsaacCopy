using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform Ldoor;
    [SerializeField] Transform Rdoor;

    [SerializeField] float targetT;
    public float t;

    Vector3 Lpos;
    Vector3 Rpos;
    Vector3 Rtmp;
    Vector3 Ltmp;



    public bool isopen;

    private void Start()
    {
        Rpos = Rdoor.localPosition + new Vector3(-0.25f, 0);
        Lpos = Ldoor.localPosition + new Vector3(0.25f, 0);
        Rtmp = Rdoor.localPosition;
        Ltmp = Ldoor.localPosition;
    }

    void Update()
    {
        if(isopen)
        {
            if(t <= 1)
            {
                t = t + Time.deltaTime;
            }
            Ldoor.localPosition = Vector3.Lerp(Ldoor.localPosition, Lpos, t / targetT);
            Rdoor.localPosition = Vector3.Lerp(Rdoor.localPosition, Rpos, t / targetT);
        }
        else if(!isopen)
        {
            if(t <= 1)
            {
                t = t + Time.deltaTime;
            }
            t = t + Time.deltaTime * 2;
            Ldoor.localPosition = Vector3.Lerp(Ldoor.localPosition, Ltmp, t / targetT);
            Rdoor.localPosition = Vector3.Lerp(Rdoor.localPosition, Rtmp, t / targetT);
        }
    }
}
