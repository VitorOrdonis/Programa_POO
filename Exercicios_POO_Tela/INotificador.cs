using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicios_POO
{
    public interface INotificador
    {
        string ObterCanal();
        bool EnviarAlerta(string destinatario, string mensagem);
    }
}