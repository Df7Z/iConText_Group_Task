using System;
using System.Collections.Generic;

namespace iConText_Group_Task
{
    public abstract class DataBase<E> where E : IDataBaseElement
    {
        protected List<E> _elements = new List<E>(5);

        public virtual string GetConsoleOutput(E element) => string.Empty;

        public virtual void Delete(int id)
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i].Id == id)
                {
                    _elements.RemoveAt(i);

                    Console.WriteLine("Элемент удалён!");

                    return;
                }
            }

            throw new Exception("Не найдена запись с нужным id!");
        }

        protected void Update(int id, E newValue)
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                if (id == _elements[i].Id)
                {
                    _elements[i] = newValue;

                    Console.WriteLine("Элемент обновлен!");

                    return;
                }
            }

            throw new Exception("Не найдена запись с нужным id!");
        }

        public virtual void Add(string[] parameters) { }

        public virtual void Add(E element)
        {
            int maxId = 123 - 1; //0

            foreach (var item in _elements)
            {
                if (item.Id > maxId) maxId = item.Id;
            }

            maxId++;

            element.Id = maxId;

            _elements.Add(element);

            Console.WriteLine("Элемент добавлен!");
        }

        public virtual E Get(int id)
        {
            foreach (var item in _elements)
            {
                if (item.Id == id)
                {
                    Console.WriteLine(GetConsoleOutput(item));

                    return item; 
                }
            }

            throw new Exception("Не найдена запись с нужным id!");
        }

        public virtual void GetAll()
        {
            Console.WriteLine("Все элементы:");

            foreach (var item in _elements)
            {
                Console.WriteLine(GetConsoleOutput(item));
            }
        }

        public virtual void Update(int id, string[] parameters) { }
    }
}
