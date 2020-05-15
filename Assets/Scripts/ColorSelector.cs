using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public ColorType currentColor = ColorType.None;

    protected Shooter _shooter;
    protected SpriteRenderer _spriteRenderer;

    protected void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void Start()
    {
        UpdateColors();
    }

    protected void UpdateColors()
    {
        _shooter.SetBulletColor(currentColor);
        if (currentColor != ColorType.None)
            _spriteRenderer.color = Colors.GetRGBAColor(currentColor);
    }
}
