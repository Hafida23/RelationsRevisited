using Microsoft.EntityFrameworkCore.Migrations;

namespace RelationsRevisited.Migrations
{
    public partial class initail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCvs",
                columns: table => new
                {
                    EmployeeCvId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCvs", x => x.EmployeeCvId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmployeeCvId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeCvs_EmployeeCvId",
                        column: x => x.EmployeeCvId,
                        principalTable: "EmployeeCvs",
                        principalColumn: "EmployeeCvId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    SkillsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Skills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Skills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "SkillsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeCvs",
                columns: new[] { "EmployeeCvId", "Title" },
                values: new object[,]
                {
                    { 1, ".Net Developer" },
                    { 2, "Java Developer" },
                    { 3, "administratief medewerker" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillsId", "SkillsDescription" },
                values: new object[,]
                {
                    { 1, "C#,Sql,......" },
                    { 2, "Administratie ervaring...." }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "EmployeeCvId", "FirstName", "LastName" },
                values: new object[] { 1, 1, 1, "kenan", "Kurda" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "EmployeeCvId", "FirstName", "LastName" },
                values: new object[] { 2, 2, 3, "Pearl", "De Smet" });

            migrationBuilder.InsertData(
                table: "Employee_Skills",
                columns: new[] { "Id", "EmployeeId", "SkillsId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Employee_Skills",
                columns: new[] { "Id", "EmployeeId", "SkillsId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Skills_EmployeeId",
                table: "Employee_Skills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Skills_SkillsId",
                table: "Employee_Skills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCvId",
                table: "Employees",
                column: "EmployeeCvId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee_Skills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeCvs");
        }
    }
}
