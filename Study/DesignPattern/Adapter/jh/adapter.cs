using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Security.AccessControl;
using static System.Console;

namespace DotNetDesignPatternDemos.Structural.Adapter.NoCaching
{
    public class GoodsList
    {
        public List<Weapon> Weapons {get; set;}
        public List<Asset> Assets{get; set;}
    }
    public class UseInfo
    {
        public int NeedGoods { get; set; }
        public int NeedAmount { get; set; }
        public int Goods { get; set; }
    }
    public interface iGoodsAdapter<T>
    {
        virtual Dictionary<int, T> SpendGoods(Dictionary<int, T> spendGoodsList)
        {
            return null;
        }
    }

    public class WeaponAdapter : iGoodsAdapter<Weapon>
    {
        public Dictionary<int, Weapon> WeaponList { get; set; }
        public WeaponAdapter(Dictionary<int, Weapon> weapons)
        {
            WeaponList = weapons;
        }  
        public Dictionary<int, Weapon> SpendGoods(Dictionary<int, Weapon> spendGoodsList)
        {
            foreach (var spendGoods in spendGoodsList)
            {
                foreach (var weapon in WeaponList)
                {
                    if (weapon.Value.Index == spendGoods.Value.Index)
                    {
                        WeaponList.Remove(weapon.Key);
                    }
                }
            }

            return WeaponList;
        }
    }

    public class AssetAdapter : iGoodsAdapter<Asset>
    {
        public Dictionary<int, Asset> AssetList { get; set; }
        public AssetAdapter(Dictionary<int, Asset> assets)
        {
            AssetList = assets;
        }
        public Dictionary<int, Asset> SpendGoods(Dictionary<int, Asset> spendGoodsList)
        {
            foreach (var spendGoods in spendGoodsList)
            {
                foreach (var asset in AssetList)
                {
                    if (asset.Value.Index == spendGoods.Key)
                    {
                        if (asset.Value.Amount >= spendGoods.Value.Amount)
                        {
                            asset.Value.Amount -= spendGoods.Value.Amount;
                        }
                    }
                }
            }

            return AssetList;
        }
    }


    public class Weapon : Goods
    {

        public int Exp { get; set; }

        public bool IsLocked { get; set; }
    }
    public class Asset : Goods
    {
    }

    public class Goods
    {
        public int Index { get; set; }
        public DateTime Time { get; set; }
        public int Amount { get; set; }

    }

    public class Demo
    {
        private static readonly Dictionary<int, Asset> SpendAsset = new Dictionary<int, Asset>();
        private static readonly Dictionary<int, Weapon> SpendWeapons = new Dictionary<int, Weapon>();
        private static readonly Dictionary<int, Asset> Assets = new Dictionary<int, Asset>();
        private static readonly Dictionary<int, Weapon> Weapons = new Dictionary<int, Weapon>();
        // the interface we have

        static void Main()
        {

            for(int i=0; i<3; i++)
            {
                Weapon weapon = new Weapon();
                weapon.Index = i + 1;
                SpendWeapons.Add(i + 1, weapon);
            }

            for (int i = 0; i < 4; i++)
            {
                Weapon weapon = new Weapon();
                weapon.Index = i + 1;
                Weapons.Add(i + 1, weapon);
            }

            for (int i = 0; i < 4; i++)
            {
                Asset asset = new Asset();
                asset.Index = i + 5;
                Assets.Add(i + 1, asset);
            }

            for (int i = 0; i < 4; i++)
            {
                Asset asset = new Asset();
                asset.Index = i + 5;
                SpendAsset.Add(i + 1, asset);
            }

            new WeaponAdapter(Weapons).SpendGoods(SpendWeapons);
            new AssetAdapter(Assets).SpendGoods(SpendAsset);
        }

    }
}