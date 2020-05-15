using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ColorSelector))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particle;

    private ColorSelector _colorSelector;
    private int _myNumber;
    private float _speed = 10f;
    private bool _towardDest = false;

    [HideInInspector]
    public Transform dest;


    private void Awake()
    {
        _colorSelector = GetComponent<ColorSelector>();
        var spawner = GameObject.Find("EnemySpawner");
        _myNumber = spawner.GetComponent<EnemySpawner>().GetEnemyCount();
    }

    private void Update(){
        if(_towardDest)
            transform.position = Vector2.MoveTowards(transform.position, dest.position , _speed * Time.deltaTime);
    }

    public void Death()
    {
        var effect = Instantiate(_particle) as ParticleSystem;
        ParticleSystem.MainModule main = effect.main;

        effect.transform.position = transform.position;
        main.startColor = Colors.GetRGBAColor(_colorSelector.currentColor);
        effect.Play();

        Score.instance.currentScore += 5;

        Destroy(effect.gameObject, effect.main.duration);
        Destroy(this.gameObject);

        var itemSpawner = GameObject.Find("ItemSpawner");
        itemSpawner.GetComponent<ItemSpawner>().GenerateItem(this.transform.position, _myNumber);
    }

    public void EndDest(){
        _towardDest = true;
    }
}
