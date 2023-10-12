using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    Boundry _offLimit;

    Vector3 _direction;
    [SerializeField]
    float _speed = 5;
    // Start is called before the first frame update

    BulletManager _manager;
    void Start()
    {
        _manager = FindAnyObjectByType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * Time.deltaTime * _speed;

        if(transform.position.y > _offLimit.max || transform.position.y < _offLimit.min)
        {
            _manager.ReturnBullet(gameObject);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        _direction = dir;
    }
}
