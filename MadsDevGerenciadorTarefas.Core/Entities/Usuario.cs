using MadsDevGerenciadorTarefas.Core.Enums;
using System.Security.Cryptography;
using System.Text;

namespace MadsDevGerenciadorTarefas.Core.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(string nome, string senha, string email, PapelEnum papel)
        {
            Nome = nome;
            Senha = HashPassword(senha);
            Email = email;
            Papel = papel;
            Status = StatusUsuarioEnum.Ativo;
            StatePree = "C";
            Tarefas = new List<Tarefa>();
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public PapelEnum Papel { get; private set; }
        public StatusUsuarioEnum Status { get; private set; }
        public string StatePree { get; set; }
        public List<Tarefa> Tarefas { get; private set; }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - retorna byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converte byte array para string  
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void Update(string nome, string senha, string email, PapelEnum papel, StatusUsuarioEnum status)
        {
            Nome = nome;
            Senha = HashPassword(senha);
            Email = email;
            Papel = papel;
            Status = status;
            StatePree = "C";
        }

        public void UpdateStatusUsuario()
        {
            Status = StatusUsuarioEnum.Inativo;
        }

        public void UpdateStatePreeUsuario()
        {
            StatePree = "A";
        }
    }
}
