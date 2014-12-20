using System;

namespace LinkList
{
    public class LinkList<T>
    {
        private LinkListItem<T> _first;
        private LinkListItem<T> _last;
        private int _length;

        public int Add(T element)
        {
            if (_length == 0)
            {
                _last = _first = new LinkListItem<T> { Element = element, Prev = null, Next = null };
            }
            else
            {
                _last = _last.Next = new LinkListItem<T> { Element = element, Prev = _last, Next = null };
            }
            return ++_length;
        }

        public T Pop()
        {
            var listItem = _first;
            if (listItem == null)
            {
                return default(T);
            }
            _first = _first.Next;
            if (_first != null)
            {
                _first.Prev = null;
            }
            _length--;
            return listItem.Element;
        }

        private LinkListItem<T> SelectAt(int index)
        {
            if(index < 0 || index >= _length){
                return null;
            }
            int steps;
            LinkListItem<T> pointer;

            if(index < _length / 2){
                steps = index;
                pointer = _first;
                while(steps > 0 && pointer != null){
                    pointer = pointer.Next;
                    steps--;
                }
            } else {
                steps = _length - index - 1;
                pointer = _last;
                while(steps > 0 && pointer != null){
                    pointer = pointer.Prev;
                    steps--;
                }
            }
            return pointer;
        }

        public T GetElementByIndex(int index)
        {
            var selection = SelectAt(index);
            return selection == null ? default(T) : selection.Element;
        }

        public LinkListItem<T> GetObjectByIndex(int index)
        {
            return SelectAt(index);
        }

        public int Recount()
        {
            int length = 0;
            LinkListItem<T> pointer = _first;
            while(pointer != null){
                length++;
                pointer = pointer.Next;
            }
            return length;
        }

        public int Length
        {
            get { return _length; }
        }

        public LinkListItem<T> FirstObject
        {
            get { return _first; }
        }

        public LinkListItem<T> LastObject
        {
            get { return _last; }
        }
    }
    public class LinkListItem<T>
    {
        public LinkListItem<T> Prev;
        public LinkListItem<T> Next;
        public T Element;
    }
}
