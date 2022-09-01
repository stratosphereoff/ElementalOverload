using UnityEngine;

public static class EnemyDatabase
{
    public static Enemy[] Enemies { get; private set; }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        Enemies = Resources.LoadAll<Enemy>("Enemies/");
    } 
}
