using System;

namespace Exercicios_POO
{
    internal class SessaoExercicios : SessaoEstudo
    {
        private int totalQuestoes;
        private int acertos;

        public SessaoExercicios(Disciplina disciplina, int duracaoMinutos, int totalQuestoes, int acertos)
            : base(disciplina, duracaoMinutos)
        {
            this.totalQuestoes = totalQuestoes;
            this.acertos = acertos;
        }

        public override string ObterModalidade()
        {
            return "Exercícios";
        }

        public override int CalcularXp()
        {
            return GetDuracaoMinutos() + (acertos * 10);
        }

        public override string GerarFeedback()
        {
            double porcentagem = totalQuestoes > 0 ? (double)acertos / totalQuestoes * 100.0 : 0.0;
            return base.GerarFeedback() + $" | Acerto: {porcentagem:F1}% ({acertos}/{totalQuestoes})";
        }

        public override string ParaJson()
        {
            return MontarJson($"\"totalQuestoes\":{totalQuestoes},\"acertos\":{acertos}");
        }
    }
}