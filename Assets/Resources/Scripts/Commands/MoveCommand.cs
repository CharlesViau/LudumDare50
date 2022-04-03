using UnityEngine;

namespace Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Player _player;
        private readonly Vector3 _v3;
        public MoveCommand(Player player, Vector3 v3)
        {
            _player = player;
            _v3 = v3;
        }
        public void Execute()
        {
            _player.Move(_v3);
        }
    }
}