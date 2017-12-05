﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.JSONObjects
{
    public class PaginatedResult<T>
    {
        public int TotalResults { get; set; }
        public string ShowingResults { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }
        public List<T> Results { get; set; }
    }
    /*
    public class User
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }
    }

    public class Post
    {
        public string Url { get; set; }
        public string Body { get; set; }
        public User Owner { get; set; }
        public DateTime Created { get; set; }
        public int Score { get; set; }
    }

    public class Question : Post
    {
        public string Title { get; set; }
        public DateTime? Closed { get; set; }
        public List<Answer> Answers { get; set; }
        public List<string> Tags { get; set; }
    }

    public class Answer : Post
    {
    }


    public class Comment
    {
        public string Url { get; set; }
        public User Owner { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }

        public string ParentUrl { get; set; }
    }
    */
}