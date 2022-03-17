using MadeFYTrabalho.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MadeFYTrabalho.Repository.Interface
{
    public interface FraseInterface
    {
        public List<Frase> GetListFrase(int IdFrase);
        public Frase GetFrase(int IdFrase);
        public int SetFrase(Frase frase);
        public bool DeleteFrase(int IdFrase);
        public bool UpdateFrase(Frase frase);

    }
}
