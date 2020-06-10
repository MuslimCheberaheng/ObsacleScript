using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaking : MonoBehaviour
{
    public Animator CamAnim;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void CamShake()
    {
        CamAnim.SetTrigger("shaking");
    }
}
