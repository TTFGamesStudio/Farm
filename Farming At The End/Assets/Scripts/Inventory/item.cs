using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "farm/item", fileName = "item" , order = 1)]
public class item : ScriptableObject
{
   public int _id;
   public string _name;
   public Texture2D _sprite;
   public bool _stackable;
   public int _maxStack;
   public string _description;
}
