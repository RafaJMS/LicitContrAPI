using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicitContrAPI.Migrations
{
    public partial class uia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    id_entidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tipo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, defaultValueSql: "('Pública')"),
                    endereco = table.Column<string>(type: "text", nullable: true),
                    contato = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Entidade__E3B5790B4CF95811", x => x.id_entidade);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    id_fornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tipo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, defaultValueSql: "('Jurídica')"),
                    doc_identificacao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    endereco = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    contato = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_entidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Forneced__6C477092251EB8F5", x => x.id_fornecedor);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licitacoes",
                columns: table => new
                {
                    id_licitacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_publicacao = table.Column<DateTime>(type: "date", nullable: true),
                    modalidade = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_entidade = table.Column<int>(type: "int", nullable: true),
                    valor_estimado = table.Column<decimal>(type: "decimal(20,5)", nullable: true),
                    status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('Ativo')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Licitaco__A9BF10D045BF8FE5", x => x.id_licitacao);
                    table.ForeignKey(
                        name: "FK_Licitacoes_Entidades",
                        column: x => x.id_entidade,
                        principalTable: "Entidades",
                        principalColumn: "id_entidade");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    nivel_permissao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, defaultValueSql: "('Baixo')"),
                    id_entidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__4E3E04ADBFF3678E", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Entidades",
                        column: x => x.id_entidade,
                        principalTable: "Entidades",
                        principalColumn: "id_entidade");
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    id_lote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_licitacao = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    ValorEstimadoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lotes__9A000486A2208E12", x => x.id_lote);
                    table.ForeignKey(
                        name: "FK_Lotes_Licitacoes",
                        column: x => x.id_licitacao,
                        principalTable: "Licitacoes",
                        principalColumn: "id_licitacao");
                });

            migrationBuilder.CreateTable(
                name: "Objetos",
                columns: table => new
                {
                    id_objeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    categoria = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    valorEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: true),
                    observacoes = table.Column<string>(type: "text", nullable: true),
                    id_lote = table.Column<int>(type: "int", nullable: true),
                    id_fornecedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Objetos__6C522AB4C0F18AEE", x => x.id_objeto);
                    table.ForeignKey(
                        name: "FK_Objetos_Fornecedores",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id_fornecedor");
                    table.ForeignKey(
                        name: "FK_Objetos_Lotes",
                        column: x => x.id_lote,
                        principalTable: "Lotes",
                        principalColumn: "id_lote");
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    id_contrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_inicio = table.Column<DateTime>(type: "date", nullable: true),
                    data_termino = table.Column<DateTime>(type: "date", nullable: true),
                    valor = table.Column<decimal>(type: "decimal(20,5)", nullable: true),
                    status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('Ativo')"),
                    id_entidade = table.Column<int>(type: "int", nullable: true),
                    id_fornecedor = table.Column<int>(type: "int", nullable: true),
                    id_objeto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contrato__FF5F2A56548126C6", x => x.id_contrato);
                    table.ForeignKey(
                        name: "FK_Contratos_Entidades",
                        column: x => x.id_entidade,
                        principalTable: "Entidades",
                        principalColumn: "id_entidade");
                    table.ForeignKey(
                        name: "FK_Contratos_Fornecedores",
                        column: x => x.id_fornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "id_fornecedor");
                    table.ForeignKey(
                        name: "FK_Contratos_Objetos",
                        column: x => x.id_objeto,
                        principalTable: "Objetos",
                        principalColumn: "id_objeto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_id_entidade",
                table: "Contratos",
                column: "id_entidade");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_id_fornecedor",
                table: "Contratos",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_id_objeto",
                table: "Contratos",
                column: "id_objeto");

            migrationBuilder.CreateIndex(
                name: "IX_Licitacoes_id_entidade",
                table: "Licitacoes",
                column: "id_entidade");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_id_licitacao",
                table: "Lotes",
                column: "id_licitacao");

            migrationBuilder.CreateIndex(
                name: "IX_Objetos_id_fornecedor",
                table: "Objetos",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Objetos_id_lote",
                table: "Objetos",
                column: "id_lote");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_entidade",
                table: "Usuarios",
                column: "id_entidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Objetos");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Licitacoes");

            migrationBuilder.DropTable(
                name: "Entidades");
        }
    }
}
