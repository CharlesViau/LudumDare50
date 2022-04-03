using System;
using System.Collections.Generic;
using System.Linq;
using General;
using UnityEngine;

namespace Commands
{
    public class CommandManager : IUpdatable
    {
        private Stack<ICommand> _commandBuffer;

        public void Init()
        {
            _commandBuffer = new Stack<ICommand>();
        }

        public void PostInit()
        {
            
        }

        public void Refresh()
        {
            
        }

        public void FixedRefresh()
        {
            
        }

        public void LateRefresh()
        {
            foreach (var command in _commandBuffer)
            { 
                Execute(command);
            }
            _commandBuffer.Clear();
        }

        private static void Execute(ICommand command)
        {
            command.Execute();
        }

        public void Add(ICommand command)
        {
            _commandBuffer.Push(command);
        }
    }
}