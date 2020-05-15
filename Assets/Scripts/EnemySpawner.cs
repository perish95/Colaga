using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpawnGroup
{
    public List<Transform> waypoints;
    public List<GameObject> spawnPrefabs;
    public List<Transform> dests;
    public float spawnDelay;
    public bool useRandomizer;
}

public class EnemySpawner : MonoBehaviour
{
    public List<SpawnGroup> spawnGroups;

    private int _enemyCount;

    private void Start()
    {

        foreach (var spawnGroup in spawnGroups)
        {
            // Debug.Log(spawnGroup + " has started spawning.");
            StartCoroutine(StartSpawnGroup(spawnGroup));
        }
    }

    private IEnumerator StartSpawnGroup(SpawnGroup spawnGroup)
    {
        int tmpCount = 0;
        System.Random random = new System.Random();
        foreach (var prefab in spawnGroup.spawnPrefabs)
        {
            var enemy = Instantiate(prefab, spawnGroup.waypoints[0].position, Quaternion.identity);
            enemy.GetComponent<WaypointFollower>().StartFollow(spawnGroup.waypoints);
            _enemyCount++;
            tmpCount++;

            enemy.GetComponent<Enemy>().dest = spawnGroup.dests[tmpCount - 1];

            if (spawnGroup.useRandomizer)
            {
                Array colors = Enum.GetValues(typeof(ColorType));
                ColorType randomColor = (ColorType)colors.GetValue(random.Next(colors.Length));
                if (randomColor == ColorType.None)
                {
                    randomColor = ColorType.Red;
                }
                enemy.GetComponent<ColorSelector>().currentColor = randomColor;

            }

            yield return new WaitForSeconds(spawnGroup.spawnDelay);
        }
    }

    public int GetEnemyCount(){
        return _enemyCount;
    }
}
