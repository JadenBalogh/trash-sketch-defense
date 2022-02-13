using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static PathSystem PathSystem { get => instance.pathSystem; }
    private PathSystem pathSystem;

    public static SpawnSystem SpawnSystem { get => instance.spawnSystem; }
    private SpawnSystem spawnSystem;

    public static BuildSystem BuildSystem { get => instance.buildSystem; }
    private BuildSystem buildSystem;

    public static ScoreSystem ScoreSystem { get => instance.scoreSystem; }
    private ScoreSystem scoreSystem;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        pathSystem = GetComponent<PathSystem>();
        spawnSystem = GetComponent<SpawnSystem>();
        buildSystem = GetComponent<BuildSystem>();
        scoreSystem = GetComponent<ScoreSystem>();
    }
}
