using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    public enum Language { English, Vietnamese, SimplifiedChinese };
    private static Language curLanguage = Language.English;

    public static Dictionary<string, string> localizedEN;
    public static Dictionary<string, string> localizedVI;
    public static Dictionary<string, string> localizedSC;
    public static bool isInit = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator UpdateTextsAfterFrame()
    {
        yield return new WaitForEndOfFrame();
        UpdateAllTexts();
    }
    void Start()
    {
        // Đặt ngôn ngữ theo cài đặt người chơi
        SetLanguage(PlayerSettings.Instance.GetLanguage());
        StartCoroutine(UpdateTextsAfterFrame());
    }

    public void UpdateAllTexts()
    {
        LocalizedText[] texts = FindObjectsOfType<LocalizedText>(true); // 🆕 thêm true để cập nhật cả object bị inactive
        foreach (LocalizedText textObject in texts)
        {
            textObject.LocalizeTextObject();
        }
    }

    public static void Init()
    {
        if (isInit) return; // 🆕 tránh load lại nhiều lần

        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localizedEN = csvLoader.GetDictionaryValues("en");
        localizedVI = csvLoader.GetDictionaryValues("vi");
        localizedSC = csvLoader.GetDictionaryValues("sc");

        isInit = true;
    }

    public static string GetLocalizedValue(string key)
    {
        if (!isInit) Init();

        string value;
        switch (curLanguage)
        {
            case Language.English:
                if (localizedEN.TryGetValue(key, out value)) return value;
                break;
            case Language.Vietnamese:
                if (localizedVI.TryGetValue(key, out value)) return value;
                break;
            case Language.SimplifiedChinese:
                if (localizedSC.TryGetValue(key, out value)) return value;
                break;
        }

        // Nếu key không có thì trả lại chính key để dễ debug
        return $"[{key}]";
    }

    public static void SetLanguage(int languageNum)
    {
        if (!isInit) Init();

        switch (languageNum)
        {
            case 1:
                curLanguage = Language.English;
                break;
            case 2:
                curLanguage = Language.Vietnamese;
                break;
            case 3:
                curLanguage = Language.SimplifiedChinese;
                break;
            default:
                curLanguage = Language.English;
                break;
        }
    }

    public static Language GetCurrentLanguage()
    {
        return curLanguage;
    }
}
