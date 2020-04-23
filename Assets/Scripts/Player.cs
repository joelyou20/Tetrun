using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathCam;

    private bool _grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, 2.0f))
        {
            _grounded = true;
        }

        if (_grounded)
        {
            Group group = null;
            var hit = Physics2D.Raycast(transform.position, Vector2.up, 0.5f);
            if(hit && hit.collider.gameObject.layer ==
                LayerMask.NameToLayer("World")) {
                    group = hit.collider.gameObject.GetComponent<Group>(); 
            }
            if(group != null && !group.IsSet())
            {
                DestroyPlayer();
            }
        }
    }

    public void DestroyPlayer()
    {
        StartCoroutine(DestroyPlayerCoroutine());
    }

    IEnumerator DestroyPlayerCoroutine()
    {
        deathCam.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
