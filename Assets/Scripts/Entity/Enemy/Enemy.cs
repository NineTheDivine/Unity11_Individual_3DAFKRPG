using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class ItemDrop
{
    public Item item;
    public float dropRate;
}

public class Enemy : Entity
{
    [Header("EnemyDrop")]
    [SerializeField] int dropGold;
    public int DropGold { get { 
            return (int)(dropGold * (1.0f + ((buffManager.CurrentBuff.TryGetValue(BuffType.Gold, out float value)) ? value : 0.0f))); 
        } }
    [SerializeField] int dropExp;
    public int DropExp { get {
            return (int)(dropExp * (1.0f + ((buffManager.CurrentBuff.TryGetValue(BuffType.Exp, out float value)) ? value : 0.0f)));
        } }
    [SerializeField] List<ItemDrop> DropPool = new List<ItemDrop>();

    private void Awake()
    {
        GameManager.Instance.battleManager.enemy = this;
    }

    protected override void OnDead()
    {
        isDead = true;
        Debug.Log("Enemy is Dead");
        entityAnimator.OnDeadApplied();
        GameManager.Instance.battleManager.EndStage(true);
    }

    public List<Item> MakeItemDrops()
    {
        List<Item> itemDropList = new List<Item>();
        for (int i = 0; i < DropPool.Count; i++)
        {
            float randomValue = Random.Range(0.0f, 1.0f);
            if (randomValue <= DropPool[i].dropRate)
                itemDropList.Add(DropPool[i].item);
        }
        return itemDropList;


    }

    public void OnResetStage()
    {
        entityAnimator.OnReset();
        health.Init();
        isDead = false;
        GetComponent<EnemyAI>().Init();
    }
}
