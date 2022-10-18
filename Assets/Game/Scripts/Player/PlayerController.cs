using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]

    public float MaxEnergy = 100;
    public float currentEnergy;

    [SerializeField]
    private float _speed = 13f;


    [Header("Player Prefabs")]
    [SerializeField]
    private GameObject _shootFirePrefab;

    // Player HiddenStats
    [SerializeField]
    private bool _fireRate = false;
    private float _fireDelay = 1f;

    public EnergyBarController _energyBar;

    void Start()
    {
        transform.position = new Vector2(0, -3.45f);
        currentEnergy = MaxEnergy;
        _energyBar.SetMaxEnergy(currentEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        // Control
        float hor = Input.GetAxisRaw("Horizontal");
        bool shoot = Input.GetKeyDown(KeyCode.Space);
        bool shootJoy = Input.GetKeyDown("joystick button 1");
        Move(hor);
        Shoot(shoot, shootJoy);
        Energy();
    }

    void Move(float hor)
    {
        transform.Translate(hor * _speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= 8.26f)
        {
            transform.position = new Vector3(8.26f, transform.position.y, 0);
        }
        if (transform.position.x <= -8.26f)
        {
            transform.position = new Vector3(-8.26f, transform.position.y, 0);
        }
    }
    public void Shoot(bool shoot, bool shootJoy)
    {
        if (!_fireRate)
        {
            if (shoot || shootJoy)
            {
                _fireRate = true;
                Instantiate(_shootFirePrefab, transform.position, Quaternion.identity);
                StartCoroutine(ShootDelay());
            }
        }

    }
    void Energy()
    {
        if (currentEnergy > 0)
        {
            currentEnergy -= Time.deltaTime;
        }
        float seconds = Mathf.FloorToInt(currentEnergy);
        _energyBar.SetEnergy(currentEnergy);
    }
    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_fireDelay);
        _fireRate = false;
    }
}
