using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicios_POO
{
    using System;

    namespace Exercicios_POO
    {
        internal class ItemCronograma
        {
            private string diaSemana;
            private int minutosPlanejados;

            public ItemCronograma(string diaSemana, int minutosPlanejados)
            {
                this.diaSemana = diaSemana;
                this.minutosPlanejados = minutosPlanejados;
            }

            public string GetDiaSemana() { return diaSemana; }
            public int GetMinutosPlanejados() { return minutosPlanejados; }
        }
    }
}