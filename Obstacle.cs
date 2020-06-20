using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    private CamShaking camShaking;
    public GameObject FX;
    
    void Start()
    {
        camShaking = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShaking>();
    }

    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); //enemies always move left
        speed += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            camShaking.CamShake();
            Instantiate(FX, transform.position, Quaternion.identity); //show the FX if enemies collide with player
            other.GetComponent<PlayerCtrl>().Health -= damage; //decrease player's health
            Debug.Log("Health -1");
            Destroy(gameObject);
        }
    }
}
