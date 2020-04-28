using System;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity.Models
{
    public class IpUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public string VatCode { get; set; }
        public string Salt { get; set; }
        public string FiscalCode { get; set; }
        public IEnumerable<string> Profile { get; set; }
    }
}


/*

Ragione Sociale
Nome
Cognome
Partita Iva
Codice Destinatario
Cellulare
Telefono
Fax
Indirizzo
Cap
Città
Provincia

*/