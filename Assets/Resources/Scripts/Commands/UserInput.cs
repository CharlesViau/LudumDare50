using General;
using UnityEngine;

namespace Commands
{
    public class UserInput : IUpdatable
    {
        private readonly Player _player;

        public UserInput(Player player)
        {
            _player = player;
        }

        private const string Interact = "Fire1";
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

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
            if (new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical)) is var v3 && v3 != Vector3.zero)
            {
                ICommand storedCommand = new MoveCommand(_player, v3);
                storedCommand.Execute();
            }
        }
    }
}