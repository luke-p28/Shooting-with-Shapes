using UnityEngine;
using Random = System.Random;

public class LevelManager
{
    public static int levelNum = 1;
    public static int LevelsUnlocked
    {
        set
        {
            PlayerPrefs.SetInt("LevelUnlocked", value);
            //Debug.Log("pref to " + value);
        }
        get
        {
            //Debug.Log("pref from " + PlayerPrefs.GetInt("LevelUnlocked", 1));
            return PlayerPrefs.GetInt("LevelUnlocked", 1);
        }
    }
    public static int[] enemyCounts =
    {
        10,
        15,
        20,
        22,
        24,
        25,
        26,
        27,
        28,
        29,
        30,
        30,
        31,
        31,
        32,
        32,
        33,
        33,
        34,
        34,
        35,
        35,
        35,
        35,
    };
//     public static float[] dupeChance =
//     {
//         0.3f,
//         0.3f,
//         0.3f,
//         0.4f,
//         0.4f,
//         0.4f,
//         0.4f,
//         0.4f,
//         0.4f,
//         0.4f,
//         0.4f,
//         0.45f,
//         0.45f,
//         0.45f,
//         0.45f,
//         0.45f,
//         0.45f,
//         0.45f,
//         0.45f,
//         0.5f,
//         0.35f,
//         0.5f,
//         0.5f,
//         0.5f,
// };

    public static float[] speedMins =
    {
        0.3f,
        0.3f,
        0.35f,
        0.4f,
        0.4f,
        0.4f,
        0.45f,
        0.45f,
        0.45f,
        0.45f,
        0.45f,
        0.5f,
        0.5f,
        0.5f,
        0.5f,
        0.5f,
        0.55f,
        0.55f,
        0.55f,
        0.6f,
        0.6f,
        0.6f,
        0.6f,
        0.75f,
    };

    public static float[] speedMaxes =
    {
        0.35f,
        0.35f,
        0.4f,
        0.5f,
        0.55f,
        0.55f,
        0.6f,
        0.6f,
        0.6f,
        0.6f,
        0.6f,
        0.7f,
        0.7f,
        0.7f,
        0.7f,
        0.7f,
        0.75f,
        0.75f,
        0.75f,
        0.75f,
        0.8f,
        0.8f,
        0.8f,
        0.85f,
    };

    public static int[,] weights =
    {
        {1,0},
        {1,0},
        {1,0},
        {1,0},
        {1,0},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
        {4,1},
    };

    public static int GetRandomEnemyIndex(Random random)
    {
        int weightsTotal = 0;
        for (int i = 0; i < weights.GetLength(1); i++) weightsTotal += weights[levelNum - 1, i];
        int igb = random.Next(weightsTotal + 1);
        for (int i = 0; true; i++)
        {
            igb -= weights[levelNum - 1, i];
            if (igb <= 0) return i;
        }
    }
}
