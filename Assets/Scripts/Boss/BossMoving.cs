using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoving : MonoBehaviour
{
    public GameObject lightingPrefab;
    
    private float _direction;
    // Start is called before the first frame update
    void Start()
    {
        _direction = 0.25f;
        //LightingAttack();
        StartCoroutine(LightingAttack());
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
        transform.Translate(new Vector3(_direction, 0f, 0f));        

    }

    private void Movement(){
        if(transform.position.x <= -20f)
            _direction = 0.25f;
        else if(transform.position.x >= 20f)
            _direction = -0.25f;
    }

    private IEnumerator LightingAttack(){
        while(true){
            GameObject lighting = Instantiate(lightingPrefab, new Vector3(transform.position.x, 
            transform.position.y - 15f, 0f), Quaternion.identity);

            yield return new WaitForSeconds(3f);
        }
    }
}
