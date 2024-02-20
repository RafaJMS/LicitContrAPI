using System;
using System.Collections.Generic;

namespace LicitContrAPI.Models
{
    public partial class Fornecedore
    {
        public Fornecedore()
        {
            Contratos = new HashSet<Contrato>();
            Objetos = new HashSet<Objeto>();
        }

        public int IdFornecedor { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? DocIdentificacao { get; set; }
        public string? Endereco { get; set; }
        public string? Contato { get; set; }
        public int? IdEntidade { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Objeto> Objetos { get; set; }
    }


public static class FornecedoreEndpoints
{
	public static void MapFornecedoreEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Fornecedore", () =>
        {
            return new [] { new Fornecedore() };
        })
        .WithName("GetAllFornecedores")
        .Produces<Fornecedore[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/Fornecedore/{id}", (int id) =>
        {
            //return new Fornecedore { ID = id };
        })
        .WithName("GetFornecedoreById")
        .Produces<Fornecedore>(StatusCodes.Status200OK);

        routes.MapPut("/api/Fornecedore/{id}", (int id, Fornecedore input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateFornecedore")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Fornecedore/", (Fornecedore model) =>
        {
            //return Results.Created($"//api/Fornecedores/{model.ID}", model);
        })
        .WithName("CreateFornecedore")
        .Produces<Fornecedore>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Fornecedore/{id}", (int id) =>
        {
            //return Results.Ok(new Fornecedore { ID = id });
        })
        .WithName("DeleteFornecedore")
        .Produces<Fornecedore>(StatusCodes.Status200OK);
    }
}}
