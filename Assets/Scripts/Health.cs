using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ColorSelector))]
public class Health : MonoBehaviour
{
    public UnityEvent _deathEvent;

    [SerializeField]
    private float _maxHealth;

    [SerializeField]
    private float _currentHealth;

    private ColorSelector _color;

    private void Awake()
    {
        _color = GetComponent<ColorSelector>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("EnemyBullet") && this.CompareTag("Player")) ||
            (other.CompareTag("PlayerBullet") && this.CompareTag("Enemy")))
        {
            Debug.Log("Hit!!");
            var _bullet = other.GetComponent<Bullet>();

            if (_bullet.GetBulletColorType() != _color.currentColor)
            {
                _bullet.DestroyBullet();
                return;
            }

            _currentHealth -= _bullet.GetBulletDamage();
            if (_currentHealth <= 0)
            {
                _bullet.DestroyBullet();
                _deathEvent.Invoke();
            }
        }

        if(other.CompareTag("Player") && this.CompareTag("Enemy")){
            var _player = other.GetComponent<PlayerController>();
            Destroy(_player.gameObject);
            _deathEvent.Invoke();            
        }
        
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public void SetMaxHealth(float health)
    {
        _maxHealth = health;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void GiveHealth(float amount)
    {
        _currentHealth += amount;
    }
}
