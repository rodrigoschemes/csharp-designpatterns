using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace csharp_designpatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            FacadeSingleton();
        }

        /// <summary>
        /// FACADE: serve como uma frente única para os serviços disponibilizados por um ou mais sub-sistemas.
        /// SINGLETON: possibilita que o usuário crie uma instância global para determinado objeto
        /// </summary>
        private static void FacadeSingleton()
        {
            EmpresaFacade fachada = new EmpresaFacadeSingleton().Instancia;

            String cpf = "12345678-11";
            Cliente cliente = new EmpresaFacade().BuscaCliente(cpf);

            double valor = 500;
            Fatura fatura = new EmpresaFacade().CriaFatura(cliente, valor);

            Cobranca cobranca = new EmpresaFacade().GeraCobranca(fatura);
            cobranca.Emite();

            ContatoCliente contato = new EmpresaFacade().FazContato(cliente, cobranca);
            contato.Dispara();
        }

        /// <summary>
        /// COMMAND: A ideia é criar uma fila de comandos a serem executados em momento posterior
        /// </summary>
        private static void Command()
        {
            Pedido pedido1 = new Pedido("Mauricio", 150.0);
            Pedido pedido2 = new Pedido("Marcelo", 250.0);

            FilaDeTrabalho fila = new FilaDeTrabalho();

            fila.Adiciona(new PagaPedido(pedido1));
            fila.Adiciona(new PagaPedido(pedido2));
            fila.Adiciona(new FinalizaPedido(pedido1));

            fila.Processa();
        }

        /// <summary>
        /// ADAPTER: Adaptar a interface de um sistema antigo para se adaptar ao novo
        /// </summary>
        private static void Adapter()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "victor";
            cliente.Endereco = "Rua Vergueiro";
            cliente.DataDeNascimento = DateTime.Now;

            GeradorDeXml gerador = new GeradorDeXml();
            String xml = gerador.GeraXml(cliente);

            Console.WriteLine(xml);
        }

        /// <summary>
        /// INTERPRETER: Trabalhar com estrutura de dados
        /// </summary>
        private static void Interpreter()
        {
            IExpressao esquerda = new Subtracao(new Numero(10), new Numero(5));
            IExpressao direita = new Soma(new Numero(2), new Numero(10));

            IExpressao conta = new Soma(esquerda, direita);

            int resultado = conta.Avalia();
            Console.WriteLine($"Expressão: (10 - 5) + (2 + 10) = {resultado}");

            Expression soma = Expression.Add(Expression.Constant(10), Expression.Constant(20)); // 10 + 20
            Func<int> interpreter = Expression.Lambda<Func<int>>(soma).Compile();
            int resultado2 = interpreter();

            Console.WriteLine($"Expressão: (10 + 20) = {resultado2}");
        }

        /// <summary>
        /// MEMENTO: Permite Salvar e Restaurar o estado de objetos
        /// </summary>
        private static void Memento()
        {
            Historico historico = new Historico();

            Contrato contrato = new Contrato(DateTime.Now, "Mauricio", TipoContrato.Novo);
            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.WriteLine(historico);
        }

        /// <summary>
        /// FLYWEIGHT: Garantir que haja uma instância de vários elementos
        /// </summary>
        private static void Flyweight()
        {
            NotasMusicais notas = new NotasMusicais();

            IList<INota> musica = new List<INota>() {
                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("mi"),
                notas.Pega("fa"),
                notas.Pega("fa"),
                notas.Pega("fa"),

                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("re"),
                notas.Pega("re"),

                notas.Pega("do"),
                notas.Pega("sol"),
                notas.Pega("fa"),
                notas.Pega("mi"),
                notas.Pega("mi"),
                notas.Pega("mi"),

                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("mi"),
                notas.Pega("fa"),
                notas.Pega("fa"),
                notas.Pega("fa")
            };

            Piano piano = new Piano();
            piano.Toca(musica);
        }

        /// <summary>
        /// FACTORY: Semelhante ao Builder mas não precisa de muitas informações para criar o objeto
        /// </summary>
        private static void Factory()
        {
            ProdutoDAO dao = new ProdutoDAO();
            IList<Produto> produtos = new List<Produto>();

            produtos = dao.Produtos();
            
            foreach(Produto p in produtos)
            {
                Console.WriteLine(p);
            }
        }

        /// <summary>
        /// OBSERVER: permite que diversas ações sejam executadas de forma transparente à classe principal
        /// </summary>
        private static void Observer()
        {
            NotaFiscalBuilder builder = new NotaFiscalBuilder();

            builder
                .ParaEmpresa("Caelum Ensino e Inovação")
                .ComCnpj("23.456.789/0001-12")
                .ComItem(new ItemDaNota("Carro", 100))
                .ComItem(new ItemDaNota("Bike", 200))
                .NaDataAtual()
                .ComObservacao("Teste de Nota Fiscal");

            builder.AdicionaAcao(new EnviadorDeEmail());
            builder.AdicionaAcao(new NotaFiscalDao());
            builder.AdicionaAcao(new EnviadorDeSms());
            builder.AdicionaAcao(new Impressora());

            NotaFiscal nf = builder.Constroi();

            Console.ReadKey();
        }

        /// <summary>
        /// BUILDER: Facilita criação de classes com construtores grandes e complexos
        /// </summary>
        private static void Builder()
        {
            NotaFiscalBuilder builder = new NotaFiscalBuilder();

            builder
                .ParaEmpresa("Caelum Ensino e Inovação")
                .ComCnpj("23.456.789/0001-12")
                .ComItem(new ItemDaNota("Carro", 100))
                .ComItem(new ItemDaNota("Bike", 200))
                .NaDataAtual()
                .ComObservacao("Teste de Nota Fiscal");

            NotaFiscal nf = builder.Constroi();

            Console.WriteLine(nf);
            Console.ReadKey();
        }

        /// <summary>
        /// STATE: Auxilia no controle de estados do objeto
        /// </summary>
        private static void State()
        {
            Orcamento reforma = new Orcamento(500);
            Console.WriteLine(reforma.Valor);

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Aprova();
            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Finaliza();

            Console.ReadKey();
        }

        /// <summary>
        /// DECORATOR: comportamentos que podem ser compostos por outras classes envolvidas em uma mesma hierarquia
        /// </summary>
        private static void Decorator()
        {
            Imposto issComposto = new ISS(new ICMS());
            Imposto issSimples = new ISS();
            Orcamento orcamento = new Orcamento(500.0);

            Console.WriteLine($"ISS Simples.: {issSimples.Calcula(orcamento)}");
            Console.WriteLine($"ISS Composto: {issComposto.Calcula(orcamento)}");
        }

        /// <summary>
        /// TEMPLATE: Estruturas similares mas algoritmos diferentes
        /// </summary>
        private static void TemplateRelatorios()
        {
            IList<Conta> contas = new List<Conta>();
            Conta c1 = new Conta("Rodrigo", 100, 123, 456);
            Conta c2 = new Conta("Roberta", 200, 321, 654);
            Conta c3 = new Conta("Raul", 300, 987, 789);

            contas.Add(c1);
            contas.Add(c2);
            contas.Add(c3);

            Relatorio relSimples = new RelatorioSimples();
            Relatorio relComplexo = new RelatorioComplexo();

            relSimples.Imprime(contas);
            relComplexo.Imprime(contas);
        }

        /// <summary>
        /// TEMPLATE: Estruturas similares mas algoritmos diferentes
        /// </summary>
        private static void TemplateImpostos()
        {
            Imposto ikcv = new IKCV();
            Imposto icpp = new ICPP();

            Orcamento orcamento = new Orcamento(500.0);
            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            Console.WriteLine($"IKCV......: {calculador.RealizaCalculo(orcamento, ikcv)}");
            Console.WriteLine($"ICPP.....: {calculador.RealizaCalculo(orcamento, icpp)}");

            Console.ReadKey();
        }

        /// <summary>
        /// CHAIN OF RESPONSIBILITY: Decisões encadeadas, há uma regra do fluxo de decisões caso o anterior não satisfaça a condição
        /// </summary>
        private static void ChainOfResponsibility()
        {
            CalculadorDeDescontos calculador = new CalculadorDeDescontos();
            Orcamento orcamento = new Orcamento(500);
            orcamento.AdicionaItem(new Item("CANETA", 250));
            orcamento.AdicionaItem(new Item("LAPIS", 250));

            double desconto = calculador.Calcula(orcamento);
            Console.WriteLine($"Desconto aplicado: {desconto}");

            Console.ReadKey();
        }

        /// <summary>
        /// STRATEGY: Aplicar em regra de negócio com interfaces similares para eliminar a necessidade de If's
        /// </summary>
        private static void Strategy()
        {
            Imposto iss = new ISS();
            Imposto icms = new ICMS();
            Imposto iccc = new ICCC();

            Orcamento orcamento = new Orcamento(500.0);
            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            Console.WriteLine($"ISS......: {calculador.RealizaCalculo(orcamento, iss)}");
            Console.WriteLine($"ICMS.....: {calculador.RealizaCalculo(orcamento, icms)}");
            Console.WriteLine($"ICCC.....: {calculador.RealizaCalculo(orcamento, iccc)}");

            Console.ReadKey();
        }
    }
}
