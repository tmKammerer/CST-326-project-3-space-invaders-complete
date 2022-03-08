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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        OnEnemyDestroyed?.Invoke(this);

        enemyAnim.SetTrigger("Death");
       
        Destroy(this.gameObject, 0.5f);
    }
}
