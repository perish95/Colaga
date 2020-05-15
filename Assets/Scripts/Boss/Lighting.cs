using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public GameObject lightingPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyLighting",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* private void LightingAttack(){
        GameObject lighting = Instantiate(lightingPrefab, new Vector3(transform.position.x, 
        transform.position.y - 15f, 0f), Quaternion.identity);
        Invoke("DestroyLighting", 2f);
    }*/

    private void DestroyLighting(){
        Destroy(this.gameObject);
    }
}
