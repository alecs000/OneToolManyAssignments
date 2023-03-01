using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Code.UI
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle effectsToggle;
        [SerializeField] private SoundService soundService;
        public Toggle MusicToggle => musicToggle;
        public Toggle SoundToggle => effectsToggle;
        private void Start()
        {
            GetSavedSettings();
            musicToggle.onValueChanged.AddListener(ToggleMusic);
            effectsToggle.onValueChanged.AddListener(ToggleEffects);
        }
        public void ToggleMusic(bool enable)
        {
            soundService.ToggleSound(enable, SoundService.Music);
            PlayerPrefs.SetInt(SoundService.Music, enable ? 0 : -80);
        }
        public void ToggleEffects(bool enable)
        {
            soundService.ToggleSound(enable, SoundService.Effects);
            PlayerPrefs.SetInt(SoundService.Effects, enable ? 0 : -80);
        }
        public void ShowInfo()
        {
            System.Diagnostics.Process.Start("https://github.com/alecs000/OneToolManyAssignments");
        }
        private void GetSavedSettings()
        {
            if (PlayerPrefs.HasKey(SoundService.Music))
            {
                int music = PlayerPrefs.GetInt(SoundService.Music);
                soundService.TurnSound(SoundService.Music, music);
                musicToggle.isOn = music == 0;
            }
            if (PlayerPrefs.HasKey(SoundService.Effects))
            {
                int effects = PlayerPrefs.GetInt(SoundService.Effects);
                soundService.TurnSound(SoundService.Effects, effects);
                musicToggle.isOn = effects == 0;
            }
        }
    }
}