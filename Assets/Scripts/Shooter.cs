using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [HideInInspector]
    public bool bulletSizeUp;
    [HideInInspector]
    public bool _powerUp;

    public float bulletSize;
    public int bulletLine;


    public List<Vector3> bulletPos = new List<Vector3>();

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private Transform _bulletSpawnOffset;

    [SerializeField]
    private Vector2 _bulletDirection;

    [SerializeField]
    private ColorType _bulletColor = ColorType.Red;

    [SerializeField, Range(0, 10)]
    private float _bulletPerSecond;
    private float _fireRate;
    private bool _speedUp;

    [SerializeField, Range(500, 1000)]
    private float _bulletSpeed;

    private void Start()
    {
        bulletSizeUp = false;
        bulletSize = 3f;
        bulletLine = 1;
        StartCoroutine(ShootBullet());
    }

    private IEnumerator ShootBullet()
    {
        while (true)
        {
            if (_bulletColor == ColorType.None)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(_fireRate);
                _fireRate = 1.0f / _bulletPerSecond;
                InitbulletPos(bulletLine);
                foreach (Vector3 tempPos in bulletPos)
                {
                    //GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnOffset.position, Quaternion.identity);
                    GameObject bullet = Instantiate(_bulletPrefab, tempPos, Quaternion.identity);
                    if (bulletSizeUp)
                    {
                        bullet.transform.localScale += new Vector3(bulletSize, bulletSize, 0);
                    }
                    bullet.GetComponent<Bullet>().SetBulletColorType(_bulletColor);
                    bullet.GetComponent<SpriteRenderer>().color = Colors.GetRGBAColor(_bulletColor);
                    bullet.GetComponent<Rigidbody2D>().AddForce(_bulletDirection * _bulletSpeed);

                    if(_speedUp) //스피드 
                        bullet.GetComponent<Bullet>().SetPowerDown();
                    if(_powerUp)
                        bullet.GetComponent<Bullet>().SetPowerUp();
                }
            }
        }
    }

    private void InitbulletPos(int bulletLine)
    {
        if(bulletLine >= 3)
            bulletLine = 3;
        bulletPos.Clear();
        switch (bulletLine)
        {
            case 1:
                bulletPos.Add(_bulletSpawnOffset.position);
                break;
            case 2:
                bulletPos.Add(_bulletSpawnOffset.position + new Vector3(-3f, 0, 0));
                bulletPos.Add(_bulletSpawnOffset.position + new Vector3(3f, 0, 0));
                break;
            case 3:
                bulletPos.Add(_bulletSpawnOffset.position);
                bulletPos.Add(_bulletSpawnOffset.position + new Vector3(3f, 0, 0));
                bulletPos.Add(_bulletSpawnOffset.position + new Vector3(-3f, 0, 0));
                break;

            default:
                break;
        }
    }

    public void SetBulletColor(ColorType color)
    {
        _bulletColor = color;
    }

    public void SetFireRate(int rate)
    {
        _fireRate = rate;
    }

    public void SetBulletSpeed(float speed)
    {
        _bulletSpeed = speed;
    }

    public void SetBulletPerSecondUp(){
        _bulletPerSecond *= 2;
        _speedUp = true;
    }

    public void SetBulletPerSecondDown(){
        if(_bulletPerSecond <= 1)
            return;
        _bulletPerSecond /= 2;
        _powerUp = true;
    }

    public void InitBulletPerSecond(){
        _bulletPerSecond = 2;
    }
}
