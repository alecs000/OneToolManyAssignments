using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Project.Code.UI
{
    public class SoundService : MonoBehaviour
    {
        public const string Music = "Music";
        public const string Effects = "Effects";
        [SerializeField] private AudioMixerGroup audioMixerGroup;
        public void ToggleSound(bool enable, string soundName)
        {
            if (enable)
            {
                TurnSound(soundName, 0);

            }
            else
            {
                TurnSound(soundName, -80);
            }
        }
        public void TurnSound(string soundName, int soundVlue)
        {
            audioMixerGroup.audioMixer.SetFloat(soundName, soundVlue);
        }
    }
}