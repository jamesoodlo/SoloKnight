using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerSlash : MonoBehaviour
{
    PlayerController playerController;
    public PlayerInfo info;
    public bool isActive;
    public GameObject bullet;
    public Button btn;
    [SerializeField] private Weapons[] weapons;
    [SerializeField] private bool canUse;
    [SerializeField] private bool isUsed;
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
        playerController = GetComponentInParent<PlayerController>();
    }
    void Start()
    {
        maxSkillTime = info.fireSkillTime;

        cooldown = maxCooldown;
        skillTime = maxSkillTime;
    }

    void Update()
    {
        weapons = FindObjectsOfType<Weapons>();

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].fireEnchant.SetActive(isUsed);
        }

        CooldownSkill();

        btn.interactable = canUse;
    }
    public void Shoot()
    {
        if (isUsed)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
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
