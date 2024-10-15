namespace BattleShip.App.Services;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Services.BateauPosition;
using System.Collections.Generic;
using System.Linq;

namespace BatailleNavale.Services
{
    public class BateauService
    {
        private readonly HttpClient _httpClient;

        public BateauService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BateauPosition>> DemanderPositionsBateauxAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<BateauPosition>>("http://localhost:5038/start");
            
            // Remplacer ':' par '0' dans les positions des bateaux
            foreach (var bateau in response)
            {
                foreach (var position in bateau.PositionsBateaux)
                {
                    foreach (var key in position) // itère sur chaque KeyValuePair
                    {
                        var bateauKey = key.Key; // Obtenir la clé du KeyValuePair
                        var positions = key.Value.Select(p => p.Replace(':', '0')).ToList();
                        position[bateauKey] = positions; // Mettre à jour la position
                    }
                }
            }

            return response;
        }
    }
}
