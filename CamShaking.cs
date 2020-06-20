using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaking : MonoBehaviour
{
    public Animator CamAnim;
    
    public void CamShake()
    {
        CamAnim.SetTrigger("shaking"); //shaking the camera when the player touche an enemy
    }
}
