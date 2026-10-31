using Exercicios_POO.Exercicios_POO;
using System;
using System.Collections.Generic;

namespace Exercicios_POO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Missão 1
            Disciplina d1 = new Disciplina("ADS201", "Programação Orientada a Objetos", "Computação", 4);
            Disciplina d2 = new Disciplina("ADS202", "Banco de Dados", "Computação", 4);
            Disciplina d3 = new Disciplina("ADS203", "Engenharia de Software", "Gestão", -4); // vira 2h

            Console.WriteLine(d1.ExibirResumo());
            Console.WriteLine(d2.ExibirResumo());
            Console.WriteLine(d3.ExibirResumo());

            // Missão 2
            Console.WriteLine();
            MetaEstudo meta = new MetaEstudo(100);

            Console.WriteLine($"RegistrarAvanco(-20): {meta.RegistrarAvanco(-20)}");
            Console.WriteLine($"RegistrarAvanco(900): {meta.RegistrarAvanco(900)}");
            Console.WriteLine($"Minutos cumpridos: {meta.GetMinutosCumpridos()}");
            Console.WriteLine($"RegistrarAvanco(60): {meta.RegistrarAvanco(60)}");
            Console.WriteLine($"Percentual: {meta.CalcularPercentual()}%");

            // Missão 3
            Console.WriteLine();
            Administrador adm = new Administrador(1, "Marta Souza", "marta@escola.com", "adm123", "Coordenação PI");
            Responsavel resp = new Responsavel(2, "João Lima", "joao@email.com", "resp456", "Pai");
            Discente aluno = new Discente(3, "Ana Lima", "ana@email.com", "aluno789", "26028722");

            aluno.AdicionarXp(150);

            Console.WriteLine(adm.GerarPainelResumo());
            Console.WriteLine(resp.GerarPainelResumo());
            Console.WriteLine(aluno.GerarPainelResumo());
            Console.WriteLine($"Senha certa: {aluno.Autenticar("aluno789")}");
            Console.WriteLine($"Senha errada: {aluno.Autenticar("0000")}");

            // Missão 4
            Console.WriteLine();
            List<SessaoEstudo> sessoes = new List<SessaoEstudo>();
            sessoes.Add(new SessaoPomodoro(d1, 50, 2));
            sessoes.Add(new SessaoExercicios(d2, 40, 10, 8));
            sessoes.Add(new SessaoLeitura(d3, 30, 12, true));

            int xpTotal = 0;
            foreach (SessaoEstudo sessao in sessoes)
            {
                Console.WriteLine(sessao.GerarFeedback());
                xpTotal += sessao.CalcularXp();
            }

            Console.WriteLine($"XP total: {xpTotal}");
            // Missão 5
            Console.WriteLine();
            Discente aluno2 = new Discente(4, "Pedro Alves", "pedro@email.com", "pedro123", "26028999");

            // Forma 1: sessão pronta
            aluno2.RegistrarEstudo(new SessaoExercicios(d2, 40, 10, 8));   // +120 XP

            // Forma 2: atalho rápido (50 min -> 2 ciclos)
            aluno2.RegistrarEstudo(d1, 50);                                // +130 XP

            // Forma 3: por horário (14h às 16h = 120 min, 10 páginas)
            aluno2.RegistrarEstudo(d3, 14, 16, 10);                        // +175 XP

            Console.WriteLine(aluno2.GerarPainelResumo());
            Console.WriteLine($"Sessões no histórico: {aluno2.GetTotalSessoes()}");

            // Missão 6
            Console.WriteLine();
            List<INotificador> canais = new List<INotificador>();
            canais.Add(new NotificadorEmail());
            canais.Add(new NotificadorWhatsApp());

            foreach (INotificador canal in canais)
            {
                string destino = canal.ObterCanal() == "E-mail" ? "marta@escola.com" : "11999998888";
                canal.EnviarAlerta(destino, "Meta semanal cumprida!");
            }

            Console.WriteLine($"E-mail inválido: {new NotificadorEmail().EnviarAlerta("invalido", "Oi")}"); // False

            Console.WriteLine();
            MetaEstudo metaJson = new MetaEstudo(100);
            metaJson.RegistrarAvanco(60);

            List<IExportavelJson> exportaveis = new List<IExportavelJson>();
            exportaveis.Add(metaJson);
            exportaveis.Add(new SessaoPomodoro(d1, 50, 2));
            exportaveis.Add(new SessaoExercicios(d2, 40, 10, 8));
            exportaveis.Add(new SessaoLeitura(d3, 30, 12, true));

            foreach (IExportavelJson item in exportaveis)
            {
                Console.WriteLine(item.ParaJson());
            }

            // Missão 7
            Console.WriteLine();

            // Associação: Responsavel ——> Discente
            Console.WriteLine($"Vincular aluno: {resp.VincularDiscente(aluno)}");     // True
            Console.WriteLine($"Vincular aluno2: {resp.VincularDiscente(aluno2)}");   // True
            Console.WriteLine($"Vincular aluno de novo: {resp.VincularDiscente(aluno)}"); // False
            Console.WriteLine($"Discentes de {resp.GetNome()}: {resp.GetTotalDiscentes()}"); // 2

            resp.DefinirMeta(aluno, new MetaEstudo(300));
            Console.WriteLine($"Meta do aluno: {resp.ObterMeta(aluno).GetMetaMinutosSemana()} min/semana"); // 300

            // Agregação: TrilhaEstudo ◇── Disciplina
            TrilhaEstudo trilha1 = new TrilhaEstudo("Trilha ADS - 1º Semestre", adm);
            trilha1.AdicionarDisciplina(d1);
            trilha1.AdicionarDisciplina(d2);
            trilha1.AdicionarDisciplina(d3);

            TrilhaEstudo trilha2 = new TrilhaEstudo("Trilha de Reforço", adm);
            trilha2.AdicionarDisciplina(d1); // a mesma disciplina em duas trilhas
            trilha2.AdicionarDisciplina(d3);

            Console.WriteLine($"{trilha1.GetTitulo()}: {trilha1.CalcularCargaHorariaTotal()}h/semana ({trilha1.GetTotalDisciplinas()} disciplinas)");
            Console.WriteLine($"{trilha2.GetTitulo()}: {trilha2.CalcularCargaHorariaTotal()}h/semana ({trilha2.GetTotalDisciplinas()} disciplinas)");
            Console.WriteLine($"Responsável pela trilha: {trilha1.GetResponsavel().GetNome()}");

            // Missão 8
            Console.WriteLine();

            // Composição: PlanoEstudo ◆── ItemCronograma
            PlanoEstudo plano = new PlanoEstudo();
            plano.AdicionarItem("Segunda", 60);
            plano.AdicionarItem("Quarta", 90);
            Console.WriteLine($"Item inválido (minutos negativos): {plano.AdicionarItem("Sexta", -10)}"); // False
            Console.WriteLine($"Item inválido (dia vazio): {plano.AdicionarItem("", 30)}");                // False
            Console.WriteLine(plano.GerarResumo());

            // Dependência: ServicoAlertaResponsavel - - -> Discente, MetaEstudo, INotificador
            Console.WriteLine();
            ServicoAlertaResponsavel servico = new ServicoAlertaResponsavel();
            MetaEstudo metaAluno = new MetaEstudo(100);

            metaAluno.RegistrarAvanco(60);
            servico.AvaliarDiscente(aluno, metaAluno, resp, new NotificadorEmail());

            metaAluno.RegistrarAvanco(50);
            servico.AvaliarDiscente(aluno, metaAluno, resp, new NotificadorWhatsApp());
        }
    }
}

