using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioDTO // Data Transfer Object (DTO) para o usuário
    {
        public int id;
        public string nome = string.Empty;
        public string sobrenome = string.Empty;
        public string email = string.Empty;
    }
}
