using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    public float speed = 6f;

    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
      if (Input.GetKeyDown(KeyCode.Space))
      {
            playerAnimator.SetTrigger(Shoot);
        GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ow I die!");
        

        playerAnimator.SetTrigger("Death");

        Destroy(this.gameObject, 0.5f);
    }
}
