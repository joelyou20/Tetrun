using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public float speed = 5f;

    private bool _set = false;

    // Blocks of group
    private Transform b0;
    private Transform b1;
    private Transform b2;
    private Transform b3;

    // Start is called before the first frame update
    void Start()
    {
        b0 = transform.GetChild(0);
        b1 = transform.GetChild(1);
        b2 = transform.GetChild(2);
        b3 = transform.GetChild(3);

        InvokeRepeating("MoveDown", 0, 0.01f / speed);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log(_grid.CellToLocalInterpolated(b0.position));
        Debug.Log(_grid.CellToLocalInterpolated(b1.position));
        Debug.Log(_grid.CellToLocalInterpolated(b2.position));
        Debug.Log(_grid.CellToLocalInterpolated(b3.position));
        */
    }

    public Transform[] GetBlocks() {
        Transform[] t = { b0, b1, b2, b3 };
        return t;
    }


    public bool IsSet() => _set;

    private void MoveDown()
    {
        if (_set)
        {
            CancelInvoke();
        }
        else
        {
            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;
            transform.position = new Vector3(x, y - 0.01f, z);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == 8)
        {
            _set = true;
        }
    }
}
