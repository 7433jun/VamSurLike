using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MyButton
{
    public Image icon;
    public TextMeshProUGUI level;
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
}

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] WeaponManager weaponManager;
    [SerializeField] GameObject upgradeScreen;
    [SerializeField] GameObject[] myButtons;
    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject[] equipedWeapons;
    [SerializeField] MyButton[] buttons;
    [SerializeField] Sprite[] icons;

    int[] weaponLevels = new int[8];
    int[] buttonInput = new int[3];

    List<int> currentWeapons;
    List<int> newWeapons;

    private bool levelUpFlag;

    void Start()
    {
        currentWeapons = new List<int>();
        newWeapons = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

        LevelUp();
    }

    void Update()
    {
        if (levelUpFlag)
        {
            if (myButtons[0].activeSelf && Input.GetKeyDown(KeyCode.Alpha1))
            {
                Button(0);
            }
            if (myButtons[1].activeSelf && Input.GetKeyDown(KeyCode.Alpha2))
            {
                Button(1);
            }
            if (myButtons[2].activeSelf && Input.GetKeyDown(KeyCode.Alpha3))
            {
                Button(2);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Skip();
            }
        }
    }

    public void LevelUp()
    {
        GameManager.instance.TimeStop();
        levelUpFlag = true;

        List<int> selectCurrentWeapons = new List<int>(currentWeapons);
        List<int> selectNewWeapons = new List<int>(newWeapons);

        upgradeScreen.SetActive(true);
        skipButton.SetActive(true);

        foreach(var e in currentWeapons)
        {
            if(weaponLevels[e] >= 8)
            {
                selectCurrentWeapons.Remove(e);
            }
        }

        if (currentWeapons.Count == 0)
        {
            for (int i = 0;i < 3; i++)
            {
                int number = selectNewWeapons[Random.Range(0, selectNewWeapons.Count)];
                selectNewWeapons.Remove(number);

                buttons[i].icon.sprite = icons[number];
                buttons[i].level.text = LevelText(number);
                buttons[i].name.text = NameText(number);
                buttons[i].description.text = DescriptionText(number);

                buttonInput[i] = number;
            }

            skipButton.SetActive(false);
        }
        if (currentWeapons.Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (selectCurrentWeapons.Count == 0)
                {
                    myButtons[i].SetActive(false);
                }
                else
                {
                    int number = selectCurrentWeapons[Random.Range(0, selectCurrentWeapons.Count)];
                    selectCurrentWeapons.Remove(number);

                    buttons[i].icon.sprite = icons[number];
                    buttons[i].level.text = LevelText(number);
                    buttons[i].name.text = NameText(number);
                    buttons[i].description.text = DescriptionText(number);

                    buttonInput[i] = number;
                }
            }
        }
        else
        {
            for(int i = 0; i < 3; i++)
            {
                if(selectCurrentWeapons.Count == 0)
                {
                    int number = selectNewWeapons[Random.Range(0, selectNewWeapons.Count)];
                    selectNewWeapons.Remove(number);

                    buttons[i].icon.sprite = icons[number];
                    buttons[i].level.text = LevelText(number);
                    buttons[i].name.text = NameText(number);
                    buttons[i].description.text = DescriptionText(number);

                    buttonInput[i] = number;
                }
                else
                {
                    if(Random.value < 0.3)
                    {
                        int number = selectCurrentWeapons[Random.Range(0, selectCurrentWeapons.Count)];
                        selectCurrentWeapons.Remove(number);

                        buttons[i].icon.sprite = icons[number];
                        buttons[i].level.text = LevelText(number);
                        buttons[i].name.text = NameText(number);
                        buttons[i].description.text = DescriptionText(number);

                        buttonInput[i] = number;
                    }
                    else
                    {
                        int number = selectNewWeapons[Random.Range(0, selectNewWeapons.Count)];
                        selectNewWeapons.Remove(number);

                        buttons[i].icon.sprite = icons[number];
                        buttons[i].level.text = LevelText(number);
                        buttons[i].name.text = NameText(number);
                        buttons[i].description.text = DescriptionText(number);

                        buttonInput[i] = number;
                    }
                }
            }
        }
    }

    private string LevelText(int number)
    {
        string result = "";

        switch (weaponLevels[number])
        {
            case 0:
                result = "Lv 1";
                break;
            case 1:
                result = "Lv 2";
                break;
            case 2:
                result = "Lv 3";
                break;
            case 3:
                result = "Lv 4";
                break;
            case 4:
                result = "Lv 5";
                break;
            case 5:
                result = "Lv 6";
                break;
            case 6:
                result = "Lv 7";
                break;
            case 7:
                result = "Lv Max";
                break;
        }
        return result;
    }

    private string NameText(int number)
    {
        string result = "";

        switch (number)
        {
            case 0:
                result = "Wind";
                break;
            case 1:
                result = "Arrow";
                break;
            case 2:
                result = "Thunder";
                break;
            case 3:
                result = "Spike";
                break;
            case 4:
                result = "Fire";
                break;
            case 5:
                result = "Knife";
                break;
            case 6:
                result = "Kunai";
                break;
            case 7:
                result = "Star";
                break;
        }
        return result;
    }

    private string DescriptionText(int number)
    {
        string result = "";

        switch (number)
        {
            case 0:
                // Wind
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "바라보는 방향으로 공격합니다.";
                        break;
                    case 1:
                        result = "투사체 수 1 증가";
                        break;
                    case 2:
                        result = "투사체 수 1 증가, 공격력 5 증가";
                        break;
                    case 3:
                        result = "투사체 수 1 증가";
                        break;
                    case 4:
                        result = "관통 1 증가";
                        break;
                    case 5:
                        result = "투사체 수 1 증가";
                        break;
                    case 6:
                        result = "투사체 수 1 증가, 공격력 5 증가";
                        break;
                    case 7:
                        result = "관통 1 증가";
                        break;
                }
                break;
            case 1:
                // Arrow
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "가장 가까운 적을 공격합니다.";
                        break;
                    case 1:
                        result = "투사체 수 1 증가";
                        break;
                    case 2:
                        result = "쿨타임 0.2초 감소";
                        break;
                    case 3:
                        result = "투사체 수 1 증가";
                        break;
                    case 4:
                        result = "공격력 10 증가";
                        break;
                    case 5:
                        result = "투사체 수 1 증가";
                        break;
                    case 6:
                        result = "관통 1 증가";
                        break;
                    case 7:
                        result = "공격력 10 증가";
                        break;
                }
                break;
            case 2:
                switch (weaponLevels[number])
                {
                    // Thunder
                    case 0:
                        result = "무작위 적에게 번개를 내려칩니다.";
                        break;
                    case 1:
                        result = "투사체 수 1 증가";
                        break;
                    case 2:
                        result = "공격력 10 증가";
                        break;
                    case 3:
                        result = "투사체 수 1 증가";
                        break;
                    case 4:
                        result = "공격력 20 증가";
                        break;
                    case 5:
                        result = "쿨타임 0.5초 감소";
                        break;
                    case 6:
                        result = "공격력 10 증가";
                        break;
                    case 7:
                        result = "투사체 수 1 증가";
                        break;
                }
                break;
            case 3:
                // Spike
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "주변을 회전하며 공격합니다.";
                        break;
                    case 1:
                        result = "투사체 수 1 증가";
                        break;
                    case 2:
                        result = "투사체 속도 30% 증가";
                        break;
                    case 3:
                        result = "쿨타임 0.5초 감소, 공격력 10 증가";
                        break;
                    case 4:
                        result = "투사체 수 1 증가";
                        break;
                    case 5:
                        result = "투사체 속도 30% 증가";
                        break;
                    case 6:
                        result = "쿨타임 0.5초 감소, 공격력 10 증가";
                        break;
                    case 7:
                        result = "투사체 수 1 증가";
                        break;
                }
                break;
            case 4:
                // Fire
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "가장 가까운 적에게 발사되며 큰 피해를 줍니다.";
                        break;
                    case 1:
                        result = "공격력 10 증가";
                        break;
                    case 2:
                        result = "공격력 10 증가, 투사체 속도 20% 증가";
                        break;
                    case 3:
                        result = "공격력 10 증가";
                        break;
                    case 4:
                        result = "공격력 10 증가, 투사체 속도 20% 증가";
                        break;
                    case 5:
                        result = "공격력 10 증가";
                        break;
                    case 6:
                        result = "공격력 10 증가, 투사체 속도 20% 증가";
                        break;
                    case 7:
                        result = "공격력 10 증가";
                        break;
                }
                break;
            case 5:
                // Knife
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "무작위 방향으로 공격합니다.";
                        break;
                    case 1:
                        result = "투사체 수 1 증가";
                        break;
                    case 2:
                        result = "공격력 5 증가";
                        break;
                    case 3:
                        result = "투사체 수 1 증가";
                        break;
                    case 4:
                        result = "투사체 수 1 증가";
                        break;
                    case 5:
                        result = "공격력 5 증가";
                        break;
                    case 6:
                        result = "투사체 수 1 증가";
                        break;
                    case 7:
                        result = "투사체 수 1 증가";
                        break;
                }
                break;
            case 6:
                // Kunai
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "가장 가까운 적에게 부채꼴 모양으로 공격합니다.";
                        break;
                    case 1:
                        result = "투사체 수 1 증가";
                        break;
                    case 2:
                        result = "공격력 5 증가";
                        break;
                    case 3:
                        result = "투사체 수 1 증가";
                        break;
                    case 4:
                        result = "공격력 5 증가";
                        break;
                    case 5:
                        result = "투사체 수 1 증가";
                        break;
                    case 6:
                        result = "공격력 5 증가";
                        break;
                    case 7:
                        result = "투사체 수 1 증가";
                        break;
                }
                break;
            case 7:
                // Star
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "적을 관통하며 튕겨져 나옵니다.";
                        break;
                    case 1:
                        result = "공격력 5 증가, 투사체 속도 20% 증가";
                        break;
                    case 2:
                        result = "공격력 5 증가";
                        break;
                    case 3:
                        result = "투사체 수 1 증가";
                        break;
                    case 4:
                        result = "공격력 5 증가, 투사체 속도 20% 증가";
                        break;
                    case 5:
                        result = "공격력 5 증가";
                        break;
                    case 6:
                        result = "투사체 수 1 증가";
                        break;
                    case 7:
                        result = "쿨타임 0.5초 감소";
                        break;
                }
                break;
        }
        return result;
    }

    private void Upgrade(int number)
    {
        switch (number)
        {
            case 0:
                // Wind
                switch (weaponLevels[number])
                {
                    case 0:
                        //바라보는 방향으로 공격합니다.
                        StartCoroutine(weaponManager.Weapon0());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[0].amount += 1;
                        break;
                    case 2:
                        //투사체 수 1 증가, 공격력 5 증가
                        weaponManager.weaponStatsArray[0].amount += 1;
                        weaponManager.weaponStatsArray[0].attack += 5;
                        break;
                    case 3:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[0].amount += 1;
                        break;
                    case 4:
                        //관통 1 증가
                        weaponManager.weaponStatsArray[0].penetration += 1;
                        break;
                    case 5:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[0].amount += 1;
                        break;
                    case 6:
                        //투사체 수 1 증가, 공격력 5 증가
                        weaponManager.weaponStatsArray[0].amount += 1;
                        weaponManager.weaponStatsArray[0].attack += 5;
                        break;
                    case 7:
                        //관통 1 증가
                        weaponManager.weaponStatsArray[0].penetration += 1;
                        break;
                }
                break;
            case 1:
                // Arrow
                switch (weaponLevels[number])
                {
                    case 0:
                        //가장 가까운 적을 공격합니다.
                        StartCoroutine(weaponManager.Weapon1());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[1].amount += 1;
                        break;
                    case 2:
                        //쿨타임 0.2초 감소
                        weaponManager.weaponStatsArray[1].cooldown -= 0.2f;
                        break;
                    case 3:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[1].amount += 1;
                        break;
                    case 4:
                        //공격력 10 증가"
                        weaponManager.weaponStatsArray[1].attack += 10;
                        break;
                    case 5:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[1].amount += 1;
                        break;
                    case 6:
                        //관통 1 증가
                        weaponManager.weaponStatsArray[1].penetration += 1;
                        break;
                    case 7:
                        //공격력 10 증가"
                        weaponManager.weaponStatsArray[1].attack += 10;
                        break;
                }
                break;
            case 2:
                switch (weaponLevels[number])
                {
                    // Thunder
                    case 0:
                        //무작위 적에게 번개를 내려칩니다.";
                        StartCoroutine(weaponManager.Weapon2());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[2].amount += 1;
                        break;
                    case 2:
                        //공격력 10 증가
                        weaponManager.weaponStatsArray[2].attack += 10;
                        break;
                    case 3:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[2].amount += 1;
                        break;
                    case 4:
                        //공격력 20 증가
                        weaponManager.weaponStatsArray[2].attack += 20;
                        break;
                    case 5:
                        //쿨타임 0.5초 감소
                        weaponManager.weaponStatsArray[2].cooldown -= 0.5f;
                        break;
                    case 6:
                        //공격력 10 증가
                        weaponManager.weaponStatsArray[2].attack += 10;
                        break;
                    case 7:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[2].amount += 1;
                        break;
                }
                break;
            case 3:
                // Spike
                switch (weaponLevels[number])
                {
                    case 0:
                        //주변을 회전하며 공격합니다
                        StartCoroutine(weaponManager.Weapon3());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[3].amount += 1;
                        break;
                    case 2:
                        //투사체 속도 30% 증가
                        weaponManager.weaponStatsArray[3].speed += 60f;
                        break;
                    case 3:
                        //쿨타임 0.5초 감소, 공격력 10 증가
                        weaponManager.weaponStatsArray[3].cooldown -= 0.5f;
                        weaponManager.weaponStatsArray[3].attack += 10;
                        break;
                    case 4:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[3].amount += 1;
                        break;
                    case 5:
                        //투사체 속도 30% 증가
                        weaponManager.weaponStatsArray[3].speed += 60f;
                        break;
                    case 6:
                        //쿨타임 0.5초 감소, 공격력 10 증가
                        weaponManager.weaponStatsArray[3].cooldown -= 0.5f;
                        weaponManager.weaponStatsArray[3].attack += 10;
                        break;
                    case 7:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[3].amount += 1;
                        break;
                }
                break;
            case 4:
                // Fire
                switch (weaponLevels[number])
                {
                    case 0:
                        //가장 가까운 적에게 발사되며 큰 피해를 줍니다
                        StartCoroutine(weaponManager.Weapon4());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //공격력 10 증가
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                    case 2:
                        //공격력 10 증가, 투사체 속도 20% 증가
                        weaponManager.weaponStatsArray[4].attack += 10;
                        weaponManager.weaponStatsArray[4].speed += 20;
                        break;
                    case 3:
                        //공격력 10 증가
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                    case 4:
                        //공격력 10 증가, 투사체 속도 20% 증가
                        weaponManager.weaponStatsArray[4].attack += 10;
                        weaponManager.weaponStatsArray[4].speed += 20;
                        break;
                    case 5:
                        //공격력 10 증가
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                    case 6:
                        //공격력 10 증가, 투사체 속도 20% 증가
                        weaponManager.weaponStatsArray[4].attack += 10;
                        weaponManager.weaponStatsArray[4].speed += 20;
                        break;
                    case 7:
                        //공격력 10 증가
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                }
                break;
            case 5:
                // Knife
                switch (weaponLevels[number])
                {
                    case 0:
                        //무작위 방향으로 공격합니다
                        StartCoroutine(weaponManager.Weapon5());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 2:
                        //공격력 5 증가
                        weaponManager.weaponStatsArray[5].attack += 5;
                        break;
                    case 3:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 4:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 5:
                        //공격력 5 증가
                        weaponManager.weaponStatsArray[5].attack += 5;
                        break;
                    case 6:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 7:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                }
                break;
            case 6:
                // Kunai
                switch (weaponLevels[number])
                {
                    case 0:
                        //가장 가까운 적에게 부채꼴 모양으로 공격합니다
                        StartCoroutine(weaponManager.Weapon6());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                    case 2:
                        //공격력 5 증가
                        weaponManager.weaponStatsArray[6].attack += 5;
                        break;
                    case 3:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                    case 4:
                        //공격력 5 증가
                        weaponManager.weaponStatsArray[6].attack += 5;
                        break;
                    case 5:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                    case 6:
                        //공격력 5 증가
                        weaponManager.weaponStatsArray[6].attack += 5;
                        break;
                    case 7:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                }
                break;
            case 7:
                // Star
                switch (weaponLevels[number])
                {
                    case 0:
                        //적을 관통하며 튕겨져 나옵니다
                        StartCoroutine(weaponManager.Weapon7());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //공격력 5 증가, 투사체 속도 20% 증가
                        weaponManager.weaponStatsArray[7].attack += 5;
                        weaponManager.weaponStatsArray[7].speed += 100;
                        break;
                    case 2:
                        //공격력 5 증가
                        weaponManager.weaponStatsArray[7].attack += 5;
                        break;
                    case 3:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[7].amount += 1;
                        break;
                    case 4:
                        //공격력 5 증가, 투사체 속도 20% 증가
                        weaponManager.weaponStatsArray[7].attack += 5;
                        weaponManager.weaponStatsArray[7].speed += 100;
                        break;
                    case 5:
                        //공격력 5 증가
                        weaponManager.weaponStatsArray[7].attack += 5;
                        break;
                    case 6:
                        //투사체 수 1 증가
                        weaponManager.weaponStatsArray[7].amount += 1;
                        break;
                    case 7:
                        //쿨타임 0.5초 감소
                        weaponManager.weaponStatsArray[7].cooldown -= 0.5f;
                        break;
                }
                break;
        }

        //무기 아이콘 레벨 갱신
        SetEpuipText(number);

        //스크립트 무기 레벨 증가
        weaponLevels[number]++;
    }

    private void SetEquipIcon(int number)
    {
        if (currentWeapons.Count >= 3)
        {
            return;
        }

        Image image = equipedWeapons[currentWeapons.Count].GetComponentsInChildren<Image>()[1];
        image.color = Vector4.one;
        image.sprite = icons[number];

        var level = equipedWeapons[currentWeapons.Count].GetComponentInChildren<TextMeshProUGUI>();
        level.text = LevelText(number);

        currentWeapons.Add(number);
        newWeapons.Remove(number);
    }

    private void SetEpuipText(int number)
    {
        var level = equipedWeapons[currentWeapons.FindIndex(x => x == number)].GetComponentInChildren<TextMeshProUGUI>();
        level.text = LevelText(number);
    }

    public void Button(int buttonIndex)
    {
        Upgrade(buttonInput[buttonIndex]);
        levelUpFlag = false;
        upgradeScreen.SetActive(false);
        GameManager.instance.TimeContinue();
    }

    public void Skip()
    {
        upgradeScreen.SetActive(false);
        GameManager.instance.TimeContinue();
    }
}
