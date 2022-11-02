using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject deathScreen;
    [SerializeField] int Hp = 100;
    [SerializeField] int Mind = 100;
    [SerializeField] double Damage = 20;
    [SerializeField] int Defence = 0;
    [SerializeField] int Hungry = 0;
    [SerializeField] bool isBleeding = false;
    [SerializeField] GameObject torch;
    public bool torchOnOff = false;
    int MaxHp = 100;
    int MaxMind = 100;
    string name = "";
    public float timer;
    public bool ispuse;
    public bool guipuse;

    void Start()
    {
        InvokeRepeating("Hungering", 0, 45);
        InvokeRepeating("Bleeding", 0, 7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Hungering()
    {
        Hungry++;
        if (Hungry >= 100)
        {
            Hp = 0;
            CheckDeath();
        }
        else if (Hungry >= 75)
        {

        }
        else if (Hungry >= 50)
        {

        }
        else if (Hungry >= 30)
        {

        }
        else
        {

        }
    }

    private void Bleeding()
    {
        if (isBleeding)
        {
            Hp--;
            CheckDeath();
        }
    }

    public void TakeDamageNoDefence(int hp)
    {
        Hp -= hp;
        CheckDeath();
    }

    public void TakeDamageSimpleDefence(int hp)
    {
        int deal;
        deal = hp - Defence;
        if (deal < 0)
        {
            deal = 0;
        }
        Hp -= deal;
        CheckDeath();
    }

    public void Heal(int hp)
    {
        Hp += hp;
        if (Hp > MaxHp)
        {
            Hp = MaxHp;
        }
    }

    public void TakeAFood(int amount)
    {
        Hungry -= amount;
        if (Hungry < 0)
        {
            Hungry = 0;
        }
    }

    public void LostMind(int amount)
    {
        Mind -= amount;
    }

    public void HealMind(int amount)
    {
        Mind += amount;
        if (Mind > MaxMind)
        {
            Mind = MaxMind;
        }
    }

    public void CheckDeath()
    {
        if (Hp < 0)
        {
            Debug.Log("Death");
            timer = 0;
            Time.timeScale = timer;
            deathScreen.SetActive(true);
        }
    }

    public void SetDefence(int amount)
    {
        Defence = amount;
    }

    public void SetDamage(int amount)
    {
        Damage = amount;
    }

    public double GetDamage()
    {
        return Damage;
    }

    public int GetMind()
    {
        return Mind;
    }

    public void SetBleeding(bool Is)
    {
        isBleeding = Is;
    }

    public void TorchOn()
    {
        torchOnOff = true;
    }

    public void TorchOff()
    {
        torchOnOff = false;
    }

    public void FireTorch()
    {
        StartCoroutine(TorchFiring(120f));
    }

    public int GetHp()
    {
        return Hp;
    }

    public int GetHunger()
    {
        return Hungry;
    }

    private IEnumerator TorchFiring(float value)
    {
        torchOnOff = true;
        torch.SetActive(true);
        yield return new WaitForSeconds(value);
        torch.SetActive(false);
        torchOnOff = false;
    }
}
