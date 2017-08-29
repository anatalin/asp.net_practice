namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 254),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        PostId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PublishDate = c.DateTime(nullable: false, storeType: "date"),
                        Text = c.String(),
                        Description = c.String(maxLength: 255),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Authors");
        }
    }
}
