using System;

namespace Objects.Iterator
{
    public class IterableLinkedList<T> : IIterator<T>
    {
        private Node<T> _headNode;
        private Node<T> _currentNode;
        public IterableLinkedList(T data)
        {
            _headNode = new Node<T>(data);
            _currentNode = _headNode;
        }

        public void Next()
        {
            _currentNode = _currentNode.NextNode;
        }

        public bool HasNext()
        {
            return _currentNode.HasNext();
        }

        public void Remove()
        {
            if (_currentNode.PreviousNode == null)
            {
                return;
            }
            _currentNode.PreviousNode.NextNode = _currentNode.NextNode;
            _currentNode = _currentNode.PreviousNode;
        }

        // should add at current push the current node to the added one?
        public void AddAtCurrent(T value)
        {
            _currentNode.AddNext(value, _currentNode);
            _currentNode = _currentNode.NextNode;
        }

        public void Add(T value, int index)
        {
            _currentNode = _headNode;
            for (var i = 0; _currentNode.HasNext(); i++)
            {
                if (i == index)
                {
                    _currentNode.AddNext(value, _currentNode);
                    break;
                }
                _currentNode = _currentNode.NextNode;
            }
        }

        public void SetAtCurrent(T value)
        {
            _currentNode.Data = value;
        }

        public void Set(T value, int index)
        {
            _currentNode = _headNode;
            for (var i = 0; _currentNode.HasNext(); i++)
            {
                if (i == index)
                {
                    _currentNode.Data = value;
                    break;
                }
                _currentNode = _currentNode.NextNode;
            }
        }

        public T GetCurrent()
        {
            return _currentNode.Data;
        }

        public T Get(int index)
        {
            _currentNode = _headNode;
            for (var i = 0; _currentNode.HasNext(); i++)
            {
                if (i == index)
                {
                    return _currentNode.Data;
                }
                _currentNode = _currentNode.NextNode;
            }

            return default(T);
        }

        public T GetLast()
        {
            if (_currentNode == null)
            {
                return default(T);
            }

            while (_currentNode.HasNext())
            {
                _currentNode = _currentNode.NextNode;
            }

            return _currentNode.Data;
        }


        //Netestavau 6ito blet
        public void AddAtEnd(T value)
        {
            while (_currentNode.HasNext())
            {
                _currentNode = _currentNode.NextNode;
            }

            AddAtCurrent(value);
            throw new System.NotImplementedException();
        }

        public void ResetHead()
        {
            _currentNode = _headNode;
        }

        private class Node<T>
        {
            public T Data;
            public Node<T> PreviousNode { get; set; }
            public Node<T> NextNode { get; set; }

            public Node(T data)
            {
                Data = data;
            }

            public void AddNext(T data, Node<T> currentNode)
            {
                var newNode = new Node<T>(data);
                newNode.PreviousNode = currentNode;
                newNode.NextNode = NextNode;

                NextNode = newNode;
            }

            public bool HasNext()
            {
                return NextNode != null;
            }
        }
    }
}