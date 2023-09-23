using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Informe a quantidade de hospedes:");
_ = uint.TryParse(Console.ReadLine(), out uint quantidadeHospedesInformada);

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = CriarHospedesDinamicamente(quantidadeHospedesInformada).ToList();

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");


static IEnumerable<Pessoa>  CriarHospedesDinamicamente(uint quantidadeHospedes)
{
    var lista = new List<Pessoa>();
    Pessoa pessoa;
    for(var i = 0 ; i < quantidadeHospedes ; i++)
    {
        pessoa = new Pessoa(nome: $"Hóspede {(i+1)}");
        lista.Add(pessoa);
    }

    return lista;
}