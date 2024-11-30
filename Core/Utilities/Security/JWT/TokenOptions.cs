using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions // Token Ayarları veya Jeton Seçenekleri
    {
        public string Audience { get; set; } // Hedef Kitle
        public string Issuer { get; set; }   // Sağlayıcı (Yayımlayan)
        public int AccessTokenExpiration { get; set; } // Erişim Jetonu Süresi (Sonlanma Süresi)
        public string SecurityKey { get; set; }        // Güvenlik Anahtarı
    }
}
