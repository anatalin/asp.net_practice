namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Posts");
            DropColumn("dbo.Posts", "Id");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            AddColumn("dbo.Posts", "PostId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropPrimaryKey("dbo.Posts");
            DropColumn("dbo.Posts", "PostId");
            DropTable("dbo.Comments");
            AddPrimaryKey("dbo.Posts", "Id");
        }
    }
}
