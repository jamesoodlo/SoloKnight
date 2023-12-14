using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Barrier : MonoBehaviour
{
    public PlayerInfo info;
    public Button btn;
    [SerializeField] private bool canUse;
    public bool isUsed;
    public float reduceDamage;
    public Shield[] shields;
    public float skillTime = 0;
    public float maxSkillTime;
    public float cooldown;
    public float maxCooldown;

    [Header("Text")]
    public GameObject status;
    public TextMeshProUGUI skillTimeText;
    public TextMeshProUGUI cooldownText;
    void Awake()
    {
        shields = GetComponentsInChildren<Shield>();
    }

    void Start()
    {
        maxSkillTime = info.barrierSkillTime;

        cooldown = maxCooldown;
        skillTime = maxSkillTime;

        reduceDamage = info.reduceDamage;
    }

    void Update()
    {
        CooldownSkill();

        for (int i = 0; i < shields.Length; i++)
        {
            shields[i].gameObject.SetActive(isUsed);
        }

        btn.interactable = canUse;
    }

    public void ActiveSkill()
    {
        if (canUse) isUsed = true;
    }

    public void CooldownSkill()
    {
        status.SetActive(isUsed);

        if (isUsed)
        {
            canUse = false;
            skillTime -= Time.deltaTime;
            skillTimeText.text = skillTime.ToString("F0");
        }

        if (skillTime <= 0)
        {
            skillTime = 0;
            isUsed = false;
        }

        if (cooldown <= 0)
        {
            cooldown = maxCooldown;
            canUse = true;
        }

        if (canUse)
        {
            skillTime = maxSkillTime;
            cooldownText.gameObject.SetActive(false);
        }
        else
        {
            cooldown -= Time.deltaTime;
            cooldownText.gameObject.SetActive(true);
            cooldownText.text = cooldown.ToString("F0");
        }
    }
}
