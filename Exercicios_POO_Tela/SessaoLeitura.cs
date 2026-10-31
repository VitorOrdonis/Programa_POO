using System;

namespace Exercicios_POO
{
    internal class SessaoLeitura : SessaoEstudo
    {
        private int paginasLidas;
        private bool fezResumo;

        public SessaoLeitura(Disciplina disciplina, int duracaoMinutos, int paginasLidas, bool fezResumo)
            : base(disciplina, duracaoMinutos)
        {
            this.paginasLidas = paginasLidas;
            this.fezResumo = fezResumo;
        }

        public override string ObterModalidade()
        {
            return "Leitura";
        }

        public override int CalcularXp()
        {
            return GetDuracaoMinutos() + (paginasLidas * 3) + (fezResumo ? 25 : 0);
        }

        public override string ParaJson()
        {
            return MontarJson($"\"paginasLidas\":{paginasLidas},\"fezResumo\":{(fezResumo ? "true" : "false")}");
        }
    }
}