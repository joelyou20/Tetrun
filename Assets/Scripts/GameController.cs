using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject dropZone;
    public GameObject deathZone;
    public GameObject player;
    public float scrollOffset;
    public float deathZoneSpeed;

    private Spawner _spawner;
    private List<GameObject> _spawnedGroups;

    // Start is called before the first frame update
    void Start()
    {
        _spawner = dropZone.GetComponent<Spawner>();
        InvokeRepeating("AdvanceDeathZone", 0, 0.01f / deathZoneSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_spawner.GetHighestBlockY());
        //Debug.Log(dropZone.transform.position.y);
        if(_spawner.GetHighestBlockY() >= dropZone.transform.position.y - scrollOffset)
        {
            var newDropZonePos = new Vector2(
                dropZone.transform.position.x,
                dropZone.transform.position.y + 5);
            dropZone.transform.position = newDropZonePos;

        }
    }

    private void AdvanceDeathZone()
    {
        var newDeathZoneScale = new Vector2(
            deathZone.transform.localScale.x,
            deathZone.transform.localScale.y + 0.01f);
        deathZone.transform.localScale = newDeathZoneScale;

    }
}
