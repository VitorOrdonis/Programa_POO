using System;
using System.Collections.Generic;

namespace Exercicios_POO
{
    internal class TrilhaEstudo
    {
        private string titulo;
        private Administrador responsavel;     // associação
        private List<Disciplina> disciplinas;  // agregação

        public TrilhaEstudo(string titulo, Administrador responsavel)
        {
            this.titulo = titulo;
            this.responsavel = responsavel;
            disciplinas = new List<Disciplina>();
        }

        public string GetTitulo() { return titulo; }
        public Administrador GetResponsavel() { return responsavel; }
        public int GetTotalDisciplinas() { return disciplinas.Count; }

        // A disciplina nasce fora da trilha e só é recebida aqui
        public void AdicionarDisciplina(Disciplina d)
        {
            if (d != null && !disciplinas.Contains(d))
            {
                disciplinas.Add(d);
            }
        }

        public int CalcularCargaHorariaTotal()
        {
            int total = 0;
            foreach (Disciplina d in disciplinas)
            {
                total += d.GetCargaHorariaSemanalHoras();
            }
            return total;
        }
    }
}