using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    [Header("UI Elements")]
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public Button nextButton;
    public Button prevButton;

    [Header("Settings")]
    public float transitionSpeed = 10f;

    private int totalPages;
    private int currentPage = 0;
    private float targetHorizontalPosition = 0f;

    void Start()
    {
        // Calculate the total number of slider items
        totalPages = contentPanel.childCount;

        // Assign button click listeners
        if (nextButton != null) nextButton.onClick.AddListener(NextPage);
        if (prevButton != null) prevButton.onClick.AddListener(PreviousPage);

        // Update button visibility at start
        UpdateButtons();
    }

    void Update()
    {
        // Smoothly interpolate to the target position page
        if (scrollRect != null)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(
                scrollRect.horizontalNormalizedPosition,
                targetHorizontalPosition,
                Time.deltaTime * transitionSpeed
            );
        }
    }

    public void NextPage()
    {
        if (currentPage < totalPages - 1)
        {
            currentPage++;
            CalculateTargetPosition();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            CalculateTargetPosition();
        }
    }

    void CalculateTargetPosition()
    {
        // Normalized position goes from 0.0 (leftmost) to 1.0 (rightmost)
        if (totalPages > 1)
        {
            targetHorizontalPosition = (float)currentPage / (totalPages - 1);
        }
        UpdateButtons();
    }

    void UpdateButtons()
    {
        // Optional: Hide buttons if you reach the absolute edge
        if (prevButton != null) prevButton.interactable = (currentPage > 0);
        if (nextButton != null) nextButton.interactable = (currentPage < totalPages - 1);
    }
}
