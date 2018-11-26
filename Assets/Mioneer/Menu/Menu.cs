using UnityEngine;
using System.Collections.Generic;

public class Menu : IUpdatable
{
    private List<MenuObject> _menuObjects;
    private List<IUpdatable> _updatableMenuObjects;

    public Menu()
    {
        _menuObjects = new List<MenuObject>();
        _updatableMenuObjects = new List<IUpdatable>();
    }

    public void Update(float deltaTime)
    {
        for (int index = 0; index < _updatableMenuObjects.Count; index++)
            _updatableMenuObjects[index].Update(deltaTime);
    }

    public void AddMenuObject(MenuObject menuObject)
    {
        menuObject.OnActive(this);
        _menuObjects.Add(menuObject);
    }

    public void RemoveMenuObject(MenuObject menuObject)
    {
        int index = _menuObjects.IndexOf(menuObject);

        if (index < 0)
        {
            Debug.LogWarning("Tried to remove invalid MenuObject");
            return;
        }

        menuObject.OnDeactive();
        menuObject.HandleRemoveSubMenuObject();

        _menuObjects.RemoveAt(index);
    }

    public void HandleAddMenuObject(MenuObject menuObject)
    {
        IUpdatable updatable = menuObject as IUpdatable;

        if (updatable != null)
            _updatableMenuObjects.Add(updatable);
    }

    public void HandleRemoveMenuObject(MenuObject menuObject)
    {
        IUpdatable updatable = menuObject as IUpdatable;

        if (updatable != null)
            _updatableMenuObjects.Remove(updatable);
    }
}