using System.Collections;
using System.Collections.Generic;
// using UnityEngine.InputSystem; // <-- 1. ĐÃ XÓA DÒNG NÀY
using TMPro;
using UnityEngine;

public class ControlsBindingText : MonoBehaviour
{
    public string actionId;
    public string keyboardBindingId;
    private int keyboardBindingIndex;
    public string gamepadBindingId;
    private int gamepadBindingIndex;
    private bool keyboardDisplayStatus = false;

    // --- Các biến của Input MỚI (đã bị xóa) ---
    // private PlayerInput playerInput; 
    private TextMeshPro objectText;
    // private InputAction bindingAction;
    private static string empty = "";
    // private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    void Start()
    {
        // Toàn bộ code cũ trong này dùng Input MỚI (PlayerInputSingleton)
        // mà chúng ta đã xóa.
        // Chúng ta sẽ vô hiệu hóa nó để ngăn lỗi.

        objectText = gameObject.GetComponent<TextMeshPro>();
        if (objectText != null)
        {
            // Hiển thị 'N/A' (Không khả dụng) vì menu này không còn hoạt động
            objectText.text = "N/A";
        }
    }

    public void UpdateDisplayText()
    {
        // Vô hiệu hóa
        if (objectText != null)
            objectText.text = "N/A";
    }

    public void SetKeyboardDisplayStatus(bool status)
    {
        keyboardDisplayStatus = status;
        UpdateDisplayText();
    }

    public void StartRebinding()
    {
        // Vô hiệu hóa - Hàm này dùng Input MỚI
    }

    private void RebindComplete()
    {
        // Vô hiệu hóa - Hàm này dùng Input MỚI

        // PlayerSettings.Instance.SaveUserRebinds(); // <-- 2. ĐÃ VÔ HIỆU HÓA LỖI NÀY
    }
}