using System;
using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;
using YG;

namespace CaseSimulator.Gameplay.ClickerSystem
{
    public class Clicker : NewSouds
    {
        [SerializeField] private string _animatorBoolName = "OnClick";
        [SerializeField] private int _multiplier;

        private Animator _animator;

        private void Start()
        {
            _multiplier = YandexGame.savesData.Multipler;
        }

        public void AddMultipler(int toAdd)
        {
            _multiplier += toAdd;
            Save();
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Click()
        {
            _animator.SetBool(_animatorBoolName, true);
            Bank.AddMoney(_multiplier);
            PlaySound(0, random: true);
        }

        public void StopClickAnim()
        {
            _animator.SetBool(_animatorBoolName, false);
        }

        private void Save()
        {
            YandexGame.savesData.Multipler = _multiplier;
            YandexGame.SaveProgress();
        }
    }
}
