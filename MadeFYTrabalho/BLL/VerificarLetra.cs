using System;

namespace MadeFYTrabalho.BLL
{
    public class VerificarLetra
    {

        public void ComparaLetra(string letraA, string letraB, string retornA, string retornB)
        {
            
            bool colchete = true;

            if (letraA != letraB)
            {
                if (colchete)
                {
                    retornA += "[" + letraA;
                    retornB += "[" + letraB;
                    colchete = false;
                }
                else
                {
                    retornA += letraA;
                    retornB += letraB;
                }
                if (!colchete)
                {
                    retornA += "]" + letraA;
                    retornB += "]" + letraB;
                    colchete = true;
                }
                else
                {

                    retornA = retornA + letraA;
                    retornB = retornB + letraB;
                }
            }
            
        }
    }
}
