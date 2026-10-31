using System;

namespace Exercicios_POO
{
    internal abstract class SessaoEstudo : IExportavelJson
    {
        private Disciplina disciplina;
        private int duracaoMinutos;

        protected SessaoEstudo(Disciplina disciplina, int duracaoMinutos)
        {
            this.disciplina = disciplina;
            this.duracaoMinutos = duracaoMinutos;
        }

        public Disciplina GetDisciplina() { return disciplina; }
        public int GetDuracaoMinutos() { return duracaoMinutos; }

        public abstract string ObterModalidade();
        public abstract int CalcularXp();
        public abstract string ParaJson(); // contrato da interface, cada filha completa

        public virtual string GerarFeedback()
        {
            return $"{ObterModalidade()} em {disciplina.GetNome()} ({duracaoMinutos} min) -> +{CalcularXp()} XP";
        }

        // Monta os campos comuns; as filhas só passam os campos extras
        protected string MontarJson(string camposExtras)
        {
            return $"{{\"modalidade\":\"{ObterModalidade()}\",\"disciplina\":\"{disciplina.GetNome()}\",\"duracaoMinutos\":{duracaoMinutos},\"xp\":{CalcularXp()},{camposExtras}}}";
        }
    }
}