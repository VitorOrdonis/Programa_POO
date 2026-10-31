using System;
using System.Globalization;

namespace Exercicios_POO
{
    internal class MetaEstudo : IExportavelJson
    {
        private int metaMinutosSemana;
        private int minutosCumpridos;

        public MetaEstudo(int metaMinutosSemana)
        {
            minutosCumpridos = 0;
            RedefinirMeta(metaMinutosSemana); // reaproveita a validação
        }

        public int GetMetaMinutosSemana() { return metaMinutosSemana; }
        public int GetMinutosCumpridos() { return minutosCumpridos; }

        // Usado pelo Responsável
        public void RedefinirMeta(int novaMeta)
        {
            if (novaMeta < 30)
            {
                metaMinutosSemana = 30;
            }
            else if (novaMeta > 3000)
            {
                metaMinutosSemana = 3000;
            }
            else
            {
                metaMinutosSemana = novaMeta;
            }
        }

        // Única forma de somar minutos cumpridos
        public bool RegistrarAvanco(int minutos)
        {
            if (minutos <= 0 || minutos > 480)
            {
                return false;
            }

            minutosCumpridos += minutos;
            return true;
        }

        public double CalcularPercentual()
        {
            double percentual = (double)minutosCumpridos / metaMinutosSemana * 100.0;
            return percentual > 100.0 ? 100.0 : percentual;
        }

        public bool EstaCumprida()
        {
            return minutosCumpridos >= metaMinutosSemana;
        }

        public string ParaJson()
        {
            string percentual = CalcularPercentual().ToString("F1", CultureInfo.InvariantCulture);
            string cumprida = EstaCumprida() ? "true" : "false";

            return $"{{\"metaMinutosSemana\":{metaMinutosSemana},\"minutosCumpridos\":{minutosCumpridos},\"percentual\":{percentual},\"cumprida\":{cumprida}}}";
        }
    }
}