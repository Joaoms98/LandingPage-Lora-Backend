using FluentMigrator;

namespace LandingPage.Lora.Infrastructure.Migrations.Scripts;

[Migration(20230711171800)]
public class AddPersonTable : Migration
{
    public const string TableName = "Person";

    public override void Up()
    {
        Create.Table(TableName)
            .WithColumn("Id")
                .AsGuid()
                .PrimaryKey()
            .WithColumn("Name")
                .AsString(150)
                .NotNullable()
            .WithColumn("Email")
                .AsString(150)
                .NotNullable()
            .WithColumn("CreatedAt")
                .AsDateTime()
                .NotNullable()
            .WithColumn("UpdateAt")
                .AsDateTime()
                .Nullable()
            .WithColumn("SoftDeleteAt")
                .AsDateTime()
                .Nullable();
    }

    public override void Down()
    {
        Delete.Table(TableName);
    }
}