using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed(Enemy enemy);
    public event EnemyDestroyed OnEnemyDestroyed;

    private Animator enemyAnim;
    public int pointVal = 50;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ouch!");
        if (collision.gameObject.tag == "Bullet")
        {
            OnEnemyDestroyed?.Invoke(this);

            enemyAnim.SetTrigger("Death");

            this.gameObject.SetActive(false);

            Destroy(this.gameObject, 0.5f);
        }
    }
}
