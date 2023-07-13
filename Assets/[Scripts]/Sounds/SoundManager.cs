using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic; // List sýnýfýný kullanmak için

public class SoundManager : MonoBehaviour
{
    // Ses kaynaðý ve yankýlanma bileþenleri listesi
    public List<AudioSource> audioSources;
    //public List<AudioReverbZone> audioReverbZones;

    // Ses seviyesi, frekansý ve yankýsý için her ses kaynaðý için ayrý ayrý deðiþkenler
    public List<float> volumes;
    //public List<float> pitches;
    //public List<AudioReverbPreset> reverbs;

    // Ses efektlerini güncelleme
    void Update()
    {
        // Listede bulunan her ses kaynaðý ve yankýlanma bileþeni için
        for (int i = 0; i < audioSources.Count; i++)
        {
            // Ses kaynaðýnýn ses seviyesini ve frekansýný ayarlama
            audioSources[i].volume = volumes[i];
            //audioSources[i].pitch = pitches[i];

            // Yankýlanma bileþeninin yanký ayarýný yapma
            //audioReverbZones[i].reverbPreset = reverbs[i];
        }
    }
}
