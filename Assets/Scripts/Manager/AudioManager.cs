using UnityEngine;


public class AudioManager : Singleton<AudioManager>
{
    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlyer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    AudioSource sfxPlayer;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlyer = bgmObject.AddComponent<AudioSource>();
        bgmPlyer.playOnAwake = false;
        bgmPlyer.loop = true;
        bgmPlyer.volume = bgmVolume;
        bgmPlyer.clip = bgmClip;

        // SFX AudioSource √ ±‚»≠
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayer = sfxObject.AddComponent<AudioSource>();
        sfxPlayer.playOnAwake = false;
        sfxPlayer.loop = false;
        sfxPlayer.volume = sfxVolume;
    }

    public void PlayBgm(bool isPlay)
    {
        if (isPlay)
        {
            bgmPlyer.Play();
        }
        else
        {
            bgmPlyer.Stop();
        }
    }

    public void PlaySfx(int sfxIndex)
    {
        if (sfxIndex < 0 || sfxIndex >= sfxClips.Length)
        {
            Debug.LogWarning("SFX index out of range");
            return;
        }

        sfxPlayer.clip = sfxClips[sfxIndex];
        sfxPlayer.PlayOneShot(sfxPlayer.clip);
    }

}