using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float Speed;
    public bool see;

    // Use this for initialization
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (see == true)
        {
            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, (transform.position.y - Player.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
        }
        else
        {
            Vector2 velocity = new Vector2(Random.value, Random.value);
            GetComponent<Rigidbody2D>().velocity = -velocity;
        }
    }
}