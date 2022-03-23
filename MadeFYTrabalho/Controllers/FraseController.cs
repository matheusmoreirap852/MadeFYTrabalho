using MadeFYTrabalho.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using static IronPython.Modules._ast;
using System.Text;
using MadeFYTrabalho.BLL;

namespace MadeFYTrabalho.Controllers
{
    public class FraseController : Controller
    {
        private readonly WebAppDbContext _WebAppDbContext;

        public FraseController(WebAppDbContext webAppDbContext)
        {
            _WebAppDbContext = webAppDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _WebAppDbContext.Frases.ToListAsync());
        }

        string retornA = "";
        string retornB = "";
        bool colchete = true;

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

        [HttpGet]
        public IActionResult CriarFrase()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarFrase(Frase frase)
        {

            if (ModelState.IsValid)
            {
               
                if (frase.Texto1.Length > frase.Texto2.Length)
                {
                    for (int i = 0; i < frase.Texto2.Length; i++)
                    {
                        ComparaLetra(frase.Texto1[i].ToString(), frase.Texto2[i].ToString(), retornA, retornB);


                        //Validar se letra 1 != letra 2

                        if (frase.Texto1[i] != frase.Texto2[i])
                        {
                            if (colchete)
                            {
                                retornA += "[" + frase.Texto1[i];
                                retornB += "[" + frase.Texto2[i];
                                colchete = false;
                            }
                            else
                            {
                                retornA = retornA + frase.Texto1[i];
                                retornB = retornB + frase.Texto2[i];
                            }
                        }
                        else
                        {
                            if (!colchete)
                            {
                                retornA = retornA + "]" + frase.Texto1[i];
                                retornB = retornB + "]" + frase.Texto2[i];
                                colchete = true;
                            }
                            else
                            {
                                retornA = retornA + frase.Texto1[i];
                                retornB = retornB + frase.Texto2[i];
                            }
                        }

                    }

                    string seguimentoA = frase.Texto1.Substring(frase.Texto2.Length, frase.Texto1.Length - frase.Texto2.Length);

                    if (!colchete)
                    {
                        retornA += seguimentoA;
                        retornB += "]";
                    }
                    else
                    {
                        retornA += "[" + seguimentoA + "]";
                    }
                }

                else if (frase.Texto1.Length < frase.Texto2.Length)
                {
                    for (int i = 0; i < frase.Texto1.Length; i++)
                    {

                        //Validar se letra 1 != letra 2

                        if (frase.Texto1[i] != frase.Texto2[i])
                        {
                            if (colchete)
                            {
                                retornA += "[" + frase.Texto1[i];
                                retornB += "[" + frase.Texto2[i];
                                colchete = false;
                            }
                            else
                            {
                                retornA = retornA + frase.Texto1[i];
                                retornB = retornB + frase.Texto2[i];
                            }
                        }
                        else
                        {
                            if (!colchete)
                            {
                                retornA = retornA + "]" + frase.Texto1[i];
                                retornB = retornB + "]" + frase.Texto2[i];
                                colchete = true;
                            }
                            else
                            {
                                retornA = retornA + frase.Texto1[i];
                                retornB = retornB + frase.Texto2[i];
                            }
                        }
                    }
                    string seguimentoB = frase.Texto2.Substring(frase.Texto1.Length, frase.Texto2.Length - frase.Texto1.Length);

                    if (!colchete)
                    {
                        retornB += seguimentoB;
                        retornA += "]";
                    }
                    else
                    {
                        retornB += "[" + seguimentoB + "]";
                    }
                }

                else
                {
                    for (int i = 0; i < frase.Texto1.Length; i++)
                    {

                        //validar
                        if (frase.Texto1[i] != frase.Texto2[i])
                        {
                            if (colchete)
                            {
                                retornA += "[" + frase.Texto1[i];
                                retornB += "[" + frase.Texto2[i];
                                colchete = false;
                            }
                            else
                            {
                                retornA = retornA + frase.Texto1[i];
                                retornB = retornB + frase.Texto2[i];
                            }
                        }
                        else
                        {
                            if (!colchete)
                            {
                                retornA = retornA + "]" + frase.Texto1[i];
                                retornB = retornB + "]" + frase.Texto2[i];
                                colchete = true;
                            }
                            else
                            {
                                retornA = retornA + frase.Texto1[i];
                                retornB = retornB + frase.Texto2[i];
                            }
                        }
                    }

                }
                if (!colchete)
                {
                    retornA += "]";
                    retornB += "]";
                }
                frase.Diferenca = "Texto1: " + retornA + " / " + "Texto2: " + retornB;
                frase.DtCadastro = DateTime.Now;
                _WebAppDbContext.Add(frase);
                await _WebAppDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(frase);
        }


        [HttpGet]
        public IActionResult AtualizarFrase(int? id)
        {
            if (id != null)
            {
                Frase frase = _WebAppDbContext.Frases.Find(id);
                return View(frase);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarFrase(int? id, Frase frase)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {

                    string valor;
                    valor = frase.Texto1;
                    frase.Diferenca = frase.Texto1 + frase.Texto2;
                    _WebAppDbContext.Update(frase);
                    await _WebAppDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else return View(frase);
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult ExlcuirFrase(int? id)
        {
            if (id != null)
            {
                Frase frase = _WebAppDbContext.Frases.Find(id);
                return View(frase);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirFrase(int? id, Frase frase)
        {
            if (id != null)
            {
                _WebAppDbContext.Remove(frase);
                await _WebAppDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
