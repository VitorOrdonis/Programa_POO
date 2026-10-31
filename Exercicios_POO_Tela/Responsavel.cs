using System;
using System.Collections.Generic;

namespace Exercicios_POO
{
    internal class Responsavel : Usuario
    {
        private string parentesco;
        private List<Discente> discentesAcompanhados;
        private Dictionary<int, MetaEstudo> metasPorDiscente; // chave: id do discente

        public Responsavel(int id, string nome, string email, string senha, string parentesco)
            : base(id, nome, email, senha)
        {
            this.parentesco = parentesco;
            discentesAcompanhados = new List<Discente>();
            metasPorDiscente = new Dictionary<int, MetaEstudo>();
        }

        public string GetParentesco() { return parentesco; }
        public int GetTotalDiscentes() { return discentesAcompanhados.Count; }

        // Associação: o Discente nasce fora e só é vinculado aqui
        public bool VincularDiscente(Discente d)
        {
            if (d == null || discentesAcompanhados.Contains(d))
            {
                return false;
            }

            discentesAcompanhados.Add(d);
            return true;
        }

        public bool DefinirMeta(Discente d, MetaEstudo meta)
        {
            if (d == null || meta == null || !discentesAcompanhados.Contains(d))
            {
                return false;
            }

            metasPorDiscente[d.GetId()] = meta;
            return true;
        }

        public MetaEstudo ObterMeta(Discente d)
        {
            if (d != null && metasPorDiscente.ContainsKey(d.GetId()))
            {
                return metasPorDiscente[d.GetId()];
            }

            return null;
        }

        public override string ObterTipoPerfil()
        {
            return "Responsável";
        }

        public override string GerarPainelResumo()
        {
            return $"[{ObterTipoPerfil()}] {GetNome()} — Parentesco: {parentesco}";
        }
    }
}