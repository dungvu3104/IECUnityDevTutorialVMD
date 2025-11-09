using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening; // 👈 import DOTween

public class UIManager : MonoBehaviour
{
    public Animator startButton;
    public Animator settingsButton;
    public Animator dialog;

    // 🆕 The UI panel you want to move
    public RectTransform contentPanel;

    // 🆕 Track current state
    private bool isPanelDown = false;

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenSettings()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    public void CloseSettings()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }

    // 🆕 Toggle panel up/down with DOTween animation
    public void ToggleContentPanel()
    {
        if (contentPanel == null)
        {
            Debug.LogWarning("⚠ contentPanel is not assigned in the inspector!");
            return;
        }

        // Kill any current tweens on this object (prevents overlap)
        contentPanel.DOKill();

        // Determine the direction
        float moveAmount = isPanelDown ? -192f : 192f;

        // Animate to the new anchoredPosition
        contentPanel.DOAnchorPosY(contentPanel.anchoredPosition.y + moveAmount, 0.4f)
            .SetEase(Ease.OutQuad);

        // Flip the state
        isPanelDown = !isPanelDown;
    }
}
