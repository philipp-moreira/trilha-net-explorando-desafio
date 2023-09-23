namespace DesafioProjetoHospedagem.Models
{
    public class Reserva : IReserva
    {
        private const decimal PERCENTUAL_DESCONTO = 0.10M;

        public uint DiasReservados { get; private set; }
        public Suite Suite { get; private set; }
        public IEnumerable<Pessoa> Hospedes { get; private set; }

        public Reserva(uint diasReservados)
        {
            DiasReservados = diasReservados;
        }

        /// <inheritdoc/>
        public void CadastrarHospedes(IEnumerable<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido

            _ = ValidarListaHospede(hospedes.ToList().AsReadOnly());

            Hospedes = hospedes;
        }

        /// <inheritdoc/>
        public void CadastrarSuite(Suite suite)
        {
            _ = ValidarSuite(suite);

            Suite = suite;
        }

        /// <inheritdoc/>
        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.ToList().Count;
        }

        /// <inheritdoc/>
        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            valor = AplicarDesconto(valor);

            return valor;
        }
        
        /// <summary>
        /// Realiza validação para a suíte informada para reserva.
        /// </summary>
        /// <param name="suite"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Exception ocorre quando a lista for nula ou vazia.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Exception ocorre quando o estado da suíte for indisponível.</exception>
        private bool ValidarSuite(Suite suite)
        {
            if (suite is null)
            {
                throw new ArgumentNullException("Suíte não informada (nula).");
            }

            if (!suite.Disponivel)
            {
                throw new ArgumentOutOfRangeException("Suíte indisponível");
            }

            return true;
        }

        /// <summary>
        /// Realiza validação da lista de hospedes.
        /// </summary>
        /// <param name="hospedes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Exception ocorre quando a lista de hospedes for nula ou com quantidade igual a 0 (zero).</exception>
        /// <exception cref="ArgumentOutOfRangeException">Exception ocorre quando a lista de hospedes possuir quantidade de hospedes além da capacidade da Suíte.</exception>
        private bool ValidarListaHospede(IReadOnlyCollection<Pessoa> hospedes)
        {
            if (hospedes is null || !hospedes.Any())
            {
                throw new ArgumentNullException($"Lista fornecida de hospedes vazia (nula).");
            }

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new ArgumentOutOfRangeException("Lista de hospedes fornecida inválida (quantidade de pessoas maior que a capacidade da Suíte.");
            }

            return true;
        }

        /// <summary>
        /// Aplica desconto no valor total/integral da reserva.
        /// </summary>
        /// <param name="valorIntegralReserva"></param>
        /// <returns></returns>
        private decimal AplicarDesconto(decimal valorIntegralReserva)
            => DiasReservados switch
            {
                >= 10 => valorIntegralReserva * PERCENTUAL_DESCONTO,
                _ => valorIntegralReserva,
            };
    }
}