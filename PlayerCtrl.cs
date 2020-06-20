using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private Vector2 targetPos;
    public float Y_Increment; //to set up and down position for a player to move

    public float speed;
    public float maxHeight; //set highest Y-axis to set when the player go up
    public float minHeight; //set lowest Y-axis to set when the player go down
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
        anim.setInteger("condition", 0); //Running animation(Idle)
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

        if(Health == 0)
        {
            anim.SetInteger("condition", 2);
            speed = 0;
            StartCoroutine(SetDelayDead());            
        }

        IEnumerator SetDelayDead() //set Delay time before changing scenes
        {
            yield return new WaitForSeconds(2); 
            SceneManager.LoadScene(0); //Replay scene again(play again)
        }
    }
}
