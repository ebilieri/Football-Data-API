# FootballAPISolution
Aplicação que consulta os dados dos campeonatos de futeboll através da API https://www.football-data.org/


public async Task<Football> GetFootball(string idCompeticao)
{            
    var token = ConfigHelper.GetToken();
    var uriEndpoint = GetUriEndpoint(idCompeticao);

    Football football = null;
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("X-Auth-Token", token);

        using (var response = await client.GetAsync(uriEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                football = await response.Content.ReadAsAsync<Football>();
            }
            else
            {
                var msgRetorno = await response.Content.ReadAsAsync<Messagem>();
                throw new Exception(msgRetorno.Message);
            }
        }
    }
    return football;
}
