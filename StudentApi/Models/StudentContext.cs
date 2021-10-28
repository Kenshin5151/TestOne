using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StudentApi.Models
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0482IAI\SQLEXPRESS;Database=StudentDb;User Id=STU;password=STU;Trusted_Connection=True;");            
        }

        public DbSet<StudentInfoClass> StudentInfo
        { 
            get; 
            set; 
        }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public List<StudentInfoClass> getStudents() => StudentInfo.ToList();

        public void AddStudent(StudentInfoClass oneStudent)
        {
            StudentInfo.Add(oneStudent);
            this.SaveChanges();
            return;
        }        
    }

    //public class DatabaseContext : DbContext
    //{
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<Book> Books { get; set; }

    //    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    //    { }

    //    public List<User> getUsers() => Users.ToList();

    //    public List<Book> getBooks() => Books.ToList();

    //    public void AddUser(User user)
    //    {
    //        Users.Add(user);
    //        this.SaveChanges();
    //        return;
    //    }

    //    public void AddBook(Book book)
    //    {
    //        Books.Add(book);
    //        this.SaveChanges();
    //        return;
    //    }
    //}
}