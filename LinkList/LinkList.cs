using System;

namespace LinkList
{
    class LinkList<T>
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
                throw new Exception("Nothing to pop");
            }
            _first = _first.Next;
            if (_first != null)
            {
                _first.Prev = null;
            }
            _length--;
            return listItem.Element;
        }

        static void Main(string[] args)
        {
            var linkList = new LinkList<int>();
            linkList.Add(30);
            Console.WriteLine(linkList.Pop() == 30);
        }
    }

    class LinkListItem<T>
    {
        public LinkListItem<T> Prev;
        public LinkListItem<T> Next;
        public T Element;
    }
}
