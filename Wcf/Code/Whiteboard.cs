using System;
using System.Collections.Generic;

namespace Wcf.Code
{
    public sealed class Whiteboard
    {
        private static string _editedBy;

        private static readonly List<int> Items = new List<int> {1, 2, 3}; 

        public IEnumerable<int> GetItems()
        {
            return Items;
        }

        public void EndEdit(string userName)
        {
            if (string.IsNullOrEmpty(_editedBy) || _editedBy == userName)
            {
                _editedBy = null;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Add(int item, string userName)
        {
            if (string.IsNullOrEmpty(_editedBy) || _editedBy == userName)
            {
                _editedBy = userName;
                Items.Add(item);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}