using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{

    //Game Manager
    private GameManager gameManager;

    [SerializeField] private GameObject _ShootPrefab;

    [Header("Enemy1 STATS")]
    [SerializeField]
    private int _hp = 1;

    private bool _fireRate = false;
    private float _fireDelay;
    [SerializeField]
    private float _speed = 7f;
    [SerializeField]
    private int _enemyScore = 30;

    private int counter = 1;
    private float initialY;
    [Header("RayCastData")]
    RaycastHit2D hit;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {

        _fireDelay = Random.Range(1f, 5f);
        hit = Physics2D.Raycast(transform.position, Vector2.down, 10f);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.down * 10f, Color.red);
            if (hit.collider.tag == "Player")
            {
                Shoot(_fireDelay);
            }

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FireShoot")
        {
            _hp--;
            if (_hp <= 0)
            {
                gameManager.score += _enemyScore;
                Destroy(this.gameObject);
            }
        }

    }

    public void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (transform.position.x >= 12f)
        {
            transform.position = new Vector3(-12f, transform.position.y, 0);
            counter++;
        }
        if (transform.position.y <= -3.59f)
        {
            transform.position = new Vector3(transform.position.x, initialY, 0);
        }
        if (counter >= 5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.20f, 0);
            counter = 1;
        }


    }
    public void Shoot(float _fireDelayRandom)
    {

        if (!_fireRate)
        {
            _fireRate = true;
            StartCoroutine(ShootDelay(_fireDelayRandom));
            Instantiate(_ShootPrefab, transform.position, Quaternion.identity);
        }


    }

    IEnumerator ShootDelay(float randomDelay)
    {
        yield return new WaitForSeconds(randomDelay);
        _fireRate = false;
    }

}
