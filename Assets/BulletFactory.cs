using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private GameObject _bulletPrefab;

    [SerializeField]
    private Sprite _playerBulletSprite, _enemyBulletSprite;
    // Start is called before the first frame update
    void Start()
    {
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    public GameObject CreateBullet(BulletTypes type)
    {
        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.SetActive(false);
        bullet.transform.parent = GetComponentInChildren<Transform>();
        
        

        switch (type)
        {
            case BulletTypes.PLAYERBULLET:
                bullet.name = "PlayerBullet";

                bullet.GetComponent<SpriteRenderer>().sprite = _playerBulletSprite;
                bullet.GetComponent<BulletBehavior>().SetDirection(Vector3.up);

                bullet.GetComponent<BulletBehavior>().SetType(BulletTypes.PLAYERBULLET);
                break;
            case BulletTypes.ENEMYBULLET:
                bullet.name = "EnemyBullet";

                bullet.GetComponent<SpriteRenderer>().sprite = _enemyBulletSprite;
                bullet.GetComponent<BulletBehavior>().SetDirection(Vector3.down);

                bullet.GetComponent<BulletBehavior>().SetType(BulletTypes.ENEMYBULLET);

                bullet.transform.RotateAround(Vector3.forward, Mathf.Deg2Rad * 180);

                break;

            default:
                Debug.LogError("Incorrect type of bullet");
                break;
        }

        return bullet;

    }

    
}
