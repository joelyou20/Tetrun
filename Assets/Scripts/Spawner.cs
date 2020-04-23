using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] groups;

    private List<GameObject> _spawnedGroups;
    private GameObject _curGroup;

    // Start is called before the first frame update
    void Start()
    {
        _spawnedGroups = new List<GameObject>();
        SpawnNext();
    }

    // Update is called once per frame
    void Update()
    {
        if(_curGroup != null && _curGroup.GetComponent<Group>().IsSet())
        {
            SpawnNext();
        }
    }

    public List<GameObject> GetSpawnedObjects() => _spawnedGroups;

    public void SpawnNext()
    {
        // Random Group Index
        int gi = Random.Range(0, groups.Length);

        // Random Drop Position Index
        int dpi = Random.Range(-3, 3);
        var dzp = new Vector2(transform.position.x + dpi, transform.position.y);

        // Random Rotation

        int r = Random.Range(1, 4);
        var qr = Quaternion.Euler(0, 0, 90f * r);

        _curGroup = Instantiate(groups[gi], dzp, qr);

        // Spawn Group at current Position
        _spawnedGroups.Add(_curGroup);
    }

    public float GetHighestBlockY()
    {
        float result = float.NegativeInfinity;
        // TODO: Fix so you don't need to iterate through each group every time
        _spawnedGroups.ForEach(x =>
        {
            Group group = x.GetComponent<Group>();
            if(group.IsSet())
            {
                var t = group.GetBlocks();
                var highest = t.OrderBy(z => z.position.y).ToArray()[0].position.y;
                if (highest > result) result = highest;
            }
        });

        return result;
    }
}
