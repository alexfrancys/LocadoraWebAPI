﻿using Locadora.Domain.FilmeAggregate;
using System;

namespace Locadora.Application.Queries.GetFilmeById
{
    public class GetFilmesByIdQueryResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public decimal ValorDiario { get; set; }
        public SituacaoFilme Situacao { get; set; }
    }
}
