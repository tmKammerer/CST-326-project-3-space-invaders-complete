using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    public Vector3 direction;
    public System.Action destroyed;
    public AudioClip bang;
  

  public float speed = 5;
    // Start is called before the first frame update
    

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
        //Debug.Log("Wwweeeeee");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource bangarang = GetComponent<AudioSource>();
        bangarang.clip = bang;
        bangarang.Play();
        
        Destroy(this.gameObject);
    }
}
