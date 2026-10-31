using System;

namespace Exercicios_POO
{
    internal class ServicoAlertaResponsavel
    {
        // Dependência: não guarda nada, só usa os objetos que chegam por parâmetro
        public bool AvaliarDiscente(Discente d, MetaEstudo meta, Responsavel resp, INotificador notificador)
        {
            double percentual = meta.CalcularPercentual();
            string mensagem;

            if (percentual >= 100.0)
            {
                mensagem = $"Parabéns! {d.GetNome()} atingiu a meta semanal de estudos ({meta.GetMetaMinutosSemana()} min)!";
            }
            else
            {
                mensagem = $"{d.GetNome()} está com {percentual:F1}% da meta semanal ({meta.GetMinutosCumpridos()}/{meta.GetMetaMinutosSemana()} min).";
            }

            return notificador.EnviarAlerta(resp.GetEmail(), mensagem);
        }
    }
}