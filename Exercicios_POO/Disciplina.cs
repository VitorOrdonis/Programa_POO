using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicios_POO
{
    internal class Disciplina
    {
        private string codigo;
        private string nome;
        private string categoria;
        private int cargaHorariaSemanalHoras;

        public Disciplina(string codigo, string nome, string categoria, int cargaHorariaSemanalHoras)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.categoria = categoria;
            this.cargaHorariaSemanalHoras = cargaHorariaSemanalHoras <= 0 ? 2 : cargaHorariaSemanalHoras;
        }

        public string GetCodigo() { return codigo; }
        public string GetNome() { return nome; }
        public string GetCategoria() { return categoria; }
        public int GetCargaHorariaSemanalHoras() { return cargaHorariaSemanalHoras; }

        public int CalcularCargaEmMinutos()
        {
            return cargaHorariaSemanalHoras * 60;
        }

        public string ExibirResumo()
        {
            return $"[{codigo}] {nome} ({categoria}) — {cargaHorariaSemanalHoras}h/semana ({CalcularCargaEmMinutos()} min)";
        }
    }
}
