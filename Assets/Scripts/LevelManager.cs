using System.Collections.Generic;
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
    public static float WinRate
    {
        set
        {
            PlayerPrefs.SetFloat("WinRate", value);
        }
        get
        {
            return PlayerPrefs.GetFloat("WinRate", 0.5f);
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
        38,
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

    readonly static float[] speedMins =
    {
        0.3f,
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
        0.4f,
        0.4f,
        0.4f,
        0.4f,
        0.4f,
        0.4f,
        0.4f,
        0.4f,
        0.4f,
        0.45f,
        0.45f,
        0.45f,
        0.55f,
    };

    readonly static float[] speedMaxes =
    {
        0.35f,
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
        0.6f,
        0.6f,
        0.6f,
        0.6f,
        0.66f,
        0.55f,
        0.55f,
        0.55f,
        0.55f,
        0.6f,
        0.6f,
        0.7f,
    };

    public static int[,] weights =
    {
        {1,0,0,0,0},
        {1,0,0,0,0},
        {1,0,0,0,0},
        {1,0,0,0,0},
        {1,0,0,0,0},
        {6,1,0,0,0},
        {5,1,0,0,0},
        {4,1,0,0,0},
        {4,1,0,0,0},
        {4,1,0,0,0},
        {4,1,0,0,0},
        {9,1,1,0,0},
        {8,1,1,0,0},
        {8,1,1,0,0},
        {8,1,1,0,0},
        {8,1,1,0,0},
        {8,1,1,0,0},
        {16,0,0,2,0},
        {20,1,1,1,0},
        {19,1,1,1,0},
        {19,1,1,1,0},
        {19,1,1,1,0},
        {19,1,1,1,0},
        {19,1,1,1,1},
    };

    public static int GetRandomEnemyIndex(Random random)
    {
        List<int> enemyIndicies = new();
        for (int i = 0; i < weights.GetLength(1); i++)
        {
            for (int j = 0; j < weights[levelNum - 1, i]; j++)
            {
                enemyIndicies.Add(i);
            }
        }
        return enemyIndicies[random.Next(enemyIndicies.Count)];
    }

    public static float SpeedModifier()
    {
        if (WinRate > 0.75f)
        {
            return 0.1f;
        } 
        else if (WinRate > 0.4f)
        {
            return 0;
        } else if (WinRate > 0.3f)
        {
            return -0.1f;
        } else
        {
            return -0.15f;
        }
    }

    public static float GetRandomSpeed(Random random){
        return speedMins[levelNum - 1] + ((float)random.NextDouble())*(speedMaxes[levelNum - 1] - speedMins[levelNum - 1]) + SpeedModifier();
    }
}
