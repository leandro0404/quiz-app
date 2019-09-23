using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using Quiz.Entities.Entitites;
using Quiz.Repositories.Abstractions;
using Quiz.Repositories.Context;
using Quiz.Repositories.Model;

namespace Quiz.Services
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        private readonly IMapper _mapper;
        private readonly DbContext _context;
        public QuestionarioRepository(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Questao>> Get()
        {
            var result = _context.Questao.AsQueryable().ToList();
            var random = result.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            return _mapper.Map<IEnumerable<Questao>>(random);
        }

        public async Task<IEnumerable<Prova>> GetByEmail(string email)
        {
            var filter = Builders<ProvaModel>.Filter.And(Builders<ProvaModel>.
                Filter.Where(x => x.Email == email));
            var result = _context.Prova.Find(filter).ToList();
            return _mapper.Map<IEnumerable<Prova>>(result);
        }

        public async Task<IEnumerable<Prova>> Rank()
        {
            var result = _context.Prova.AsQueryable()
                    .GroupBy(row => new
                    {
                        X = row.Email
                    })
                    .Select(x => new ProvaModel
                    {
                        Email = x.Key.X,
                        Pontos = x.Max(z => z.Pontos)
                    }).OrderByDescending(x => x.Pontos).ToList();

            return _mapper.Map<IEnumerable<Prova>>(result);
        }

        public Task<Prova> Save(Prova prova)
        {
            _context.Prova.InsertOneAsync(_mapper.Map<ProvaModel>(prova));
            return Task.FromResult(prova);
        }
    }
}
