using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Commands
{
    public class CommandManager
    {
        private Stack<ICommand> _commandBuffer;

        private void Awake()
        {
            _commandBuffer = new Stack<ICommand>();
        }

        public static void Execute(ICommand command)
        {
            command.Execute();
        }

        
        
    }
}