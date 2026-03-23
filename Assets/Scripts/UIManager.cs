using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static bool hasSeenTutorial = false;

    [Header("UI elements")]
    public TextMeshProUGUI scoreText;
    public Image energyBarFill;
    public GameObject onboardingPanel;

    [Header("Onboarding")]
    public GameObject[] tutorialSteps; 
    private int currentStepIndex = 0;  

    private float maxEnergy = 100f;
    private bool isOnboarding = true;

    void Start()
    {
        if (!hasSeenTutorial)
        {
            isOnboarding = true;
            onboardingPanel.SetActive(true);
            Time.timeScale = 0f;

            for (int i = 0; i < tutorialSteps.Length; i++)
            {
                tutorialSteps[i].SetActive(i == 0);
            }
        }
        else
        {
            isOnboarding = false;
            onboardingPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if (isOnboarding)
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                AdvanceTutorial();
            }
            return;
        }

        if (GameManager.Instance != null)
        {
            UpdateScoreUI();
            UpdateEnergyUI();
        }
    }

    private void AdvanceTutorial()
    {
        if (currentStepIndex < tutorialSteps.Length)
        {
            tutorialSteps[currentStepIndex].SetActive(false);
        }

        currentStepIndex++;

        if (currentStepIndex < tutorialSteps.Length)
        {
            tutorialSteps[currentStepIndex].SetActive(true);
        }
        else
        {
            EndOnboarding();
        }
    }

    private void EndOnboarding()
    {
        isOnboarding = false;
        hasSeenTutorial = true; 

        onboardingPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void UpdateScoreUI()
    {
        int currentScore = Mathf.FloorToInt(GameManager.Instance.pointTotal);
        scoreText.text = currentScore.ToString();
    }

    private void UpdateEnergyUI()
    {
        float currentEnergy = GameManager.Instance.energy;
        energyBarFill.fillAmount = currentEnergy / maxEnergy;
    }
}