using Core.Interceptors;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LearnDBContext: DbContext
    {
        private bool useRecompileOption = false;

        public bool UseRecompileOption
        {
            get
            {
                return useRecompileOption;
            }

            set
            {
                useRecompileOption = value;
            }
        }

        static LearnDBContext()
        {
            //При отсутствии БД создаст БД по модели из кода.
            //Для инициализации базы по своим правилам можно замутить свой класс унаследовав его от CreateDatabaseIfNotExists<T>
            Database.SetInitializer<LearnDBContext>(new LearnDBInitializer());
            //Database.SetInitializer<LearnDBContext>(new DropCreateDatabaseIfModelChanges<LearnDBContext>());
            // Включаем автоматическую миграцию на время разработки сервиса, чтобы все изменения автоматически отражались в БД
            // TODO : Отключить в релизе
            //Database.SetInitializer<LearnDBContext>(new MigrateDatabaseToLatestVersion<LearnDBContext, /*DbMigrationsConfiguration<LearnDBContext>*/Configuration>());
        }

        public LearnDBContext():base("Name=LearnDBContext")
        {
            //Configuration.LazyLoadingEnabled = false;            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Comment>().HasOptional<Post>(c => c.Post).WithMany().WillCascadeOnDelete();
            //modelBuilder.Entity<Comment>().HasOptional<Author>(c => c.Author).WithMany().WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
    }
}
