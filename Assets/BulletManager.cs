using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GameObject _bulletPrefab;
    Queue<GameObject> _bulletPool = new Queue<GameObject>();

    [SerializeField]
    int _bulletTotal = 50;


    // Start is called before the first frame update
    void Start()
    {
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

        BuildBulletPool();
    }

    //Instantiate a bullet pool

    void BuildBulletPool()
    {
        //create bullets
        //add them to a list

        for(int i = 0; i < _bulletTotal; i++)
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab);
        
        bullet.SetActive(false);
        bullet.transform.SetParent(transform);
        _bulletPool.Enqueue(bullet);

    }
    
    public GameObject GetBullet(Vector3 spawnPos, Vector3 dir, Color color)
    {
        if( _bulletPool.Count < 1 )
            CreateBullet();

        GameObject bullet = _bulletPool.Dequeue();

        if (!Vector3.Equals(dir, Vector3.up))
        {
            if (Vector3.Equals(dir, Vector3.down))
            {
                bullet.transform.rotation = new Quaternion(0, 0, 0, 0);
                bullet.transform.RotateAround(Vector3.forward, Mathf.Deg2Rad * 180);
                //bullet.transform.rotation = Quaternion.AxisAngle(Vector3.forward, 1);
            }

        }

        bullet.SetActive(true);
        bullet.transform.position = spawnPos;
        bullet.GetComponent<BulletBehavior>().SetDirection(dir);
        bullet.GetComponent<SpriteRenderer>().color = color;
        
     


        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);



        _bulletPool.Enqueue(bullet);
    }
}
