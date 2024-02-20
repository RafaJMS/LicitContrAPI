using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LicitContrAPI.Models
{
    public partial class BancoDadosCLContext : DbContext
    {
        public BancoDadosCLContext()
        {
        }

        public BancoDadosCLContext(DbContextOptions<BancoDadosCLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contrato> Contratos { get; set; } = null!;
        public virtual DbSet<Entidade> Entidades { get; set; } = null!;
        public virtual DbSet<Fornecedore> Fornecedores { get; set; } = null!;
        public virtual DbSet<Licitaco> Licitacoes { get; set; } = null!;
        public virtual DbSet<Lote> Lotes { get; set; } = null!;
        public virtual DbSet<Objeto> Objetos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PK__Contrato__FF5F2A56548126C6");

                entity.Property(e => e.IdContrato).HasColumnName("id_contrato");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("data_inicio");

                entity.Property(e => e.DataTermino)
                    .HasColumnType("date")
                    .HasColumnName("data_termino");

                entity.Property(e => e.IdEntidade).HasColumnName("id_entidade");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.IdObjeto).HasColumnName("id_objeto");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Ativo')");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdEntidadeNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdEntidade)
                    .HasConstraintName("FK_Contratos_Entidades");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK_Contratos_Fornecedores");

                entity.HasOne(d => d.IdObjetoNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdObjeto)
                    .HasConstraintName("FK_Contratos_Objetos");
            });

            modelBuilder.Entity<Entidade>(entity =>
            {
                entity.HasKey(e => e.IdEntidade)
                    .HasName("PK__Entidade__E3B5790B4CF95811");

                entity.Property(e => e.IdEntidade).HasColumnName("id_entidade");

                entity.Property(e => e.Contato)
                    .HasColumnType("text")
                    .HasColumnName("contato");

                entity.Property(e => e.Endereco)
                    .HasColumnType("text")
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("('Pública')");
            });

            modelBuilder.Entity<Fornecedore>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK__Forneced__6C477092251EB8F5");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.Contato)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contato");

                entity.Property(e => e.DocIdentificacao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("doc_identificacao");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdEntidade).HasColumnName("id_entidade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("('Jurídica')");
            });

            modelBuilder.Entity<Licitaco>(entity =>
            {
                entity.HasKey(e => e.IdLicitacao)
                    .HasName("PK__Licitaco__A9BF10D045BF8FE5");

                entity.Property(e => e.IdLicitacao).HasColumnName("id_licitacao");

                entity.Property(e => e.DataPublicacao)
                    .HasColumnType("date")
                    .HasColumnName("data_publicacao");

                entity.Property(e => e.IdEntidade).HasColumnName("id_entidade");

                entity.Property(e => e.Modalidade)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("modalidade");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Ativo')");

                entity.Property(e => e.ValorEstimado)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("valor_estimado");

                entity.HasOne(d => d.IdEntidadeNavigation)
                    .WithMany(p => p.Licitacos)
                    .HasForeignKey(d => d.IdEntidade)
                    .HasConstraintName("FK_Licitacoes_Entidades");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote)
                    .HasName("PK__Lotes__9A000486A2208E12");

                entity.Property(e => e.IdLote).HasColumnName("id_lote");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.IdLicitacao).HasColumnName("id_licitacao");

                entity.Property(e => e.ValorEstimadoTotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdLicitacaoNavigation)
                    .WithMany(p => p.Lotes)
                    .HasForeignKey(d => d.IdLicitacao)
                    .HasConstraintName("FK_Lotes_Licitacoes");
            });

            modelBuilder.Entity<Objeto>(entity =>
            {
                entity.HasKey(e => e.IdObjeto)
                    .HasName("PK__Objetos__6C522AB4C0F18AEE");

                entity.Property(e => e.IdObjeto).HasColumnName("id_objeto");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.IdLote).HasColumnName("id_lote");

                entity.Property(e => e.Observacoes)
                    .HasColumnType("text")
                    .HasColumnName("observacoes");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.ValorEstimado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorEstimado");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Objetos)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK_Objetos_Fornecedores");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.Objetos)
                    .HasForeignKey(d => d.IdLote)
                    .HasConstraintName("FK_Objetos_Lotes");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__4E3E04ADBFF3678E");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdEntidade).HasColumnName("id_entidade");

                entity.Property(e => e.NivelPermissao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nivel_permissao")
                    .HasDefaultValueSql("('Baixo')");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdEntidadeNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEntidade)
                    .HasConstraintName("FK_Usuarios_Entidades");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
