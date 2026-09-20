using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    AudioSource player;
    public AudioClip[] tracks;
    static float fadeTime = 2;
    static int currentTrack = 0;
    static int nextTrack;
    static float fadeTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeTimer = -fadeTime;
        player = GetComponent<AudioSource>();
        player.PlayOneShot(tracks[0]);
        DontDestroyOnLoad(gameObject);
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
                player.PlayOneShot(tracks[nextTrack]);
                currentTrack = nextTrack;
            } else
            {
                player.volume = -fadeTimer/fadeTime;
            }
            fadeTimer -= Time.deltaTime;
        } else if (!player.isPlaying)
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
}
