using System;
using System.Collections.Generic;

namespace Exercicios_POO
{
    internal class Discente : Usuario
    {
        private string ra;
        private int xpTotal;
        private List<SessaoEstudo> historico;

        public Discente(int id, string nome, string email, string senha, string ra)
            : base(id, nome, email, senha)
        {
            this.ra = ra;
            xpTotal = 0;
            historico = new List<SessaoEstudo>();
        }

        public string GetRa() { return ra; }
        public int GetXpTotal() { return xpTotal; }
        public int GetTotalSessoes() { return historico.Count; }

        public void AdicionarXp(int pontos)
        {
            if (pontos > 0)
            {
                xpTotal += pontos;
            }
        }

        // Forma 1: recebe a sessão pronta
        public void RegistrarEstudo(SessaoEstudo sessao)
        {
            historico.Add(sessao);
            xpTotal += sessao.CalcularXp();
        }

        // Forma 2: atalho rápido (Pomodoro padrão)
        public void RegistrarEstudo(Disciplina d, int minutos)
        {
            int ciclos = minutos / 25;
            if (ciclos < 1)
            {
                ciclos = 1;
            }

            SessaoPomodoro sessao = new SessaoPomodoro(d, minutos, ciclos);
            RegistrarEstudo(sessao);
        }

        // Forma 3: por horário (Leitura com resumo)
        public void RegistrarEstudo(Disciplina d, int horaInicio, int horaFim, int paginasLidas)
        {
            int minutos = (horaFim - horaInicio) * 60;

            SessaoLeitura sessao = new SessaoLeitura(d, minutos, paginasLidas, true);
            RegistrarEstudo(sessao);
        }

        public override string ObterTipoPerfil()
        {
            return "Discente";
        }

        public override string GerarPainelResumo()
        {
            return $"[{ObterTipoPerfil()}] {GetNome()} — RA: {ra} | XP: {xpTotal}";
        }
    }
}