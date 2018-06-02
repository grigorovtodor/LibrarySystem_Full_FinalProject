﻿namespace LibrarySystemPro.DataAccessLayer.Contratcs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        T Read(int id);
        ICollection<T> ReadAll();
    }
}
