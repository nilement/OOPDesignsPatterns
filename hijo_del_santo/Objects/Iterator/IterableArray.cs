using System.Collections.Generic;

namespace Objects.Iterator
{
    public class IterableArray<T> : IIterator<T>
    {
        private T[] _array;
        private int _index;

        public IterableArray(int size = 1)
        {
            _array = new T[size];
            _index = 0;
        }
        public IterableArray(T[] array)
        {
            _array = array;
            _index = 0;
        }

        public void Next()
        {
            _index++;
        }

        public bool HasNext()
        {
            return _array.Length > _index + 1 && !(EqualityComparer<T>.Default.Equals(_array[_index + 1], default(T)));
        }

        public void Remove()
        {
            var newArray = new T[_array.Length - 1];

            var j = 0;
            for (var i = 0; i < _array.Length; i++)
            {
                if (j == _index)
                {
                    j++;
                    continue;
                }

                newArray[i] = _array[j++];
            }

            _array = newArray;
            if (newArray.Length == _index)
            {
                _index--;
            }
        }

        public void AddAtCurrent(T value)
        {
            var newArray = new T[_array.Length + 1];

            var j = 0;
            for (var i = 0; i < _array.Length; i++)
            {
                if (j == _index)
                {
                    newArray[j++] = value;
                    i--;
                    continue;
                }

                newArray[j++] = _array[i];
            }

            _array = newArray;
            if (newArray.Length == _index)
            {
                _index--;
            }
        }

        public void Add(T value, int index)
        {
            var newArray = new T[_array.Length + 1];

            var j = 0;
            for (var i = 0; i < _array.Length; i++)
            {
                if (j == index)
                {
                    newArray[j++] = value;
                    i--;
                    continue;
                }

                newArray[j++] = _array[i];
            }

            if (newArray[_array.Length] == null) newArray[_array.Length] = value;
            _array = newArray;
            if (newArray.Length == _index)
            {
                _index--;
            }
        }

        public void SetAtCurrent(T value)
        {
            _array[_index] = value;
        }

        public void Set(T value, int index)
        {
            _array[index] = value;
        }

        public T GetCurrent()
        {
            return _array[_index];
        }

        public T Get(int index)
        {
            _index = index;
            return _array[index];
        }

        public T GetLast()
        {
            return Get(_array.Length - 1);
        }

        public void AddAtEnd(T value)
        {
            if (_array[0] == null)
            {
                _array[0] = value;
                return;
            }

            Add(value, _array.Length);
        }

        public void ResetHead()
        {
            _index = 0;
        }
    }
}