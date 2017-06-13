namespace RoastMeApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replyadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Votes", "Comment_id", "dbo.Comments");
            DropForeignKey("dbo.Votes", "Comment_id1", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "CommentId" });
            DropIndex("dbo.Votes", new[] { "CommentId" });
            DropIndex("dbo.Votes", new[] { "Comment_id" });
            DropIndex("dbo.Votes", new[] { "Comment_id1" });
            DropColumn("dbo.Votes", "CommentId");
            RenameColumn(table: "dbo.Votes", name: "Comment_id1", newName: "CommentId");
            AddColumn("dbo.Comments", "isReply", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "CommentRepliedId", c => c.Int());
            AlterColumn("dbo.Votes", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Votes", "CommentId");
            AddForeignKey("dbo.Votes", "CommentId", "dbo.Comments", "id", cascadeDelete: true);
            DropColumn("dbo.Comments", "CommentId");
            DropColumn("dbo.Votes", "Comment_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "Comment_id", c => c.Int());
            AddColumn("dbo.Comments", "CommentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Votes", "CommentId", "dbo.Comments");
            DropIndex("dbo.Votes", new[] { "CommentId" });
            AlterColumn("dbo.Votes", "CommentId", c => c.Int());
            DropColumn("dbo.Comments", "CommentRepliedId");
            DropColumn("dbo.Comments", "isReply");
            RenameColumn(table: "dbo.Votes", name: "CommentId", newName: "Comment_id1");
            AddColumn("dbo.Votes", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Votes", "Comment_id1");
            CreateIndex("dbo.Votes", "Comment_id");
            CreateIndex("dbo.Votes", "CommentId");
            CreateIndex("dbo.Comments", "CommentId");
            AddForeignKey("dbo.Votes", "Comment_id1", "dbo.Comments", "id");
            AddForeignKey("dbo.Votes", "Comment_id", "dbo.Comments", "id");
            AddForeignKey("dbo.Comments", "CommentId", "dbo.Comments", "id");
        }
    }
}
