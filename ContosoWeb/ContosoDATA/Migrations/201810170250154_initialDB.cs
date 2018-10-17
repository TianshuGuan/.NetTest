namespace ContosoDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Credit = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        RowVeersion = c.Binary(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 10),
                        AddressLine1 = c.String(maxLength: 150),
                        AddressLine2 = c.String(maxLength: 150),
                        UnitOrAppartmentNumber = c.Int(nullable: false),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 20),
                        ZipCode = c.String(maxLength: 9),
                        PassWord = c.String(maxLength: 20),
                        Salt = c.String(maxLength: 20),
                        IsLocked = c.Boolean(nullable: false),
                        LastLockedDateTime = c.DateTime(nullable: false),
                        FailedAttempt = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        Location = c.String(maxLength: 150),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorId)
                .ForeignKey("dbo.Instructor", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 50),
                        Descriptioin = c.String(maxLength: 200),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Grades = c.Int(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Id })
                .ForeignKey("dbo.Instructor", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.PersonRoles",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Role_Id })
                .ForeignKey("dbo.Person", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HiredDate = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: false)
                .Index(t => t.Id)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Id", "dbo.Person");
            DropForeignKey("dbo.Instructor", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Instructor", "Id", "dbo.Person");
            DropForeignKey("dbo.Course", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.PersonRoles", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.PersonRoles", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.OfficeAssignment", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructor");
            DropIndex("dbo.Student", new[] { "Id" });
            DropIndex("dbo.Instructor", new[] { "DepartmentId" });
            DropIndex("dbo.Instructor", new[] { "Id" });
            DropIndex("dbo.PersonRoles", new[] { "Role_Id" });
            DropIndex("dbo.PersonRoles", new[] { "Person_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropIndex("dbo.Enrollment", new[] { "CourseId" });
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorId" });
            DropIndex("dbo.Course", new[] { "DepartmentId" });
            DropTable("dbo.Student");
            DropTable("dbo.Instructor");
            DropTable("dbo.PersonRoles");
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Role");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Person");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
        }
    }
}
