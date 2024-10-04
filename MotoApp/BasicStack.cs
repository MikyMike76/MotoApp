namespace MotoApp
{
    internal class BasicStack<T>
    {
        private readonly T[] _items;
        private int _currenIndex = -1;
        public BasicStack() => _items = new T[10];
        public int Count => _currenIndex + 1;
        public void Push(T item) => _items[++_currenIndex] = item;
        public T Pop() => _items[_currenIndex--];
    }
}
