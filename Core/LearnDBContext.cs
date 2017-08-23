using Core.Migrations;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LearnDBContext: DbContext
    {
        static LearnDBContext()
        {
            //При отсутствии БД создаст БД по модели из кода.
            //Для инициализации базы по своим правилам можно замутить свой класс унаследовав его от CreateDatabaseIfNotExists<T>
            //Database.SetInitializer<LearnDbContext>(new CustomCreateDatabaseIfNotExists<LearnDbContext>());
            Database.SetInitializer<LearnDBContext>(new DropCreateDatabaseAlways<LearnDBContext>());
            // Включаем автоматическую миграцию на время разработки сервиса, чтобы все изменения автоматически отражались в БД
            // TODO : Отключить в релизе
            Database.SetInitializer<LearnDBContext>(new MigrateDatabaseToLatestVersion<LearnDBContext, /*DbMigrationsConfiguration<LearnDBContext>*/Configuration>());
        }

        public LearnDBContext():base("Name=LearnDBContext")
        {
            Configuration.LazyLoadingEnabled = false;
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
