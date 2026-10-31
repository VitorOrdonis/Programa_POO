using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicios_POO
{
    using System;
    using System.Collections.Generic;

    namespace Exercicios_POO
    {
        internal class PlanoEstudo
        {
            private List<ItemCronograma> itens;

            public PlanoEstudo()
            {
                itens = new List<ItemCronograma>();
            }

            // Composição: recebe só dados primitivos e cria o item aqui dentro
            public bool AdicionarItem(string diaSemana, int minutos)
            {
                if (string.IsNullOrWhiteSpace(diaSemana) || minutos <= 0)
                {
                    return false;
                }

                itens.Add(new ItemCronograma(diaSemana, minutos));
                return true;
            }

            public int GetTotalItens()
            {
                return itens.Count;
            }

            public int CalcularMinutosTotais()
            {
                int total = 0;
                foreach (ItemCronograma item in itens)
                {
                    total += item.GetMinutosPlanejados();
                }
                return total;
            }

            // Devolve texto, nunca a lista nem os itens
            public string GerarResumo()
            {
                string resumo = "";
                foreach (ItemCronograma item in itens)
                {
                    resumo += $"{item.GetDiaSemana()}: {item.GetMinutosPlanejados()} min\n";
                }
                return resumo + $"Total: {CalcularMinutosTotais()} min";
            }
        }
    }
}