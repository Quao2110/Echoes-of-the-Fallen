using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem; // <-- ĐÃ XÓA
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour, SceneController
{
    private int menuLayer = 1;
    private Vector2Int mainMenuPosition = new Vector2Int(1, 1);
    private Vector2Int settingsPosition = new Vector2Int(1, 1);
    private Vector2Int controlsPosition = new Vector2Int(1, 1);

    // layer 1
    private List<float> playButton = new List<float>() { -3.89f, 4.11f, -1.03f, 1.97f, 1f, 1f, 1f };
    private List<float> settingsButton = new List<float>() { -3.89f, 4.11f, -3.05f, -0.05f, 1f, 2f, 1f };
    private List<float> creditsButton = new List<float>() { -3.89f, 4.11f, - 5.05f, -2.24f, 1f, 3f, 1f };
    private List<float> gameIntroductionButton = new List<float>() { -9.95f, -2.95f, -7.24f, -4.24f, 1f, 4f, 1f };
    private List<float> quitButton = new List<float>() { -3.89f, 4.11f, -9.05f, -6.37f, 1f, 5f, 1f }; 
    // layer 2
    private List<float> fullscreen = new List<float>() { -1.43f, 8.57f, 1.11f, 3.11f, 2f, 1f, 1f }; 
    private List<float> fullscreenRight = new List<float>() { 8.6f, 11.6f, 1.11f, 3.11f, 2f, 1f, 2f };
    private List<float> fullscreenLeft = new List<float>() { -4.43f, -1.43f, 1.11f, 3.11f, 2f, 1f, -1f };
    private List<float> music = new List<float>() { -1.43f, 8.57f, -1.14f, 0.86f, 2f, 2f, 1f }; 
    private List<float> musicRight = new List<float>() { 8.6f, 11.6f, -1.14f, 0.86f, 2f, 2f, 2f };
    private List<float> musicLeft = new List<float>() { -4.43f, -1.43f, -1.14f, 0.86f, 2f, 2f, -1f };
    private List<float> effects = new List<float>() { -1.43f, 8.57f, -3.39f, -1.39f, 2f, 3f, 1f };
    private List<float> effectsRight = new List<float>() { 8.6f, 11.6f, -3.39f, -1.39f, 2f, 3f, 2f };
    private List<float> effectsLeft = new List<float>() { -4.43f, -1.43f, -3.39f, -1.39f, 2f, 3f, -1f };
    private List<float> keyboardSettings = new List<float>() { -1.43f, 8.57f, -5.64f, -3.64f, 2f, 4f, 1f }; 
    private List<float> gamepadSettings = new List<float>() { -1.43f, 8.57f, -7.89f, -5.89f, 2f, 5f, 1f }; 
    private List<float> language = new List<float>() { -1.43f, 8.57f, -10.14f, -8.14f, 2f, 6f, 1f }; 
    private List<float> languageRight = new List<float>() { 8.5f, 11.6f, -10.14f, -8.14f, 2f, 6f, 2f };
    private List<float> languageLeft = new List<float>() { -15.0f, -1.43f, -10.14f, -8.14f, 2f, 6f, -1f };

    // Nút Exit (Vẫn dùng tọa độ CŨ, bạn cần gửi hình nếu đã di chuyển nó)
    private List<float> settingsExit = new List<float>() { -4f, 4f, -10.5f, -6.5f, 2f, 7f, 1f };
    private List<float> select1 = new List<float>() { -9.97f, -2.47f, 0.84f, 2.84f, 3f, 1f, 1f };
    private List<float> select2 = new List<float>() { -1.87f, 5.63f, 0.84f, 2.84f, 3f, 1f, 2f }; 
    private List<float> back1 = new List<float>() { -9.94f, -2.44f, -1.41f, 0.59f, 3f, 2f, 1f }; 
    private List<float> back2 = new List<float>() { -1.87f, 5.63f, -1.41f, 0.59f, 3f, 2f, 2f }; 
    private List<float> up1 = new List<float>() { -9.97f, -2.47f, -3.66f, -1.66f, 3f, 3f, 1f }; 
    private List<float> up2 = new List<float>() { -1.84f, 5.66f, -3.66f, -1.66f, 3f, 3f, 2f };
    private List<float> down1 = new List<float>() { -9.97f, -2.47f, -5.91f, -3.91f, 3f, 4f, 1f };
    private List<float> down2 = new List<float>() { -1.87f, 5.63f, -5.91f, -3.91f, 3f, 4f, 2f }; 
    private List<float> right1 = new List<float>() { -9.97f, -2.47f, -10.41f, -8.41f, 3f, 6f, 1f };
    private List<float> right2 = new List<float>() { -1.87f, 5.63f, -10.41f, -8.41f, 3f, 6f, 2f }; 
    private List<float> left1 = new List<float>() { -9.97f, -2.47f, -8.16f, -6.16f, 3f, 5f, 1f }; 
    private List<float> left2 = new List<float>() { -1.87f, 5.63f, -8.16f, -6.16f, 3f, 5f, 2f }; 
    private List<float> controlsReset = new List<float>() { 8.3f, 16.3f, 2.55f, 6.05f, 3f, 7f, 2f }; 


    private List<List<float>> sceneClickables = new List<List<float>>();
    [SerializeField] private ControlsController controlsController;
    [SerializeField] private SettingsController settingsController;

    private int mainMenuLayerMax = 5;
    private int settingsPosXMax = 7;
    private int controlsPosXMax = 7;

    [SerializeField] private SelectedIcon selectedIconLeft;
    [SerializeField] private SelectedIcon selectedIconRight;

    private List<TextMeshPro> mainMenuOptions = new List<TextMeshPro>();
    private List<TextMeshPro> creditsOptions = new List<TextMeshPro>();


    void Awake()
    {
        menuLayer = 1;
        sceneClickables.Add(playButton);
        sceneClickables.Add(settingsButton);
        sceneClickables.Add(creditsButton);
        sceneClickables.Add(gameIntroductionButton);
        sceneClickables.Add(quitButton);
        sceneClickables.Add(fullscreen);
        sceneClickables.Add(music);
        sceneClickables.Add(effects);
        sceneClickables.Add(keyboardSettings);
        sceneClickables.Add(gamepadSettings);
        sceneClickables.Add(language);
        sceneClickables.Add(settingsExit);
        sceneClickables.Add(fullscreenLeft);
        sceneClickables.Add(fullscreenRight);
        sceneClickables.Add(musicLeft);
        sceneClickables.Add(musicRight);
        sceneClickables.Add(effectsLeft);
        sceneClickables.Add(effectsRight);
        sceneClickables.Add(languageLeft);
        sceneClickables.Add(languageRight);
        sceneClickables.Add(select1);
        sceneClickables.Add(select2);
        sceneClickables.Add(back1);
        sceneClickables.Add(back2);
        sceneClickables.Add(up1);
        sceneClickables.Add(up2);
        sceneClickables.Add(down1);
        sceneClickables.Add(down2);
        sceneClickables.Add(right1);
        sceneClickables.Add(right2);
        sceneClickables.Add(left1);
        sceneClickables.Add(left2);
        sceneClickables.Add(controlsReset);
    }

    void Start()
    {
        foreach (GameObject mainText in GameObject.FindGameObjectsWithTag("mainOptions"))
        {
            mainMenuOptions.Add(mainText.GetComponent<TextMeshPro>());
        }

        foreach (GameObject creditsText in GameObject.FindGameObjectsWithTag("creditsText"))
        {
            creditsOptions.Add(creditsText.GetComponent<TextMeshPro>());
        }
        HideCredits();
    }

    // <-- THÊM HÀM UPDATE VÀO ĐÂY -->
    void Update()
    {
        // --- Kiểm tra di chuyển bằng phím ---
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Util.Direction.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Util.Direction.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Util.Direction.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Util.Direction.right);
        }

        // --- Kiểm tra nút Chọn (Select) ---
        // "Attack" là "mouse 0" (chuột trái) mà bạn đã cài đặt trong Input Manager
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Attack"))
        {
            Select();
        }

        // --- Kiểm tra nút Quay lại (Back) ---
        // "Fire2" thường là "mouse 1" (chuột phải)
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire2"))
        {
            Back();
        }

        // --- Xử lý chuột (Point & Click) ---
        if (Camera.main != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Cập nhật vị trí con trỏ chuột để highlight
            Point(mousePos);

            // Kiểm tra click chuột trái (nút "Attack")
            if (Input.GetButtonDown("Attack"))
            {
                Click(mousePos);
            }
        }
    }


    public void Move(Util.Direction direction)
    {
        if (direction == Util.Direction.up)
        {
            if (menuLayer == 1)
            {
                if (mainMenuPosition.x > 1)
                {
                    mainMenuPosition.x -= 1;
                    AudioManagers.Instance.PlayMenuMove();
                }
            }
            else if (menuLayer == 2)
            {
                if (mainMenuPosition.x == 2)
                {
                    if (settingsPosition.x > 1)
                    {
                        settingsPosition.x -= 1;
                        AudioManagers.Instance.PlayMenuMove();
                    }
                }
            }
            else if (menuLayer == 3)
            {
                if (controlsPosition.x > 1)
                {
                    controlsPosition.x -= 1;
                    AudioManagers.Instance.PlayMenuMove();
                }
            }
        }
        else if (direction == Util.Direction.down)
        {
            if (menuLayer == 1)
            {
                if (mainMenuPosition.x < mainMenuLayerMax)
                {
                    mainMenuPosition.x += 1;
                    AudioManagers.Instance.PlayMenuMove();
                }
            }
            else if (menuLayer == 2)
            {
                if (mainMenuPosition.x == 2)
                {
                    if (settingsPosition.x < settingsPosXMax)
                    {
                        settingsPosition.x += 1;
                        AudioManagers.Instance.PlayMenuMove();
                    }
                }
            }
            else if (menuLayer == 3)
            {
                if (controlsPosition.x < controlsPosXMax)
                {
                    controlsPosition.x += 1;
                    AudioManagers.Instance.PlayMenuMove();
                }
            }
        }
        else if (direction == Util.Direction.left)
        {
            if (menuLayer == 2)
            {
                if (mainMenuPosition.x == 2)
                {
                    settingsController.Left(GetSettingOptionFromXPos());
                }
            }
            else if (menuLayer == 3)
            {
                if (controlsPosition.y == 2)
                {
                    controlsPosition.y -= 1;
                    AudioManagers.Instance.PlayMenuMove();
                }
            }
        }
        else if (direction == Util.Direction.right)
        {
            if (menuLayer == 2)
            {
                if (mainMenuPosition.x == 2)
                {
                    settingsController.Right(GetSettingOptionFromXPos());
                }
            }
            else if (menuLayer == 3)
            {
                if (controlsPosition.y == 1)
                {
                    controlsPosition.y += 1;
                    AudioManagers.Instance.PlayMenuMove();
                }
            }
        }
        UpdateSelected();
    }

    public void Select()
    {
        if (menuLayer == 1)
        {
            if (mainMenuPosition.x == 1)
            {
                SceneManager.LoadScene("Introduction");
            }
            else if (mainMenuPosition.x == 2)
            {
                // 2. SETTINGS
                menuLayer += 1;
                ResetLayerDefaultPositions(true, true);
                HideMain();
                settingsController.ShowSettings();
                AudioManagers.Instance.PlayMenuSelect();
            }
            else if (mainMenuPosition.x == 3)
            {
                // 3. CREDITS
                menuLayer += 1;
                AudioManagers.Instance.PlayMenuSelect();
                HideMain();
                ShowCredits();
            }
            else if (mainMenuPosition.x == 4)
            {
                menuLayer += 1;
                AudioManagers.Instance.PlayMenuSelect();
                HideMain();
                ShowCredits();
            }
            else if (mainMenuPosition.x == 5)
            {
                // 5. EXIT
                Application.Quit();
            }
        }
        else if (menuLayer == 2)
        {
            if (mainMenuPosition.x == 2)
            {
                if (settingsPosition.x == 4)
                {
                    menuLayer += 1;
                    settingsController.HideSettings();
                    ResetLayerDefaultPositions(false, true);
                    controlsController.ShowControls(true);
                    AudioManagers.Instance.PlayMenuSelect();
                }
                else if (settingsPosition.x == 5)
                {
                    menuLayer += 1;
                    settingsController.HideSettings();
                    ResetLayerDefaultPositions(false, true);
                    controlsController.ShowControls(false);
                    AudioManagers.Instance.PlayMenuSelect();
                }
                else if (settingsPosition.x == 7)
                {
                    AudioManagers.Instance.PlayMenuSelect();
                    ExitSettings();
                    ShowMain();
                }
            }
        }
        else if (menuLayer == 3)
        {
            if (controlsPosition.x == 7)
            {
                if (controlsPosition.y == 1)
                {
                    menuLayer = 2;
                    controlsController.HideControls();
                    settingsController.ShowSettings();
                }
                else
                {
                    // PlayerSettings.Instance.RestoreControlDefaults();
                    controlsController.ReDisplayCorrectBindings();
                }
                AudioManagers.Instance.PlayMenuSelect();
            }
            else
            {
                controlsController.RemapSelectedControl(GetControlsOptionFromXYPos());
                AudioManagers.Instance.PlayMenuSelect();
            }
        }
        UpdateSelected();
    }

    private void UpdateSelected()
    {
        int xPositionUpdate = menuLayer == 1 ? mainMenuPosition.x : menuLayer == 2 ? settingsPosition.x : controlsPosition.x;
        int yPositionUpdate = menuLayer == 1 ? mainMenuPosition.y : menuLayer == 2 ? settingsPosition.y : controlsPosition.y;
        selectedIconLeft.UpdateSelectedIconPosition(menuLayer, xPositionUpdate, yPositionUpdate, mainMenuPosition.x);
        selectedIconRight.UpdateSelectedIconPosition(menuLayer, xPositionUpdate, yPositionUpdate, mainMenuPosition.x);
        if (menuLayer == 2 && mainMenuPosition.x == 2)
        {
            settingsController.ChangeSettingSelected(GetSettingOptionFromXPos());
        }
    }

    private void ResetLayerDefaultPositions(bool settings, bool controls)
    {
        if (settings)
        {
            settingsPosition.x = 1;
            settingsPosition.y = 1;
        }
        else if (controls)
        {
            controlsPosition.x = 1;
            controlsPosition.y = 1;
        }
    }

    public void Back()
    {
        if (menuLayer == 2)
        {
            if (mainMenuPosition.x == 2)
            {
                ExitSettings();
                AudioManagers.Instance.PlayMenuBack();
            }
            else if (mainMenuPosition.x == 3)
            {
                menuLayer = 1;
                HideCredits();
                ShowMain();
                AudioManagers.Instance.PlayMenuBack();
            }
        }
        else if (menuLayer == 3)
        {
            menuLayer = 2;
            controlsController.HideControls();
            settingsController.ShowSettings();
            AudioManagers.Instance.PlayMenuBack();
        }
        UpdateSelected();
    }

    public void Click(Vector2 clickLocation)
    {
        Vector2Int clickAnalysis = Util.ReturnPositionFromMouse(clickLocation, menuLayer, sceneClickables);
        if (clickAnalysis.x != 0)
        {
            if (menuLayer == 1)
            {
                if (mainMenuPosition.x != clickAnalysis.x || mainMenuPosition.y != clickAnalysis.y)
                {
                    AudioManagers.Instance.PlayMenuMove();
                }
                mainMenuPosition = clickAnalysis;
            }
            else if (menuLayer == 2)
            {
                if (mainMenuPosition.x == 2)
                {
                    if (clickAnalysis.y == -1)
                    {
                        Move(Util.Direction.left);
                    }
                    else if (clickAnalysis.y == 2)
                    {
                        Move(Util.Direction.right);
                    }
                    else
                    {
                        if (settingsPosition.x != clickAnalysis.x)
                        {
                            AudioManagers.Instance.PlayMenuMove();
                        }
                        settingsPosition = clickAnalysis;
                    }
                }
            }
            else if (menuLayer == 3)
            {
                if (controlsPosition.x != clickAnalysis.x || controlsPosition.y != clickAnalysis.y)
                {
                    AudioManagers.Instance.PlayMenuMove();
                }
                controlsPosition = clickAnalysis;
            }
            Select();
        }
    }

    public void Point(Vector2 pointerLocation)
    {
        Vector2Int pointAnalysis = Util.ReturnPositionFromMouse(pointerLocation, menuLayer, sceneClickables);
        if (pointAnalysis.x != 0)
        {
            if (menuLayer == 1)
            {
                if (mainMenuPosition.x != pointAnalysis.x || mainMenuPosition.y != pointAnalysis.y)
                {
                    AudioManagers.Instance.PlayMenuMove();
                }
                mainMenuPosition = pointAnalysis;
            }
            else if (menuLayer == 2)
            {
                if (mainMenuPosition.x == 2)
                {
                    if (settingsPosition.x != pointAnalysis.x)
                    {
                        AudioManagers.Instance.PlayMenuMove();
                    }
                    settingsPosition = pointAnalysis;
                }
            }
            else if (menuLayer == 3)
            {
                if (controlsPosition.x != pointAnalysis.x || controlsPosition.y != pointAnalysis.y)
                {
                    AudioManagers.Instance.PlayMenuMove();
                }
                controlsPosition = pointAnalysis;
            }
            UpdateSelected();
        }
    }

    private ControlsController.ControlsOptions GetControlsOptionFromXYPos()
    {
        if (controlsPosition.x == 1)
        {
            if (controlsPosition.y == 1)
            {
                return ControlsController.ControlsOptions.selectOne;
            }
            else
            {
                return ControlsController.ControlsOptions.selectTwo;
            }
        }
        else if (controlsPosition.x == 2)
        {
            if (controlsPosition.y == 1)
            {
                return ControlsController.ControlsOptions.backOne;
            }
            else
            {
                return ControlsController.ControlsOptions.backTwo;
            }
        }
        else if (controlsPosition.x == 3)
        {
            if (controlsPosition.y == 1)
            {
                return ControlsController.ControlsOptions.upOne;
            }
            else
            {
                return ControlsController.ControlsOptions.upTwo;
            }
        }
        else if (controlsPosition.x == 4)
        {
            if (controlsPosition.y == 1)
            {
                return ControlsController.ControlsOptions.downOne;
            }
            else
            {
                return ControlsController.ControlsOptions.downTwo;
            }
        }
        else if (controlsPosition.x == 5)
        {
            if (controlsPosition.y == 1)
            {
                return ControlsController.ControlsOptions.leftOne;
            }
            else
            {
                return ControlsController.ControlsOptions.leftTwo;
            }
        }
        else if (controlsPosition.x == 6)
        {
            if (controlsPosition.y == 1)
            {
                return ControlsController.ControlsOptions.rightOne;
            }
            else
            {
                return ControlsController.ControlsOptions.rightTwo;
            }
        }
        else
        {
            if (controlsPosition.y == 1)
            {
                return ControlsController.ControlsOptions.exit;
            }
            else
            {
                return ControlsController.ControlsOptions.reset;
            }
        }
    }

    private SettingsController.SettingOptions GetSettingOptionFromXPos()
    {
        if (settingsPosition.x == 1)
        {
            return SettingsController.SettingOptions.fullscreen;
        }
        else if (settingsPosition.x == 2)
        {
            return SettingsController.SettingOptions.musicVolume;
        }
        else if (settingsPosition.x == 3)
        {
            return SettingsController.SettingOptions.effectsVolume;
        }
        else if (settingsPosition.x == 4)
        {
            return SettingsController.SettingOptions.keyboardControls;
        }
        else if (settingsPosition.x == 5)
        {
            return SettingsController.SettingOptions.gamepadControls;
        }
        else if (settingsPosition.x == 6)
        {
            return SettingsController.SettingOptions.language;
        }
        else
        {
            return SettingsController.SettingOptions.na;
        }
    }

    private void HideMain()
    {
        foreach (TextMeshPro mainMenuOption in mainMenuOptions)
        {
            mainMenuOption.enabled = false;
        }
    }

    private void ShowMain()
    {
        foreach (TextMeshPro mainMenuOption in mainMenuOptions)
        {
            mainMenuOption.enabled = true;
        }
    }

    private void ShowCredits()
    {
        foreach (TextMeshPro creditsOption in creditsOptions)
        {
            creditsOption.enabled = true;
        }
    }

    private void HideCredits()
    {
        foreach (TextMeshPro creditsOption in creditsOptions)
        {
            creditsOption.enabled = false;
        }
    }

    private void ExitSettings()
    {
        menuLayer = 1;
        settingsController.HideSettings();
        ShowMain();
    }
}