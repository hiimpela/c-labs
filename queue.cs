public class CustomQueue<T> {
    private T[] _items;
    private int _head = 0;
    private int _tail = 0;
    private int _size = 0;

    public CustomQueue(int capacity = 10) {
        _items = new T[capacity];
    }

    public int Count => _size;

    public void Enqueue(T item) {
        if (_size == _items.Length) {
            T[] newArray = new T[_items.Length * 2];
            for (int i = 0; i < _size; i++) {
                newArray[i] = _items[(_head + i) % _items.Length];
            }
            _items = newArray;
            _head = 0;
            _tail = _size;
        }

        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _size++;
    }

    public T Dequeue() {
        if (_size == 0) {
            throw new InvalidOperationException("Queue is empty.");
        }

        T item = _items[_head];
        _items[_head] = default!; 
        _head = (_head + 1) % _items.Length;
        _size--;
        return item;
    }

    public T Peek() {
        if (_size == 0) {
            throw new InvalidOperationException("Queue is empty.");
        }
        return _items[_head];
    }
}
