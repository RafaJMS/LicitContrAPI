using System;
using System.Collections.Generic;

namespace LicitContrAPI.Models
{
    public partial class Contrato
    {
        public int IdContrato { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public decimal? Valor { get; set; }
        public string? Status { get; set; }
        public int? IdEntidade { get; set; }
        public int? IdFornecedor { get; set; }
        public int? IdObjeto { get; set; }

        public virtual Entidade? IdEntidadeNavigation { get; set; }
        public virtual Fornecedor? IdFornecedorNavigation { get; set; }
        public virtual Objeto? IdObjetoNavigation { get; set; }
    }


public static class ContratoEndpoints
{
	public static void MapContratoEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Contrato", () =>
        {
            return new [] { new Contrato() };
        })
        .WithName("GetAllContratos")
        .Produces<Contrato[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/Contrato/{id}", (int id) =>
        {
            //return new Contrato { ID = id };
        })
        .WithName("GetContratoById")
        .Produces<Contrato>(StatusCodes.Status200OK);

        routes.MapPut("/api/Contrato/{id}", (int id, Contrato input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateContrato")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Contrato/", (Contrato model) =>
        {
            //return Results.Created($"//api/Contratos/{model.ID}", model);
        })
        .WithName("CreateContrato")
        .Produces<Contrato>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Contrato/{id}", (int id) =>
        {
            //return Results.Ok(new Contrato { ID = id });
        })
        .WithName("DeleteContrato")
        .Produces<Contrato>(StatusCodes.Status200OK);
    }
}}
