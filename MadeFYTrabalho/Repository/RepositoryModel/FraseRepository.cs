using MadeFYTrabalho.Models;
using MadeFYTrabalho.Repository.Interface;
using System.Collections.Generic;
using SoulSoftApi.Model;
using System;
using System.Linq;

namespace MadeFYTrabalho.Repository.RepositoryModel
{
    public class FraseRepository : FraseInterface
    {
        private readonly WebAppDbContext _context;

        public FraseRepository(WebAppDbContext context)
        {
            _context = context;
        }

        public bool DeleteFrase(int IdFrase)
        {
            int result = 0;
            if(_context != null)
            {
                var frase = _context.Frases.FirstOrDefault(x => x.Id == IdFrase);
                if(frase != null)
                {
                    _context.Frases.Remove(frase);
                    result = _context.SaveChanges();
                }
                return result != 0 ? true : false; 
            }
            return result != 0 ? true : false;
        }


        public Frase GetFrase(int IdFrase)
        {
            if (_context != null)
            {
                return _context.Frases.FirstOrDefault(x => x.Id == IdFrase);
            }
            return null;
        }

        public List<Frase> GetListFrase(int IdFrase)
        {
            return _context.Frases.Where(x => x.Id == IdFrase).ToList();
        }

        public int SetFrase(Frase frase)
        {
            if (_context != null)
            {
                frase.DtCadastro = DateTime.Now;
                _context.Frases.AddAsync(frase);
                _context.SaveChanges();

                return frase.Id;
            }
            return 0;
        }

        public bool UpdateFrase(Frase frase)
        {
            int result = 0;
            if (_context != null)
            {
                frase.DtCadastro = DateTime.Now;
                _context.Frases.Update(frase);
                result = _context.SaveChanges();
                return result != 0 ? true : false;
            }
            return result != 0 ? true : false;
        }
    }
}
