﻿using System.ComponentModel.DataAnnotations;

namespace PhotoShare.Service
{
    /// <summary>
    ///     папка для ef. папка для доменной модели (сущностей). папка репозиториев.
    /// </summary>
    public class Entity
    {
        [Key] private int ID;
    }
}