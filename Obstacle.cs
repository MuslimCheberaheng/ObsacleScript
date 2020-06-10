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
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        speed += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            camShaking.CamShake();
            Instantiate(FX, transform.position, Quaternion.identity);
            other.GetComponent<PlayerCtrl>().Health -= damage;
            Debug.Log("Health -1");
            Destroy(gameObject);
        }
    }
}
