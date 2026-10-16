\# FintechBank



\## Visão geral



O \*\*FintechBank\*\* é uma aplicação .NET que implementa regras de negócio de um banco digital: taxa de manutenção de conta, validação de saque com cheque especial, cálculo de parcelas de empréstimo por score de crédito e aprovação de empréstimo por margem de 30% da renda. As regras são cobertas por testes unitários parametrizados com xUnit.



\## Requisitos técnicos



\- .NET 10 SDK

\- Git



\## Regras de negócio



\### ContaCorrenteService



\- `CalcularTaxaManutencao(saldo, clienteEspecial)`: isento (R$ 0,00) se saldo >= R$ 5.000,00 ou cliente especial; R$ 12,50 se saldo entre R$ 1.000,00 e R$ 4.999,99; R$ 25,00 se saldo abaixo de R$ 1.000,00.

\- `PodeRealizarSaque(saldo, limiteChequeEspecial, valorSaque)`: retorna `true` somente se o saque for menor ou igual a saldo + limite do cheque especial.



\### EmprestimoService



\- `CalcularValorParcela(valorTotal, parcelas, scoreCredito)`: juros de 5% (score >= 700), 12% (score de 500 a 699) ou 20% (score < 500). Retorna o valor com juros dividido pelo número de parcelas.

\- `AprovarEmprestimo(rendaMensal, valorParcela)`: aprova somente se a parcela for no máximo 30% da renda mensal.



\## Como clonar e compilar



```bash

git clone https://github.com/gabrielrrbeiro-byte/fintech-bank-xunit.git

cd fintech-bank-xunit

dotnet restore

dotnet build

```



\## Como executar os testes



```bash

dotnet test

```



\## Testes parametrizados



\- `\[Theory]` marca um teste que roda várias vezes, uma para cada conjunto de dados.

\- `\[InlineData(...)]` define um conjunto de entradas e o resultado esperado.



\*\*ContaCorrenteServiceTests:\*\* 4 casos para a taxa de manutenção (saldo alto, cliente especial, saldo intermediário, saldo baixo) e 2 casos para o saque (dentro e fora do limite).



\*\*EmprestimoServiceTests:\*\* 3 casos para a parcela (score alto, médio e baixo) e 2 casos para a aprovação (parcela igual a 30% da renda e parcela acima de 30%).



\## Licença



MIT

