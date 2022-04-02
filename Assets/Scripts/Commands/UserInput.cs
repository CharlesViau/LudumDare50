using General;
using Managers;
using UnityEngine;

namespace Commands
{
    public class UserInput : IUpdatable
    {
        private readonly Player _player;
        [SerializeField] public int speed;

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
            _player.rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 7)
            {
                _player.upStage();
            }
            else if (collision.gameObject.layer == 8) {
            _player.downStage();
            }
        }
    }
}