using AutoService.Core.DomainObjects;
using AutoService.Domain.Enums;

namespace AutoService.Domain.Entities
{
    public sealed class Professional : AggregateRoot
    {
        protected Professional(){
            }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string PhotoDirectory { get; private set; }
        public bool FullAcecss { get; private set; }
        public DateTime? DateFullAcecss { get; private set; }
        public PermissionEnum Permission { get; private set; }
        public Professional(string name,
            string password,
            string email,
            string cPF)
            : base()
        {
            Name = name;
            Password = password;
            Email = email;
            CPF = cPF;
            PhotoDirectory = string.Empty;
            FullAcecss = false;
            Permission = PermissionEnum.Test;
        }

        public void ChangeAcecssToFull()
        {
            FullAcecss = true;
            DateFullAcecss = DateTime.Now;
            Permission = PermissionEnum.Admin;
        }
        
        public void Update(string name,
            string email,
            string password,
            string photoDirectory)
        {
            Email = email;
            Name = name;
            Password = password;
            PhotoDirectory = photoDirectory;
        }
    }
}
