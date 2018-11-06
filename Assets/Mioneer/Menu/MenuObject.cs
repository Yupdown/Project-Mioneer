using UnityEngine;
using System.Collections.Generic;

public class MenuObject
{
    private Menu _menu;

    private MenuObject _owner;
    private List<MenuObject> _subMenuObjects;

    protected FContainer _container;

    public bool activated
    {
        get
        { return _menu != null; }
    }

    public MenuObject()
    {
        _subMenuObjects = new List<MenuObject>();

        _container = new FContainer();
    }

    public virtual void OnActive(Menu menu)
    {
        _menu = menu;

        _menu.HandleAddMenuObject(this);

        for (int index = 0; index < _subMenuObjects.Count; index++)
            _subMenuObjects[index].OnActive(menu);
    }

    public virtual void OnDeactive()
    {
        _menu.HandleRemoveMenuObject(this);

        _menu = null;

        for (int index = 0; index < _subMenuObjects.Count; index++)
            _subMenuObjects[index].OnDeactive();
    }

    public void AddSubMenuObject(MenuObject subMenuObject)
    {
        if (activated)
            subMenuObject.OnActive(_menu);

        subMenuObject.HandleAddSubMenuObject(this);
        _container.AddChild(subMenuObject._container);

        _subMenuObjects.Add(subMenuObject);
    }

    public void HandleAddSubMenuObject(MenuObject owner)
    {
        _owner = owner;
    }

    public void RemoveSubMenuObject(MenuObject subMenuObject)
    {
        int index = _subMenuObjects.IndexOf(subMenuObject);

        if (index < 0)
        {
            Debug.LogWarning("Tried to remove invalid subMenuObject");
            return;
        }

        if (activated)
            subMenuObject.OnDeactive();

        subMenuObject.HandleRemoveSubMenuObject();
        _container.RemoveChild(subMenuObject._container);

        _subMenuObjects.RemoveAt(index);
    }

    public void HandleRemoveSubMenuObject()
    {
        _owner = null;
    }

    public void RemoveFromOwner()
    {
        _owner.RemoveSubMenuObject(this);
    }
}