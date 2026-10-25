using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    public AudioSource audioSource;
    public AudioClip menuMusic;
    public AudioClip level1Music;
    public AudioClip level2Music;
    public AudioClip finallevelMusic;
    
    private AudioClip CurrentMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        PlayMusicForScene();
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene();
    }

    void PlayMusicForScene()
    {
        if (audioSource == null) return;
        
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"Scene: {SceneManager.GetActiveScene().name}, Build Index: {buildIndex}");
        AudioClip newMusic = null;

        switch (buildIndex)
        {
            case 0: // Menu Music
                newMusic = menuMusic;
                break;
            case 1: // Credits
                newMusic = menuMusic;
                break;
            case 2: // Controls
                newMusic = menuMusic;
                break;
            case 3: // level 1
                newMusic = level1Music;
                break;
            case 4: // level 2
                newMusic = level2Music;
                break;
            case 5: // Level 3
                newMusic = finallevelMusic;
                break;
        }
        
        // Only change music if different
        if (newMusic != null && newMusic != CurrentMusic)
        {
            audioSource.clip = newMusic;
            audioSource.Play();
            CurrentMusic = newMusic;
        }
    }
}