using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] int pointsLeft = 2;
    [SerializeField] TextMeshProUGUI pointsLeftText;
    int currentIndex;

    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (pointsLeftText == null) return;
        pointsLeftText.text = pointsLeft + " Points left for upgrade...";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentIndex + 1);
        pointsLeft = 2;
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        pointsLeft = 2;
    }

    public void DisplayGameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        pointsLeft = 2;
    }

    public void UpgradeFireRate()
    {
        if (pointsLeft == 0) return;
        var change = UpgradePlayerPrefs.GetGunFireRate() - 0.1f;
        if (change >= 0.2f)
        {
            UpgradePlayerPrefs.SetGunFireRate(change);
            pointsLeft--;
            if (pointsLeftText == null) return;
            pointsLeftText.text = pointsLeft + " Points left for upgrade...";
        }
        else
        {
            StartCoroutine(MaxedOut());
        }
    }

    public void UpgradeRechargeTime()
    {
        if (pointsLeft == 0) return;
        var change = UpgradePlayerPrefs.GetMissileRechargeTime() - 2;
        Debug.Log(change);
        if (change >= 4)
        {
            UpgradePlayerPrefs.SetMissileRechargeTime(change);
            pointsLeft--;
            if (pointsLeftText == null) return;
            pointsLeftText.text = pointsLeft + " Points left for upgrade...";
        }
        else
        {
            StartCoroutine(MaxedOut());
        }
    }

    public void UpgradeMissileDamage()
    {
        if (pointsLeft == 0) return;
        var change = UpgradePlayerPrefs.GetMissileDamage() + 50;
        if (change <= 250)
        {
            UpgradePlayerPrefs.SetMissileDamage(change);
            pointsLeft--;
            if (pointsLeftText == null) return;
            pointsLeftText.text = pointsLeft + " Points left for upgrade...";
        }
        else
        {
            StartCoroutine(MaxedOut());
        }
    }

    public void UpgradeGunDamage()
    {
        if (pointsLeft == 0) return;
        var change = UpgradePlayerPrefs.GetGunDamage() + 5;
        if (change <= 45)
        {
            UpgradePlayerPrefs.SetGunDamage(change);
            pointsLeft--;
            if (pointsLeftText == null) return;
            pointsLeftText.text = pointsLeft + " Points left for upgrade...";
        }
        else
        {
            StartCoroutine(MaxedOut());
        }
    }

    public void UpgradeBusMaxSpeed()
    {
        if (pointsLeft == 0) return;
        var change = UpgradePlayerPrefs.GetBusMaxMoveSpeed() + 2;
        if (change < 15)
        {
            UpgradePlayerPrefs.SetBusMaxMoveSpeed(change);
            pointsLeft--;
            if (pointsLeftText == null) return;
            pointsLeftText.text = pointsLeft + " Points left for upgrade...";
        }
        else
        {
            StartCoroutine(MaxedOut());
        }
    }

    IEnumerator MaxedOut()
    {
        pointsLeftText.text = "Maxed Out...";
        yield return new WaitForSeconds(2);
        pointsLeftText.text = pointsLeft + " Points left for upgrade...";
    }
}
