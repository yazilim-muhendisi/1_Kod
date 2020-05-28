using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.coreproject.Data_Transfer_Objects;

namespace tekno_egitim_web.coreproject.KategoriAPI
{
    public class KategoriAPIServices
    {
        private readonly HttpClient _httpclient;
        public KategoriAPIServices(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<IEnumerable<KategoriDto>> GetAllAsync()
        {
            IEnumerable<KategoriDto> kategoridto;
            var response = await _httpclient.GetAsync("kategoriler");
            if (response.IsSuccessStatusCode)
            {
                kategoridto = JsonConvert.DeserializeObject<IEnumerable<KategoriDto>>
                    (await response.Content.ReadAsStringAsync());
            }

            else
            {
                kategoridto = null;
            }

            return kategoridto;
        }
        public async Task<KategoriDto> AddAsync(KategoriDto KategoriDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(KategoriDto), Encoding.UTF8, "application/json");

            var response = await _httpclient.PostAsync("kategoriler", stringContent);

            if (response.IsSuccessStatusCode)
            {
                KategoriDto = JsonConvert.DeserializeObject<KategoriDto>(await response.Content.ReadAsStringAsync());

                return KategoriDto;
            }
            else
            {
                //loglama yap
                return null;
            }
        }

        public async Task<KategoriDto> GetByIdAsync(int id)
        {
            var response = await _httpclient.GetAsync($"kategoriler/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<KategoriDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(KategoriDto KategoriDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(KategoriDto), Encoding.UTF8, "application/json");

            var response = await _httpclient.PutAsync("kategoriler", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpclient.DeleteAsync($"kategoriler/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            {
                return false;
            }
        }


    }
}
