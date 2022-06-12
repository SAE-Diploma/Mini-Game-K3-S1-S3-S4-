using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum Menus : int
{
    ChooseTower = 0,
    TowerUpgrades = 1
}


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject interactionPanel;
    [SerializeField] List<Image> menus;

    [Header("TowerUpgradePanel")]
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] TextMeshProUGUI attackSpeedValue;
    [SerializeField] TextMeshProUGUI attackSpeedCost;
    [SerializeField] TextMeshProUGUI damageValue;
    [SerializeField] TextMeshProUGUI damageCost;
    [SerializeField] TextMeshProUGUI rangeValue;
    [SerializeField] TextMeshProUGUI rangeCost;
    [SerializeField] TextMeshProUGUI projectileSpeedValue;
    [SerializeField] TextMeshProUGUI projectileSpeedCost;

    [Header("Waves")]
    [SerializeField] TextMeshProUGUI currentWaveText;
    [SerializeField] TextMeshProUGUI timer;

    public void SetMenuVisibility(Menus menu, bool visibility)
    {
        GameObject obj = menus[(int)menu].gameObject;
        obj.SetActive(visibility);
    }

    public void SetInteractionVisibility(bool visibility)
    {
        interactionPanel.SetActive(visibility);
    }

    public void UpdateTowerUpgradePanel(TowerBase tower)
    {
        towerName.text = tower.Tower.name;
        attackSpeedValue.text = $"{tower.AttackSpeed} rps";
        attackSpeedCost.text = ((tower.AttackSpeedLevel) * tower.Tower.AttackspeedUpgradeCost).ToString();
        damageValue.text = $"{tower.Damage} hp";
        damageCost.text = ((tower.DamageLevel) * tower.Tower.DamageUpgradeCost).ToString();
        rangeValue.text = $"{tower.Range} meters";
        rangeCost.text = ((tower.RangeLevel) * tower.Tower.RangeUpgradeCost).ToString();
        projectileSpeedValue.text = $"{tower.ProjectileSpeed} m/s";
        projectileSpeedCost.text = ((tower.ProjectileSpeedLevel) * tower.Tower.ProjectileSpeedUpgradeCost).ToString();
    }

    public void UpdateTowerMenuCoinError(TowerStat stat)
    {
        Animator animator;
        switch (stat)
        {
            case TowerStat.Attackspeed:
                animator = attackSpeedCost.GetComponent<Animator>();
                animator.SetTrigger("NotEnoughCoins");
                break;
            case TowerStat.Damage:
                animator = damageCost.GetComponent<Animator>();
                animator.SetTrigger("NotEnoughCoins");
                break;
            case TowerStat.Range:
                animator = rangeCost.GetComponent<Animator>();
                animator.SetTrigger("NotEnoughCoins");
                break;
            case TowerStat.ProjectileSpeed:
                animator = projectileSpeedCost.GetComponent<Animator>();
                animator.SetTrigger("NotEnoughCoins");
                break;
        }
    }

    public void UpdateWaveCounter(int currentWave, int maxWaveCount)
    {
        currentWaveText.text = $"Wave {currentWave}/{maxWaveCount}";
    }

    public void ShowRemainingTime(int remainingSeconds)
    {
        timer.text = SecondsToTime(remainingSeconds);
    }

    private string SecondsToTime(int timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = timeInSeconds - minutes * 60;
        string secondsString = seconds < 10 ? $"0{seconds}" : seconds.ToString();
        return $"{minutes}:{secondsString}";
    }
}
