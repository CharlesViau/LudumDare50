using General;
using Managers;
using UnityEngine;

namespace Commands
{
    public class UserInput : IUpdatable
    {
        private readonly Player _player;

        public UserInput(Player player)
        {
            this._player = player;
        }

        private const string Interact = "Fire1";

        public void Init()
        {
        }

        public void PostInit()
        {
        }

        public void Refresh()
        {
            if (Input.GetKeyDown(Interact))
            {
                ICommand storedCommand = new InteractCommand(_player);
                storedCommand.Execute();
            }
        }

        public void FixedRefresh()
        {
            throw new System.NotImplementedException();
        }
    }
}