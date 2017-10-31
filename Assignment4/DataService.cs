﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DAL
{
    public class DataService : IDataService
    {
        public List<SearchQuestion> GetPostsByName(string name, int page, int pageSize, out int totalResults)
        {

            using (var db = new SovaContext())
            {

                var posts = db.SearchQuestions.FromSql("CALL wordSearch({0})", name);
                totalResults = posts.Count();
                
                var returnPosts = posts.Skip(page * pageSize).Take<SearchQuestion>(pageSize).ToList<SearchQuestion>();
                foreach (var post in posts)
                {
                    post.FillTags();
                }
                return returnPosts;
            }
        }
        public Question GetPost(int id)
        {
            using (var db = new SovaContext())
            {
                var post = GetQuestionAllData(id);//db.Questions.Include(p => p.Comments).FirstOrDefault(x => x.Id == id);
                
                return post;
            }
        }

        public Question GetQuestionAllData(int id)
        {
            using (var db = new SovaContext())
            {
                var question =  db.Questions.FirstOrDefault(x => x.Id == id);
                question.FillAnswers();
                question.FillComments();
                question.FillTags();

                foreach(Answer answer in question.Answers)
                {
                    answer.FillComments();
                }
                return question;
            }

        }

        public User GetUser(int id)
        {
            using (var db = new SovaContext())
            {
                return db.Users.FirstOrDefault(user => user.Id == id);
            }
        }

        public List<Question> GetPostsByTagId(int tagId)
        {
            throw new NotImplementedException();
        }

        public Boolean MarkPost(int id)
        {
            using (var db = new SovaContext())
            {

                try
                {
                    var result = db.Database.ExecuteSqlCommand("CALL setMarkedPost({0})", id);

                    return true;
                }
                catch (Exception)
                {

                }
                
                return false;
            }
        }

        public bool UnmarkPost(int id)
        {
            using (var db = new SovaContext())
            {

               
                var result = db.Database.ExecuteSqlCommand("CALL removeMarkedPost({0})", id);
                Debug.WriteLine(result);
                return result > 0;
                
            }
        }

        public bool AddHistory(string searchWord)
        {
            throw new NotImplementedException();
        }

        public Note GetNote(int postId)
        {
            using (var db = new SovaContext())
            {
                return db.Notes.FirstOrDefault(note => note.PostId == postId);
            }
        }

        public Note CreateNote(int postId, string text)
        {
            using (var db = new SovaContext())
            {
                Note note = new Note();
                try
                {
                    var result = db.Database.ExecuteSqlCommand("CALL createNote({0}, {1})", postId, text);
                    note.Text = text;
                    note.PostId = postId;
                    return note;

                }
                catch (Exception)
                {

                }
               
                return null;
            }
        }

        public bool DeleteNote(int noteId)
        {
            throw new NotImplementedException();
        }

        public bool ClearHistory()
        {
            using (var db = new SovaContext())
            {


                db.Database.ExecuteSqlCommand("CALL clearHistory()");
                
                return true;

            }
        }
    }

   

}
