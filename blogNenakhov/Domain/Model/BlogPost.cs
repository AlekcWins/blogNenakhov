﻿using System;
using blogNenakhov.Domain.Model.Common;

namespace blogNenakhov.Domain.Model
{
    /// <summary>
    /// Пост блога
    /// </summary>
    public class BlogPost:Entity
    {
        /// <summary>
        /// Пользователь который создал сущность
        /// </summary>
        public Employee Owner { get; set; }

        /// <summary>
        /// Дата и время создания поста
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Заголовок поста
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        public string Data { get; set; }
    }
}