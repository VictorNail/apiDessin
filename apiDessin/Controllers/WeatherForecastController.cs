using Microsoft.AspNetCore.Mvc;
using apiDessin;
using Newtonsoft.Json;
using System.IO;


namespace apiDessin.Controllers
{
    [ApiController]
    [Route("/dessin")]
    public class DessinController : Controller
    {
        private readonly IDessin _dessinRepository;
        public DessinController(IDessin dessinRepository)
        {
            _dessinRepository = dessinRepository;
        }

        [HttpPost]
        public void CreeDessin(int id, [FromQuery] string name, [FromQuery] int width, [FromQuery] int height, [FromQuery] string description)
        {
            _dessinRepository._id = id;
            _dessinRepository._name = name;
            _dessinRepository._width = width;
            _dessinRepository._height = height;
            _dessinRepository._description = description;
            string path = string.Format("dessins/{0}.json", _dessinRepository._id);
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(_dessinRepository));
        }

        [HttpPut("{id}")]
        public void UpdateDessin(int id, [FromBody] Dessin dessin)
        {
            if (id == dessin._id)
            {
                _dessinRepository.Update(dessin);
                string path = string.Format("dessins/{0}.json", _dessinRepository._id);
                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(_dessinRepository));
            }
        }

        [HttpGet]
        public ActionResult<string> AfficherDessins()
        {
            string result = "";
            string path = @"dessins/";
            foreach (string file in Directory.EnumerateFiles(path, "*.json*", SearchOption.AllDirectories))
            {
                result += System.IO.File.ReadAllText(file) + "\n";
            }
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<string> AfficherId(int id)
        {
            string path = @"dessins/";
            foreach (string file in Directory.EnumerateFiles(path, "*.json*", SearchOption.AllDirectories))
            {
                JsonSerializer serializer = new JsonSerializer();
                Dessin result = JsonConvert.DeserializeObject<Dessin>(System.IO.File.ReadAllText(file));
                if (result._id == id)
                {
                    return Ok(result);
                }
            }
            return NotFound("Dessin non trouvé");
        }

        [HttpGet("/{name}")]

        public ActionResult<string> AfficherName(string name)
        {
            Dessin[] result = new Dessin[0];
            string path = @"dessins/";
            foreach (string file in Directory.EnumerateFiles(path, "*.json*", SearchOption.AllDirectories))
            {
                JsonSerializer serializer = new JsonSerializer();
                Dessin objet = JsonConvert.DeserializeObject<Dessin>(System.IO.File.ReadAllText(file));
                if (objet._name == name)
                {
                    Array.Resize(ref result, result.Length + 1); result[result.Length - 1] = objet;
                }
            }
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Dessin non trouvé");
            }
        }
    }
}
