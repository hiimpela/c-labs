public class CustomStack<T> {
    private T[] _items;
    private int _top;

    public CustomStack(int capacity = 10) {
        _items = new T[capacity];
        _top = 0;
    }

    public int Count => _top;

    public void Push(T item) {
        if (_top == _items.Length) {
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[_top++] = item;
    }

    public T Pop() {
        if (_top == 0) {
            throw new InvalidOperationException("Stack is empty.");
        }
        _top--;
        T item = _items[_top];
        _items[_top] = default!; 
        return item;
    }

    public T Peek() {
        if (_top == 0) {
            throw new InvalidOperationException("Stack is empty.");
        }
        return _items[_top - 1];
    }
}
