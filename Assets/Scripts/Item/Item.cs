using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        Movement();
    }

    private void Movement(){
        transform.Translate(new Vector3(0f, -0.03f, 0f));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            OperateItem();
            Destroy(this.gameObject);
        }
    }

    public abstract void OperateItem();
}
