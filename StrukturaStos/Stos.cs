using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrukturaStos
{
    internal class Stos<T> : IStos<T>
    {
        private List<T> stos;

        private int _count;

        private bool _isEmpty;

        private T _peek;

        public int Count
        {
            get { return _count; }
            private set { _count = value; }
        }

        public bool IsEmpty
        {
            get { return _isEmpty; }
            private set { _isEmpty = value; }
        }

        public T Peek
        {
            get 
            {
                if (IsEmpty == true) throw new StosEmptyException();
                return _peek;  
            }
            private set { _peek = value; }
        }

        public Stos()
        {
            _count = 0;
            _isEmpty = true;
            stos = new List<T>();
            _peek = default(T);
        }

        public void Push(T value)
        {
            Count += 1;
            Peek = value;
            IsEmpty = false;
            stos.Add(value);
        }
        public T Pop()
        {
            if (IsEmpty == true) throw new StosEmptyException();
            else
            {
                T last = stos.Last();
                stos.RemoveAt(Count - 1);
                Count -= 1;
                if(Count == 0)
                {
                    IsEmpty = true;
                    Peek = default(T);
                }
                else Peek = stos.Last();   
                
                return last;
            }
        }

        public void Clear()
        {
            stos.Clear();
            Peek = default(T);
            Count = 0;
            IsEmpty = true;
        }

        public T[] ToArray()
        {
            List<T> clone = new List<T>(stos);
            return clone.ToArray();
        }


    }
}
