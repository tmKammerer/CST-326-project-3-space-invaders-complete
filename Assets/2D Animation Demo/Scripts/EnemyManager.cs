using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    
    public float widthPerEnemy = 3f;
    public Transform enemyRoot;
    public scoreManager scoreManager;
    public Enemy prefab;

    public static int numEnemiesAcross = 3;
    public static int columns = 3;

    public float speed=5f;
    public float shootingRate=1.5f;

    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;

    public static int amountDead { get; private set; }
    public static int amountIn = numEnemiesAcross * columns;
    
    public int amountLiving = amountIn - amountDead;

    private Vector3 direction = Vector2.right;
    // Start is called before the first frame update

    private void Awake()
    {
        for(int row=0; row < numEnemiesAcross; row++)
        {
            float width = 2.0f * (columns - 1);
            float height= 2.0f*(numEnemiesAcross-1);
            Vector2 centering= new Vector2(-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            
            for(int column=0; column< columns; column++)
            {
                Enemy enemy = Instantiate(prefab, this.transform);
                enemy.OnEnemyDestroyed += OnEnemyDied;
                Vector3 position = rowPosition;
                position.x += column * 2.0f;
                enemy.transform.position = position;
            }
        }
    }
    void Start()
    {
        InvokeRepeating(nameof(shootBack), this.shootingRate, this.shootingRate);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * this.speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }
            if(direction==Vector3.right&&enemy.position.x>= rightEdge.x)
            {
                AdvanceRow();
            }else if (direction == Vector3.left && enemy.position.x <= leftEdge.x)
            {
                AdvanceRow();
            }
            

            
        }
    }

    private void AdvanceRow()
    {
        direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;

    }

    private void shootBack()
    {
        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Random.value<(1.0f/(float)amountLiving))
            {
                GameObject shot = Instantiate(bulletPrefab, enemy.position, Quaternion.identity);
                break;
            }
        }

    }
    
    void OnEnemyDied(Enemy enemy)
    {
        enemy.OnEnemyDestroyed -= OnEnemyDied;
        scoreManager.AddPoints(enemy.pointVal);
    }
}
