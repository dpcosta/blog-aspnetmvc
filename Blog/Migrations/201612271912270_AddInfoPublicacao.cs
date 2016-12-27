namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInfoPublicacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("Post", "DataPublicacao", c => c.DateTime(nullable: true));
            AddColumn("Post", "Publicado", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("Post", "DataPublicacao");
            DropColumn("Post", "Publicado");
        }
    }
}
