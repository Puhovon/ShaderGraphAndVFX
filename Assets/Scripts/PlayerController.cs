using System;
using System.IO;
using DefaultNamespace;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int level;
    [SerializeField] private int armor;
    [SerializeField] private int spellResis;

    private PlayerStats stats;
    private void Start()
    {
        var uniStats = Observable.Start(GetStats);
        Debug.Log(GetStats());

        Observable.WhenAll(uniStats).ObserveOnMainThread().Subscribe(xs =>
        {
            Debug.Log(xs.Length);
            Debug.Log(xs[0]);
            stats = JsonUtility.FromJson<PlayerStats>(xs[0]);
            Debug.Log(stats);
            health = stats.health;
            damage = stats.damage;
            level = stats.level;
            armor = stats.armor;
            spellResis = stats.spellResist;
        });
        
    }

    private string GetStats()
    {
        string jsonPath = "./Assets/Scripts/PlayerConfig.json";
        var json = File.ReadAllText(jsonPath);
        return json;
    }

}