using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Heal : MonoBehaviour
{
    public PlayerInfo info;
    public float healRate;
    public GameObject healFx;
    public Button btn;
    [SerializeField] private bool canUse;
    public bool isUsed;
    public float skillTime = 0;
    public float maxSkillTime;
    public float cooldown;
    public float maxCooldown;

    [Header("Text")]
    public GameObject status;
    public TextMeshProUGUI skillTimeText;
    public TextMeshProUGUI cooldownText;
    void Start()
    {
        maxSkillTime = info.healSkillTime;
        
        cooldown = maxCooldown;
        skillTime = maxSkillTime;

        healRate = info.healRate;
    }

    // Update is called once per frame
    void Update()
    {
        healFx.SetActive(isUsed);

        CooldownSkill();

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
