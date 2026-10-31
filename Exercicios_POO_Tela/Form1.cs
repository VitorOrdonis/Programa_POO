using Exercicios_POO;

namespace Exercicios_POO_Tela
{
    public partial class Form1 : Form
    {
        // ----- Objetos do domínio (criados aqui, fora das classes) -----
        private Discente discente = new Discente(3, "Ana Lima", "ana@email.com", "aluno789", "26028722");
        private Responsavel responsavel = new Responsavel(2, "João Lima", "joao@email.com", "resp456", "Pai");
        private MetaEstudo meta = new MetaEstudo(300);
        private ServicoAlertaResponsavel servico = new ServicoAlertaResponsavel();
        private INotificador notificador = new NotificadorPainel();
        private List<Disciplina> disciplinas = new List<Disciplina>();

        // ----- Integração com o backend -----
        private readonly ClienteBackendEstudo _cliente = new ClienteBackendEstudo();
        private readonly Button btnCarregarHistorico = new Button();

        public Form1()
        {
            InitializeComponent();
        }

        // Roda uma vez, quando a janela abre
        private void Form1_Load(object sender, EventArgs e)
        {
            // Disciplinas da Missão 1
            disciplinas.Add(new Disciplina("ADS201", "Programação Orientada a Objetos", "Computação", 4));
            disciplinas.Add(new Disciplina("ADS202", "Banco de Dados", "Computação", 4));
            disciplinas.Add(new Disciplina("ADS203", "Engenharia de Software", "Gestão", 2));

            foreach (Disciplina d in disciplinas)
            {
                cmbDisciplina.Items.Add(d.GetNome());
            }
            cmbDisciplina.SelectedIndex = 0;

            cmbModalidade.Items.Add("Pomodoro");
            cmbModalidade.Items.Add("Exercicios");
            cmbModalidade.Items.Add("Leitura");
            cmbModalidade.SelectedIndex = 0;

            // Associação: o responsável acompanha o discente
            responsavel.VincularDiscente(discente);
            responsavel.DefinirMeta(discente, meta);

            CriarBotaoHistorico();   // cria o botão do servidor
            AtualizarTela();
        }

