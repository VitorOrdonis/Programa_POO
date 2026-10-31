using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicios_POO
{
    internal class NotificadorEmail : INotificador
    {
        public string ObterCanal()
        {
            return "E-mail";
        }

        public bool EnviarAlerta(string destinatario, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(destinatario) || !destinatario.Contains("@")
                || string.IsNullOrWhiteSpace(mensagem))
            {
                return false;
            }

            Console.WriteLine($"[{ObterCanal()}] Para: {destinatario} | {mensagem}");
            return true;
        }
    }
}
