using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Giữ lại cái này

// using UnityEngine.InputSystem; // <-- ĐÃ XÓA

public class PlayerSettings : MonoBehaviour
{
    public static PlayerSettings Instance;
    // public PlayerInput playerInput; // <-- ĐÃ XÓA

    private static string defaultBindings = "defaultBindings";
    private static string playerBindings = "playerBindings";
    private static string fullScreenMode = "fullscreenMode";
    private static int fullScreenModeDefault = 1;
    private static string musicVolume = "musicVolume";
    private static int musicVolumeDefault = 2;
    private static string effectsVolume = "effectsVolume";
    private static int effectsVolumeDefault = 8;
    private static string language = "language";
    private static int languageDefault = 1; // 1 - English, 2 - Spanish, 3 - Simplified Chinese, 4 - Vietnamese


    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject); // <-- Giữ nguyên
            Instance = this;

            // --- Toàn bộ code liên quan đến playerInput.actions... đã được XÓA ---
            // (Vì chúng ta không dùng Input MỚI nữa)

            // Chỉ giữ lại code cài đặt PlayerPrefs
            if (!PlayerPrefs.HasKey(fullScreenMode))
            {
                PlayerPrefs.SetInt(fullScreenMode, fullScreenModeDefault);
                PlayerPrefs.Save();
            }
            if (!PlayerPrefs.HasKey(musicVolume))
            {
                PlayerPrefs.SetInt(musicVolume, musicVolumeDefault);
                PlayerPrefs.Save();
            }
            if (!PlayerPrefs.HasKey(effectsVolume))
            {
                PlayerPrefs.SetInt(effectsVolume, effectsVolumeDefault);
                PlayerPrefs.Save();
            }
            if (!PlayerPrefs.HasKey(language))
            {
                PlayerPrefs.SetInt(language, languageDefault);
                PlayerPrefs.Save();
            }
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        SetFullScreenSettings();

        // --- Toàn bộ code load binding và HandleInputSystemState đã được XÓA ---
    }

    // --- Các hàm OnSceneLoaded và HandleInputSystemState đã được XÓA ---


    // --- Các hàm RestoreControlDefaults và SaveUserRebinds đã bị XÓA ---
    // (Vì chúng dùng cho Input MỚI)


    // Các hàm còn lại (ChangeFullScreen, ChangeMusic...) giữ nguyên
    public void ChangeFullScreenMode(int newFullScreenMode)
    {
        if (newFullScreenMode == 1 || newFullScreenMode == 2)
        {
            PlayerPrefs.SetInt(fullScreenMode, newFullScreenMode);
            PlayerPrefs.Save();
        }
        SetFullScreenSettings();
    }

    public void ChangeMusicVolume(int newMusicVolume)
    {
        PlayerPrefs.SetInt(musicVolume, newMusicVolume);
        PlayerPrefs.Save();
        AudioManagers.Instance.UpdateMusicVolume();
    }

    public void ChangeEffectsVolume(int newEffectsVolume)
    {
        PlayerPrefs.SetInt(effectsVolume, newEffectsVolume);
        PlayerPrefs.Save();
        AudioManagers.Instance.UpdateEffectsVolume();
        AudioManagers.Instance.UpdateEffectsVolume();
    }

    public void ChangeLanguage(int newLanguage)
    {
        PlayerPrefs.SetInt(language, newLanguage);
        PlayerPrefs.Save();
        LocalizationManager.SetLanguage(newLanguage);
        LocalizationManager.Instance.UpdateAllTexts();
    }

    public int GetFullScreenMode()
    {
        return PlayerPrefs.GetInt(fullScreenMode);
    }

    public int GetMusicVolume()
    {
        return PlayerPrefs.GetInt(musicVolume);
    }

    public int GetEffectsVolume()
    {
        return PlayerPrefs.GetInt(effectsVolume);
    }

    public int GetLanguage()
    {
        return PlayerPrefs.GetInt(language);
    }

    private void SetFullScreenSettings()
    {
        if (PlayerPrefs.GetInt(fullScreenMode) == 1)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else if (PlayerPrefs.GetInt(fullScreenMode) == 2)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}