        // Mostra só os campos da modalidade escolhida
        private void cmbModalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModalidade.Text == "Pomodoro")
            {
                lblExtra.Text = "Ciclos completos:";
                lblQuestoes.Visible = false;
                numQuestoes.Visible = false;
                chkResumo.Visible = false;
            }
            else if (cmbModalidade.Text == "Exercicios")
            {
                lblExtra.Text = "Acertos:";
                lblQuestoes.Visible = true;
                numQuestoes.Visible = true;
                chkResumo.Visible = false;
            }
            else
            {
                lblExtra.Text = "Páginas lidas:";
                lblQuestoes.Visible = false;
                numQuestoes.Visible = false;
                chkResumo.Visible = true;
            }
        }

        // O clique só lê a tela e pede para os objetos calcularem. Nada de fórmula aqui!
        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            Disciplina disciplina = disciplinas[cmbDisciplina.SelectedIndex];
            int minutos = (int)numDuracao.Value;
            int extra = (int)numExtra.Value;
            SessaoEstudo sessao;

            if (cmbModalidade.Text == "Pomodoro")
            {
                sessao = new SessaoPomodoro(disciplina, minutos, extra);
            }
            else if (cmbModalidade.Text == "Exercicios")
            {
                if (extra > (int)numQuestoes.Value)
                {
                    MessageBox.Show("Os acertos não podem ser maiores que o total de questões.");
                    return;
                }
                sessao = new SessaoExercicios(disciplina, minutos, (int)numQuestoes.Value, extra);
            }
            else
            {
                sessao = new SessaoLeitura(disciplina, minutos, extra, chkResumo.Checked);
            }

            if (meta.RegistrarAvanco(minutos) == false)
            {
                MessageBox.Show("Duração inválida: use de 1 a 480 minutos.");
                return;
            }

            discente.RegistrarEstudo(sessao);
            listBoxHistorico.Items.Add(sessao.GerarFeedback());
            AtualizarTela();

            // Envia a sessão concluída para o backend (POST)
            await EnviarSessaoAsync(disciplina.GetNome(), minutos, extra);
        }

        private void btnNotificar_Click(object sender, EventArgs e)
        {
            servico.AvaliarDiscente(discente, meta, responsavel, notificador);
        }

        // Atualiza cabeçalho e barra de progresso
        private void AtualizarTela()
        {
            lblDiscente.Text = discente.GerarPainelResumo();
            lblResponsavel.Text = responsavel.GerarPainelResumo();

            progressBar1.Value = (int)meta.CalcularPercentual();
            lblProgresso.Text = $"Meta semanal: {meta.GetMinutosCumpridos()}/{meta.GetMetaMinutosSemana()} min ({meta.CalcularPercentual():F1}%)";
        }

        // ===== Integração com o backend =====

        private void CriarBotaoHistorico()
        {
            btnCarregarHistorico.Text = "Carregar Histórico do Servidor";
            btnCarregarHistorico.Location = new Point(320, 365);
            btnCarregarHistorico.Size = new Size(200, 26);
            btnCarregarHistorico.Click += btnCarregarHistorico_Click;
            Controls.Add(btnCarregarHistorico);
        }

        // GET: busca as sessões gravadas e mostra na ListBox
        private async void btnCarregarHistorico_Click(object? sender, EventArgs e)
        {
            try
            {
                string json = await _cliente.ObterSessoesAsync();
                listBoxHistorico.Items.Clear();

                using var doc = System.Text.Json.JsonDocument.Parse(json);
                foreach (var item in doc.RootElement.EnumerateArray())
                {
                    listBoxHistorico.Items.Add(item.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar do servidor.\n" + ex.Message);
            }
        }

        // POST: envia a sessão que acabou de ser registrada
        private async Task EnviarSessaoAsync(string nomeDisciplina, int minutos, int extra)
        {
            try
            {
                // Nomes dos campos exigidos pela API: discenteNome, disciplina, duracaoMinutos
                var sessao = new
                {
                    discenteNome = "Ana Lima",
                    disciplina = nomeDisciplina,
                    modalidade = cmbModalidade.Text,
                    duracaoMinutos = minutos,
                    extra = extra,
                    questoes = (int)numQuestoes.Value,
                    fezResumo = chkResumo.Checked
                };

                string? erro = await _cliente.RegistrarSessaoAsync(sessao);
                if (erro != null)
                    MessageBox.Show("O servidor recusou a sessão.\n" + erro);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Backend offline. Rode o iniciar_backend.bat.");
            }
        }

        // Classe que conversa com a API (a "dependência" do formulário)
        private class ClienteBackendEstudo
        {
            private static readonly HttpClient _http = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5080"),
                Timeout = TimeSpan.FromSeconds(10)
            };

            // Devolve null se deu certo, ou o texto do erro se o servidor recusou
            public async Task<string?> RegistrarSessaoAsync(object sessao)
            {
                string json = System.Text.Json.JsonSerializer.Serialize(sessao);
                using var conteudo = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage resposta = await _http.PostAsync("/api/sessoes", conteudo);

                if (resposta.IsSuccessStatusCode)
                    return null;

                string corpo = await resposta.Content.ReadAsStringAsync();
                return "Código " + (int)resposta.StatusCode + ": " + corpo;
            }

            public async Task<string> ObterSessoesAsync()
            {
                return await _http.GetStringAsync("/api/sessoes");
            }

            public async Task<string> ObterRelatorioAsync(string nomeDiscente)
            {
                return await _http.GetStringAsync("/api/relatorio/" + Uri.EscapeDataString(nomeDiscente));
            }
        }

        // Métodos vazios que o Designer pede (cliques acidentais nos labels).
        // Não fazem nada, só existem para o projeto compilar.
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label1_Click_2(object sender, EventArgs e) { }
    }
}