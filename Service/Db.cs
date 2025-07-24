using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;

namespace Service
{
    public class Db
    { // ? = em algum momento a variável pode ser nula
        private readonly MySqlConnection _con; // conexão
        private MySqlCommand? _command; //comandos
        private MySqlDataReader? _reader; //leitos de dados

        public Db()
        {
            _con = new MySqlConnection("Server=127.0.0.1;Database=cadusuario;Uid=root;Pwd=SsMode=none;"); // Coloque aqui a string de conexão com o banco de dados
        }

        public List<UsuarioDTO> GetData() //
        {
            _con.Open(); //abrir conexão
            _command = new MySqlCommand(); //criar comando
            _command.Connection = _con; //atribuir conexão ao comando
            _command.CommandText = "SELECT * FROM Usuario";
            _reader = _command.ExecuteReader(); //executar comando e ler dados

            List< UsuarioDTO> ListaDeUsuarios = new List<UsuarioDTO>();

            while (_reader.Read())
            {
                var usuarioDTO = new UsuarioDTO()
                {
                    id = int.Parse(_reader["Id"].ToString()!),
                    nome = _reader["Nome"].ToString()!,
                    sobrenome = _reader["Sobrenome"].ToString()!,
                    email = _reader["Email"].ToString()!
                };
                ListaDeUsuarios.Add(usuarioDTO); //adicionar usuário à lista
            }
            return ListaDeUsuarios;
        }

        public void AddUsuario(string nome)
        {
            _con.Open(); //abrir conexão
            _command = new MySqlCommand(); //criar comando
            _command.Connection = _con; //atribuir conexão ao comando

            _command.CommandText = "INSERT INTO USUARIO (Nome, Sobrenome, Email) VALUES (?nome, ?sobrenome, ?email)";
            _command.Parameters.Add("?nome", MySqlDbType.String).Value = nome;

        }
    }
}
