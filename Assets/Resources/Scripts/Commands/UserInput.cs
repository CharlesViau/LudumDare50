using General;
using UnityEngine;

namespace Commands
{
    public class UserInput : IUpdatable
    {
        private readonly Player _player;
        //public CommandManager CommandManager;

        public UserInput(Player player)
        {
            _player = player;
            //CommandManager = new CommandManager();
        }

        private const string Interact = "Fire1";
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        public void Init()
        {
            //CommandManager.Init();
        }

        public void PostInit()
        {
            //CommandManager.PostInit();
        }

        public void Refresh()
        {
            if (Input.GetButtonDown(Interact))
            {
                ICommand storedCommand = new InteractCommand(_player);
                storedCommand.Execute();
                //CommandManager.Add(storedCommand);

            }
            
            //CommandManager.Refresh();
        }

        public void FixedRefresh()
        {
            if (new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical)) is var v3 && v3 != Vector3.zero)
            {
                ICommand storedCommand = new MoveCommand(_player, v3);
                storedCommand.Execute();
                //CommandManager.Add(storedCommand);
            }
            
            //CommandManager.FixedRefresh();
        }

        public void LateRefresh()
        {
           //CommandManager.LateRefresh(); 
        }
    }
}