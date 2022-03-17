using MadeFYTrabalho.Models;
using MadeFYTrabalho.Repository.Interface;
using MadeFYTrabalho.Repository.RepositoryModel;
using System;
using System.Collections.Generic;

namespace MadeFYTrabalho.BLL
{
    public class FraseBll
    {
        FraseInterface FraseRepository;

        public FraseBll(FraseInterface _fraseInterface)
        {
            FraseRepository = _fraseInterface;
        }

        public List<Frase> GetListFrase(int IdFrase)
        {
            try
            {
                return FraseRepository.GetListFrase(IdFrase);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Frase GetFrase(int IdFrase)
        {
            try
            {
                return FraseRepository.GetFrase(IdFrase);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int SetFrase(Frase frase)
        {
            try
            {
                return FraseRepository.SetFrase(frase);
            }
            catch (Exception)
            {
                return FraseRepository.SetFrase(frase);
            }
        }
        public bool DeleteFrase(int IdFrase)
        {
            try
            {
                return FraseRepository.DeleteFrase(IdFrase);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateFrase(Frase frase)
        {
            return FraseRepository.UpdateFrase(frase);
        }
    }
}
