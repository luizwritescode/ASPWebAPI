using BLL;
using Microsoft.AspNetCore.Mvc;
using MODEL;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        public Dictionary<int, string> cidades = new Dictionary<int, string>()
            {
{11, "São Paulo - SP"},
{ 12, "São José dos Campos - SP"},
{ 13, "Santos - SP"},
{ 14, "Bauru - SP"},
{ 15, "Sorocaba - SP"},
{ 16, "Ribeirão Preto - SP"},
{ 17, "São José do Rio Preto - SP"},
{ 18, "Presidente Prudente - SP"},
{ 19, "Campinas - SP"},
{ 21, "Rio de Janeiro - RJ"},
{ 22, "Campos dos Goytacazes - RJ"},
{ 24, "Volta Redonda - RJ"},
{ 27, "Vitória / Vila Velha - ES"},
{ 28, "Cachoeiro de Itapemirim - ES"},
{ 31, "Belo Horizonte - MG"},
{ 32, "Juiz de Fora - MG"},
{ 33, "Governador Valadares - MG"},
{ 34, "Uberlândia - MG"},
{ 35, "Poços de Caldas - MG"},
{ 37, "Divinópolis - MG"},
{ 38, "Montes Claros - MG"},
{ 41, "Curitiba - PR"},
{ 42, "Ponta Grossa - PR"},
{ 43, "Londrina - PR"},
{ 44, "Maringá - PR"},
{ 45, "Foz do Iguaçú - PR"},
{ 46, "Pato Branco / Francisco Beltrão - PR"},
{ 47, "Joinville - SC"},
{ 48, "Florianópolis - SC"},
{ 49, "Chapecó - SC"},
{ 51, "Porto Alegre - RS"},
{ 53, "Pelotas - RS"},
{ 54, "Caxias do Sul - RS"},
{ 55, "Santa Maria - RS"},
{ 61, "Brasília - DF"},
{ 62, "Goiânia - GO"},
{ 63, "Palmas - TO"},
{ 64, "Rio Verde - GO"},
{ 65, "Cuiabá - MT"},
{ 66, "Rondonópolis - MT"},
{ 67, "Campo Grande - MS"},
{ 68, "Rio Branco - AC"},
{ 69, "Porto Velho - RO"},
{ 71, "Salvador - BA"},
{ 73, "Ilhéus - BA"},
{ 74, "Juazeiro - BA"},
{ 75, "Feira de Santana - BA"},
{ 77, "Barreiras - BA"},
{ 79, "Aracaju - SE"},
{ 81, "Recife - PE"},
{ 82, "Maceió - AL"},
{ 83, "João Pessoa - PB"},
{ 84, "Natal - RN"},
{ 85, "Fortaleza - CE"},
{ 86, "Teresina - PI"},
{ 87, "Petrolina - PE"},
{ 88, "Juazeiro do Norte - CE"},
{ 89, "Picos - PI"},
{ 91, "Belém - PA"},
{ 92, "Manaus - AM"},
{ 93, "Santarém - PA"},
{ 94, "Marabá - PA"},
{ 95, "Boa Vista - RR"},
{ 96, "Macapá - AP"},
{ 97, "Coari - AM"},
{ 98, "São Luís - MA"},
{ 99, "Imperatriz - MA"}

            };

        /*
        //Endpoint POST que retorna a cidade, dado o objeto do cliente
            body: Cliente (Id, Nome, Telefone, Email)

         obs. O swagger vai inicializar o teste com o Id 0. Mudar valor do Id para 1 porque o Banco começa pelo Id 1.

        Exemplo:  Id 1 retorna Salvador, já Id 3 retorna Feira de Santana 
        */
        [HttpPost(Name = "GetCidade")]
        public ActionResult<string> GetCidade(Cliente _cliente)
        {

            try
            {
                Cliente cliente = ClienteRepository.GetById(_cliente.Id);   // usa apenas o id

                if (cliente != null && cliente.Telefone != null)
                {
                    int ddd = Int32.Parse(cliente.Telefone.Substring(0, 2));
                    string cidade;
                    if (cidades.TryGetValue(ddd, out cidade))
                    {
                        return Ok(cidade);
                    }
                    else
                    {
                        return NotFound("Não foi encontrada uma cidade associada a este ddd: " + ddd);
                    }
                }

                return BadRequest("Cliente ou telefone inválidos.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //BONUS (ESSE É LEGAL TEM BASTANTE DDD graças a uma ajudinha do javascript)
        //Endpoint GET que retorna a cidade, dado um DDD
        [HttpGet(Name = "GetCidadeFromDDD")]
        public ActionResult<string> GetCidadeFromDDD(string _ddd)
        {

            try
            {

                if (_ddd != null)
                {
                    int ddd = Int32.Parse(_ddd);
                    string cidade;
                    if (cidades.TryGetValue(ddd, out cidade))
                    {
                        return Ok(cidade);
                    }
                    else
                    {
                        return NotFound("Não foi encontrada uma cidade associada a este ddd: " + ddd);
                    }
                }

                return BadRequest("DDD inválido.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
