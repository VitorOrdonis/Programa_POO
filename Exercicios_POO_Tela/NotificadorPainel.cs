using System;
using System.Windows.Forms;

namespace Exercicios_POO
{
    internal class NotificadorPainel : INotificador
    {
        public string ObterCanal()
        {
            return "Painel";
        }

        public bool EnviarAlerta(string destinatario, string mensagem)
        {
            MessageBox.Show($"Para: {destinatario}\n\n{mensagem}", "Alerta");
            return true;
        }
    }
}