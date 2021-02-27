using CharacterCreatorMenu.Enums;
using CharacterCreatorMenu.Models.Operation;
using System.Collections.Generic;

namespace CharacterCreatorMenu.Models
{
    public class Operations
    {
        private readonly Dictionary<OperationType, BaseOperation> _operations;

        public Operations()
        {
            _operations = new Dictionary<OperationType, BaseOperation> {
                { OperationType.Add, new Add() },
                { OperationType.Subtract, new Subtract() }
            };
        }

        public BaseOperation GetOperation(OperationType type)
        {
            return _operations[type];
        }
    }
}
