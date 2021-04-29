Back-End
- Desenvolvido na versão 3.1 do .NET CORE

1 - É necessário instalar o visual studio 2019 ou o vscode (caso não tenha) com o sdk a partir da versão 3.1
2 - Abrir projeto Planos_Ligacao.sln
3 - Configurar Base
	2.1 Abrir Package Manager Console
	2.2 Default project: Planos_Ligacao.Infra.Data
	2.3 update-database -Context PlanosLigacaoContext
	2.4 Executar os scripts no arquivo 'dados tabelas.sql' presente na pasta sql da raiz do projeto
4 - Basta rodar API

Front-End
- Desenvolvido em angular 10 e bootstrap 4 (responsivo)

1 - Instalar o angular CLI e o node.js (caso não tenha instalado)
2 - navegar para src/Planos_Ligacao.Presentation/
3 - Abrir o CMD no diretório acima
4 - Executar o comando npm install
5 - Executar o comando ng s
6 - Para rodar os testes basta executar o comando ng test no CMD ("no diretorio acima. Item 1")
