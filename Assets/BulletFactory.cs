using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private GameObject _bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    public GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab);

        return bullet;

    }

    
}
