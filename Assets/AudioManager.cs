using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    [Header("Game SFX")]

    [SerializeField] protected AudioSource shootingSFX;
    [SerializeField] protected AudioSource dieSFX;
    [SerializeField] protected AudioSource UISFX;
    [SerializeField] protected AudioSource winningSFX;
    [SerializeField] protected AudioSource loseSFX;

    public void PlayShootingSFX() => shootingSFX.Play();
    public void PlayDieSFX() => dieSFX.Play();
    public void PlayWinningSFX() => winningSFX.Play();
    public void PlayUISFX() => UISFX.Play();
    public void PlayLoseSFX() => loseSFX.Play();
}
