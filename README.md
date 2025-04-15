# Criação da interface - aba lateral
  Criação dos metodos: Listagem - List<ItemPedido> ListarTodos, buscar por ID -"Nome do repositorio" BuscarPorId(int id)
  DEFINIR metodos CRUID void: Cadastrar - ("Repositorio" var), Atualizar, Deletar

# Criação do Repository - aba lateral
  Herdar Interface
  Implementar os métodos da Interface
  Criou o _context 
  ctor 
  Alterar os metodos implementando listar e cadastrar
  
### Program - injeção de dependencia builder.ServicesAddTransient<"Interface", "repository">

# Criação da classe Crotroller - abalateral
  Injetou o Repository
  Criou o "nome do controller" private
  ctor - implementando "nome private" recebendo uma variavel
  CRIAR metodos CRUID
  Criação do retorno para o JSON - Get para listar com return e Post
