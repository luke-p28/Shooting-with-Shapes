using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    AudioSource player;
    public AudioClip[] tracks;
    public AudioClip clickEffect;
    public AudioClip explosionEffect;
    public AudioClip enemyExplosionEffect;
    public AudioClip lifeLossEffect;
    static List<AudioClip> audioClips;
    static float fadeTime = 2;
    static int currentTrack = 0;
    static int nextTrack;
    static float fadeTimer;
    static bool firstPlayer = true;
    static float loopTimer;
    static float loopTime = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!firstPlayer) Destroy(gameObject);
        else firstPlayer = false;
        loopTimer = loopTime;
        fadeTimer = -fadeTime;
        player = GetComponent<AudioSource>();
        player.PlayOneShot(tracks[0]);
        DontDestroyOnLoad(gameObject);
        audioClips = new()
        {
            clickEffect,
            explosionEffect,
            enemyExplosionEffect,
            lifeLossEffect
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTimer > -fadeTime)
        {
            if (fadeTimer > 0)
            {
                player.volume = fadeTimer/fadeTime;
            } else if (currentTrack != nextTrack)
            {
                player.Stop();
                print("stopped");
                player.PlayOneShot(tracks[nextTrack]);
                print("playing");
                currentTrack = nextTrack;
            } else
            {
                player.volume = -fadeTimer/fadeTime;
            }
            fadeTimer -= Time.deltaTime;
        } else if (!player.isPlaying)
        {
            if (loopTimer > 0)
            {
                loopTimer -= Time.deltaTime;
            } else
            {
                if (currentTrack == 1 || currentTrack == 2 || currentTrack == 3)
                {
                    nextTrack = (currentTrack % 3) + 1;
                    currentTrack = nextTrack;
                    player.PlayOneShot(tracks[nextTrack]);
                } else
                {
                    player.PlayOneShot(tracks[currentTrack]);
                }
                loopTimer = loopTime;
            }
        } else
        {
            // print(SceneManager.GetActiveScene().buildIndex);
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                if (currentTrack != 1 && currentTrack != 2 && currentTrack != 3)
                {
                    PlayTrack(Random.Range(1,4));
                }
            } else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                if (currentTrack != 4)
                {
                    PlayTrack(4);
                }
            } else
            {
                if (currentTrack != 0)
                {
                    PlayTrack(0);
                }
            }
        }
    }

    public static void PlayTrack(int track)
    {
        nextTrack = track;
        fadeTimer = fadeTime;
    }

    public static void LoseLife()
    {
        AudioSource.PlayClipAtPoint(audioClips[3], Vector3.zero);
    }

    public static void Explosion()
    {
        AudioSource.PlayClipAtPoint(audioClips[1], Vector3.zero);
    }

    public static void EnemyExplosion()
    {
        AudioSource.PlayClipAtPoint(audioClips[2], Vector3.zero);
    }

    public static void Click()
    {
        print("clicked");
        AudioSource.PlayClipAtPoint(audioClips[0], Vector3.zero);
    }
}
