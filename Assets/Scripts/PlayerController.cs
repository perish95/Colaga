using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _direction;
    // Start is called before the first frame update
    void Awake()
    {
        _direction = 0f;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalcPos();
            if (_direction != 0)
                Movement();
        }

        if (Input.GetKey(KeyCode.A))
        {
            _direction = -0.3f;
            Movement();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _direction = 0.3f;
            Movement();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -34f, 34f),
            transform.position.y
        );
    }

    void Movement()
    {
        transform.Translate(new Vector3(_direction, 0f, 0f));
    }

    void CalcPos()
    {
        Vector2 tem = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (tem.x >= -34 && tem.x < -17)
            _direction = -0.3f;
        else if (tem.x >= -17 && tem.x <= -8)
            _direction = 0.3f;
        else
            _direction = 0f;
    }

}
