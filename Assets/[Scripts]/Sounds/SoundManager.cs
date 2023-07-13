using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic; // List s�n�f�n� kullanmak i�in

public class SoundManager : MonoBehaviour
{
    // Ses kayna�� ve yank�lanma bile�enleri listesi
    public List<AudioSource> audioSources;
    //public List<AudioReverbZone> audioReverbZones;

    // Ses seviyesi, frekans� ve yank�s� i�in her ses kayna�� i�in ayr� ayr� de�i�kenler
    public List<float> volumes;
    //public List<float> pitches;
    //public List<AudioReverbPreset> reverbs;

    // Ses efektlerini g�ncelleme
    void Update()
    {
        // Listede bulunan her ses kayna�� ve yank�lanma bile�eni i�in
        for (int i = 0; i < audioSources.Count; i++)
        {
            // Ses kayna��n�n ses seviyesini ve frekans�n� ayarlama
            audioSources[i].volume = volumes[i];
            //audioSources[i].pitch = pitches[i];

            // Yank�lanma bile�eninin yank� ayar�n� yapma
            //audioReverbZones[i].reverbPreset = reverbs[i];
        }
    }
}
