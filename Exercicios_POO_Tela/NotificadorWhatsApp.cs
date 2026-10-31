using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicios_POO
{
    internal class NotificadorWhatsApp : INotificador
    {
        public string ObterCanal()
        {
            return "WhatsApp";
        }

        public bool EnviarAlerta(string destinatario, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(destinatario) || destinatario.Length < 10
                || string.IsNullOrWhiteSpace(mensagem))
            {
                return false;
            }

            Console.WriteLine($"[{ObterCanal()}] Para: {destinatario} | {mensagem}");
            return true;
        }
    }
}