using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private Vector2 targetPos;
    public float Y_Increment;

    public float speed;
    public float maxHeight;
    public float minHeight;
    public Text healthDisplay;
    
    public int Health = 3;
    public LinkingScene linkingScene;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        healthDisplay.text = Health.ToString();
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Y_Increment);                        
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Y_Increment);
        } 
        
        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("condition", 1);
            transform.position = new Vector2(0, -1);
            
        }
        else
        {
            anim.SetInteger("condition", 0);
            
        }

        if(Health == 0)
        {
            anim.SetInteger("condition", 2);
            speed = 0;
            StartCoroutine(SetDelayDead());
            
        }

        IEnumerator SetDelayDead()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(0);
        }
    }
}
