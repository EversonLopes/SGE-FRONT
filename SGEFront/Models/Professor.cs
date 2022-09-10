using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGEFront.Enums;

namespace SGEFront.Models
{
    public class Professor
    {
       
    
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public NiveldePermissaoEnum NiveldePermissaoEnum { get; set; }      
        
        

}
}