using MadeFYTrabalho.Models;
using System;

namespace MadeFYTrabalho.BLL
{
    public class VerificarLetra
    {
        
        public  RetornoVerificaLetra ComparaLetra(string letraA, string letraB, bool colchete)
        {
           
            string v1 = "";
            string v2 = "";
            RetornoVerificaLetra doisRetornString = new RetornoVerificaLetra();

            if (letraA != letraB)
            {
                if (colchete)
                {
                    v1 += "[" + letraA;
                    v2 += "[" + letraB;
                    colchete = false;
                }
                else
                {
                    v1 += letraA;
                    v2 += letraB;
                }
            }
            else
            {
                if (!colchete)
                {
                    v1 += "]" + letraA;
                    v2 += "]" + letraB;
                    colchete = true;
                }
                else
                {

                    v1 += letraA;
                    v2 += letraB;

                }
            }
            doisRetornString.valor1 = v1;
            doisRetornString.valor2 = v2;
            doisRetornString.colchete = colchete;
            return doisRetornString;
        }
    }
}
