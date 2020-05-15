using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletRemovalDelay = 5f;

    [SerializeField]
    private ColorType _bulletColor = ColorType.Red;

    [SerializeField]
    private float _bulletDamage = 1f;

    public void Start()
    {
        StartCoroutine(RemoveBullet());
    }

    private IEnumerator RemoveBullet()
    {
        yield return new WaitForSeconds(_bulletRemovalDelay);
        Destroy(this.gameObject);
    }

    public ColorType GetBulletColorType()
    {
        return _bulletColor;
    }

    public void SetBulletColorType(ColorType color)
    {
        _bulletColor = color;
    }

    public float GetBulletDamage()
    {
        return _bulletDamage;
    }

    public void SetBulletDamage(float damage)
    {
        _bulletDamage = damage;
    }

    public void DestroyBullet(){
        Destroy(this.gameObject);
    }

    public void SetPowerUp(){
        _bulletDamage *= 2;
    }

    public void SetPowerDown(){
        _bulletDamage /= 2;
    }
}
