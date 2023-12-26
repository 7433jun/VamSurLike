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
                        result = "�ٶ󺸴� �������� �����մϴ�.";
                        break;
                    case 1:
                        result = "����ü �� 1 ����";
                        break;
                    case 2:
                        result = "����ü �� 1 ����, ���ݷ� 5 ����";
                        break;
                    case 3:
                        result = "����ü �� 1 ����";
                        break;
                    case 4:
                        result = "���� 1 ����";
                        break;
                    case 5:
                        result = "����ü �� 1 ����";
                        break;
                    case 6:
                        result = "����ü �� 1 ����, ���ݷ� 5 ����";
                        break;
                    case 7:
                        result = "���� 1 ����";
                        break;
                }
                break;
            case 1:
                // Arrow
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "���� ����� ���� �����մϴ�.";
                        break;
                    case 1:
                        result = "����ü �� 1 ����";
                        break;
                    case 2:
                        result = "��Ÿ�� 0.2�� ����";
                        break;
                    case 3:
                        result = "����ü �� 1 ����";
                        break;
                    case 4:
                        result = "���ݷ� 10 ����";
                        break;
                    case 5:
                        result = "����ü �� 1 ����";
                        break;
                    case 6:
                        result = "���� 1 ����";
                        break;
                    case 7:
                        result = "���ݷ� 10 ����";
                        break;
                }
                break;
            case 2:
                switch (weaponLevels[number])
                {
                    // Thunder
                    case 0:
                        result = "������ ������ ������ ����Ĩ�ϴ�.";
                        break;
                    case 1:
                        result = "����ü �� 1 ����";
                        break;
                    case 2:
                        result = "���ݷ� 10 ����";
                        break;
                    case 3:
                        result = "����ü �� 1 ����";
                        break;
                    case 4:
                        result = "���ݷ� 20 ����";
                        break;
                    case 5:
                        result = "��Ÿ�� 0.5�� ����";
                        break;
                    case 6:
                        result = "���ݷ� 10 ����";
                        break;
                    case 7:
                        result = "����ü �� 1 ����";
                        break;
                }
                break;
            case 3:
                // Spike
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "�ֺ��� ȸ���ϸ� �����մϴ�.";
                        break;
                    case 1:
                        result = "����ü �� 1 ����";
                        break;
                    case 2:
                        result = "����ü �ӵ� 30% ����";
                        break;
                    case 3:
                        result = "��Ÿ�� 0.5�� ����, ���ݷ� 10 ����";
                        break;
                    case 4:
                        result = "����ü �� 1 ����";
                        break;
                    case 5:
                        result = "����ü �ӵ� 30% ����";
                        break;
                    case 6:
                        result = "��Ÿ�� 0.5�� ����, ���ݷ� 10 ����";
                        break;
                    case 7:
                        result = "����ü �� 1 ����";
                        break;
                }
                break;
            case 4:
                // Fire
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "���� ����� ������ �߻�Ǹ� ū ���ظ� �ݴϴ�.";
                        break;
                    case 1:
                        result = "���ݷ� 10 ����";
                        break;
                    case 2:
                        result = "���ݷ� 10 ����, ����ü �ӵ� 20% ����";
                        break;
                    case 3:
                        result = "���ݷ� 10 ����";
                        break;
                    case 4:
                        result = "���ݷ� 10 ����, ����ü �ӵ� 20% ����";
                        break;
                    case 5:
                        result = "���ݷ� 10 ����";
                        break;
                    case 6:
                        result = "���ݷ� 10 ����, ����ü �ӵ� 20% ����";
                        break;
                    case 7:
                        result = "���ݷ� 10 ����";
                        break;
                }
                break;
            case 5:
                // Knife
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "������ �������� �����մϴ�.";
                        break;
                    case 1:
                        result = "����ü �� 1 ����";
                        break;
                    case 2:
                        result = "���ݷ� 5 ����";
                        break;
                    case 3:
                        result = "����ü �� 1 ����";
                        break;
                    case 4:
                        result = "����ü �� 1 ����";
                        break;
                    case 5:
                        result = "���ݷ� 5 ����";
                        break;
                    case 6:
                        result = "����ü �� 1 ����";
                        break;
                    case 7:
                        result = "����ü �� 1 ����";
                        break;
                }
                break;
            case 6:
                // Kunai
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "���� ����� ������ ��ä�� ������� �����մϴ�.";
                        break;
                    case 1:
                        result = "����ü �� 1 ����";
                        break;
                    case 2:
                        result = "���ݷ� 5 ����";
                        break;
                    case 3:
                        result = "����ü �� 1 ����";
                        break;
                    case 4:
                        result = "���ݷ� 5 ����";
                        break;
                    case 5:
                        result = "����ü �� 1 ����";
                        break;
                    case 6:
                        result = "���ݷ� 5 ����";
                        break;
                    case 7:
                        result = "����ü �� 1 ����";
                        break;
                }
                break;
            case 7:
                // Star
                switch (weaponLevels[number])
                {
                    case 0:
                        result = "���� �����ϸ� ƨ���� ���ɴϴ�.";
                        break;
                    case 1:
                        result = "���ݷ� 5 ����, ����ü �ӵ� 20% ����";
                        break;
                    case 2:
                        result = "���ݷ� 5 ����";
                        break;
                    case 3:
                        result = "����ü �� 1 ����";
                        break;
                    case 4:
                        result = "���ݷ� 5 ����, ����ü �ӵ� 20% ����";
                        break;
                    case 5:
                        result = "���ݷ� 5 ����";
                        break;
                    case 6:
                        result = "����ü �� 1 ����";
                        break;
                    case 7:
                        result = "��Ÿ�� 0.5�� ����";
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
                        //�ٶ󺸴� �������� �����մϴ�.
                        StartCoroutine(weaponManager.Weapon0());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[0].amount += 1;
                        break;
                    case 2:
                        //����ü �� 1 ����, ���ݷ� 5 ����
                        weaponManager.weaponStatsArray[0].amount += 1;
                        weaponManager.weaponStatsArray[0].attack += 5;
                        break;
                    case 3:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[0].amount += 1;
                        break;
                    case 4:
                        //���� 1 ����
                        weaponManager.weaponStatsArray[0].penetration += 1;
                        break;
                    case 5:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[0].amount += 1;
                        break;
                    case 6:
                        //����ü �� 1 ����, ���ݷ� 5 ����
                        weaponManager.weaponStatsArray[0].amount += 1;
                        weaponManager.weaponStatsArray[0].attack += 5;
                        break;
                    case 7:
                        //���� 1 ����
                        weaponManager.weaponStatsArray[0].penetration += 1;
                        break;
                }
                break;
            case 1:
                // Arrow
                switch (weaponLevels[number])
                {
                    case 0:
                        //���� ����� ���� �����մϴ�.
                        StartCoroutine(weaponManager.Weapon1());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[1].amount += 1;
                        break;
                    case 2:
                        //��Ÿ�� 0.2�� ����
                        weaponManager.weaponStatsArray[1].cooldown -= 0.2f;
                        break;
                    case 3:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[1].amount += 1;
                        break;
                    case 4:
                        //���ݷ� 10 ����"
                        weaponManager.weaponStatsArray[1].attack += 10;
                        break;
                    case 5:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[1].amount += 1;
                        break;
                    case 6:
                        //���� 1 ����
                        weaponManager.weaponStatsArray[1].penetration += 1;
                        break;
                    case 7:
                        //���ݷ� 10 ����"
                        weaponManager.weaponStatsArray[1].attack += 10;
                        break;
                }
                break;
            case 2:
                switch (weaponLevels[number])
                {
                    // Thunder
                    case 0:
                        //������ ������ ������ ����Ĩ�ϴ�.";
                        StartCoroutine(weaponManager.Weapon2());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[2].amount += 1;
                        break;
                    case 2:
                        //���ݷ� 10 ����
                        weaponManager.weaponStatsArray[2].attack += 10;
                        break;
                    case 3:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[2].amount += 1;
                        break;
                    case 4:
                        //���ݷ� 20 ����
                        weaponManager.weaponStatsArray[2].attack += 20;
                        break;
                    case 5:
                        //��Ÿ�� 0.5�� ����
                        weaponManager.weaponStatsArray[2].cooldown -= 0.5f;
                        break;
                    case 6:
                        //���ݷ� 10 ����
                        weaponManager.weaponStatsArray[2].attack += 10;
                        break;
                    case 7:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[2].amount += 1;
                        break;
                }
                break;
            case 3:
                // Spike
                switch (weaponLevels[number])
                {
                    case 0:
                        //�ֺ��� ȸ���ϸ� �����մϴ�
                        StartCoroutine(weaponManager.Weapon3());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[3].amount += 1;
                        break;
                    case 2:
                        //����ü �ӵ� 30% ����
                        weaponManager.weaponStatsArray[3].speed += 60f;
                        break;
                    case 3:
                        //��Ÿ�� 0.5�� ����, ���ݷ� 10 ����
                        weaponManager.weaponStatsArray[3].cooldown -= 0.5f;
                        weaponManager.weaponStatsArray[3].attack += 10;
                        break;
                    case 4:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[3].amount += 1;
                        break;
                    case 5:
                        //����ü �ӵ� 30% ����
                        weaponManager.weaponStatsArray[3].speed += 60f;
                        break;
                    case 6:
                        //��Ÿ�� 0.5�� ����, ���ݷ� 10 ����
                        weaponManager.weaponStatsArray[3].cooldown -= 0.5f;
                        weaponManager.weaponStatsArray[3].attack += 10;
                        break;
                    case 7:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[3].amount += 1;
                        break;
                }
                break;
            case 4:
                // Fire
                switch (weaponLevels[number])
                {
                    case 0:
                        //���� ����� ������ �߻�Ǹ� ū ���ظ� �ݴϴ�
                        StartCoroutine(weaponManager.Weapon4());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //���ݷ� 10 ����
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                    case 2:
                        //���ݷ� 10 ����, ����ü �ӵ� 20% ����
                        weaponManager.weaponStatsArray[4].attack += 10;
                        weaponManager.weaponStatsArray[4].speed += 20;
                        break;
                    case 3:
                        //���ݷ� 10 ����
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                    case 4:
                        //���ݷ� 10 ����, ����ü �ӵ� 20% ����
                        weaponManager.weaponStatsArray[4].attack += 10;
                        weaponManager.weaponStatsArray[4].speed += 20;
                        break;
                    case 5:
                        //���ݷ� 10 ����
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                    case 6:
                        //���ݷ� 10 ����, ����ü �ӵ� 20% ����
                        weaponManager.weaponStatsArray[4].attack += 10;
                        weaponManager.weaponStatsArray[4].speed += 20;
                        break;
                    case 7:
                        //���ݷ� 10 ����
                        weaponManager.weaponStatsArray[4].attack += 10;
                        break;
                }
                break;
            case 5:
                // Knife
                switch (weaponLevels[number])
                {
                    case 0:
                        //������ �������� �����մϴ�
                        StartCoroutine(weaponManager.Weapon5());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 2:
                        //���ݷ� 5 ����
                        weaponManager.weaponStatsArray[5].attack += 5;
                        break;
                    case 3:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 4:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 5:
                        //���ݷ� 5 ����
                        weaponManager.weaponStatsArray[5].attack += 5;
                        break;
                    case 6:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                    case 7:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[5].amount += 1;
                        break;
                }
                break;
            case 6:
                // Kunai
                switch (weaponLevels[number])
                {
                    case 0:
                        //���� ����� ������ ��ä�� ������� �����մϴ�
                        StartCoroutine(weaponManager.Weapon6());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                    case 2:
                        //���ݷ� 5 ����
                        weaponManager.weaponStatsArray[6].attack += 5;
                        break;
                    case 3:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                    case 4:
                        //���ݷ� 5 ����
                        weaponManager.weaponStatsArray[6].attack += 5;
                        break;
                    case 5:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                    case 6:
                        //���ݷ� 5 ����
                        weaponManager.weaponStatsArray[6].attack += 5;
                        break;
                    case 7:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[6].amount += 1;
                        break;
                }
                break;
            case 7:
                // Star
                switch (weaponLevels[number])
                {
                    case 0:
                        //���� �����ϸ� ƨ���� ���ɴϴ�
                        StartCoroutine(weaponManager.Weapon7());
                        SetEquipIcon(number);
                        break;
                    case 1:
                        //���ݷ� 5 ����, ����ü �ӵ� 20% ����
                        weaponManager.weaponStatsArray[7].attack += 5;
                        weaponManager.weaponStatsArray[7].speed += 100;
                        break;
                    case 2:
                        //���ݷ� 5 ����
                        weaponManager.weaponStatsArray[7].attack += 5;
                        break;
                    case 3:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[7].amount += 1;
                        break;
                    case 4:
                        //���ݷ� 5 ����, ����ü �ӵ� 20% ����
                        weaponManager.weaponStatsArray[7].attack += 5;
                        weaponManager.weaponStatsArray[7].speed += 100;
                        break;
                    case 5:
                        //���ݷ� 5 ����
                        weaponManager.weaponStatsArray[7].attack += 5;
                        break;
                    case 6:
                        //����ü �� 1 ����
                        weaponManager.weaponStatsArray[7].amount += 1;
                        break;
                    case 7:
                        //��Ÿ�� 0.5�� ����
                        weaponManager.weaponStatsArray[7].cooldown -= 0.5f;
                        break;
                }
                break;
        }

        //���� ������ ���� ����
        SetEpuipText(number);

        //��ũ��Ʈ ���� ���� ����
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
