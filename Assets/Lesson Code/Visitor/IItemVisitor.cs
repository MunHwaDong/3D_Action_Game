using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemVisitor
{
    void Visit(IItem item);
}

public interface IItem
{
    string Name { get; set; }
    
    void Accept(IItemVisitor visitor);
    
    //Visitor가 자신에게 영향을 줬는지 확인
    void ShowInfo();

    void SetItemName(string name);
}

public class SuwonVisitor : IItemVisitor
{
    public void Visit(IItem item)
    {
        if (item is WeaponItem)
        {
            item.SetItemName("Toy");
        }
    }
}

public class SeoulVisitor : IItemVisitor
{
    public void Visit(IItem item)
    {
        if (item is WeaponItem)
        {
            item.SetItemName("Sword");
        }
        if (item is AmorItem)
        {
            item.SetItemName("Coat");
        }
    }
}

//지역별로 아이템의 성질을 다르게 할 것
public class RegionInventory : MonoBehaviour
{
    private List<IItem> _items = new List<IItem>();
    private IItemVisitor _itemVisitor;

    private void Start()
    {
        _itemVisitor = new SuwonVisitor();
        
        AddItem(new AmorItem());
        AddItem(new WeaponItem());
        
        UpdateVisitorInfo();
    }
    
    public void AddItem(IItem item)
    {
        _items.Add(item);
    }

    public void UpdateVisitorInfo()
    {
        foreach (var item in _items)
        {
            item.Accept(_itemVisitor);
        }
    }

    public void ShowInfo()
    {
        foreach (var item in _items)
        {
            item.ShowInfo();
        }
    }
}

public class WeaponItem : IItem
{
    public string Name { get; set; }

    string IItem.Name
    {
        get => Name;
        set => Name = value;
    }

    public void Accept(IItemVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void ShowInfo()
    {
        Debug.Log(Name);
    }

    public void SetItemName(string name)
    {
        Name = name;
    }
}

public class AmorItem : IItem
{
    public string Name { get; set; }
    
    string IItem.Name
    {
        get => Name;
        set => Name = value;
    }

    public void Accept(IItemVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void ShowInfo()
    {
        Debug.Log(Name);
    }

    public void SetItemName(string name)
    {
        Name = name;
    }
}