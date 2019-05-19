namespace Objects.Iterator
{
    public interface IIterator<T>
    {
        void Next();
        bool HasNext();
        void Remove();
        void AddAtCurrent(T value);
        void Add(T value, int index);
        void SetAtCurrent(T value);
        void Set(T value, int index);
        T GetCurrent();
        T Get(int index);
        T GetLast();
        void AddAtEnd(T index);
        void ResetHead();

    }
}
