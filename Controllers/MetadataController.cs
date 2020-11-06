using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCsvApi.Models;
using MovieCsvApi.CsvData;

namespace MovieCsvApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        private readonly CsvReader _csvReader;
        private static List<Metadata> _database;

        public MetadataController(CsvReader csvReader)
        {
            _csvReader = csvReader;
            if (_database == null)
                _database = new List<Metadata>();
        }

        // GET: metadata
        [HttpGet]
        public ActionResult<IEnumerable<Metadata>> Get()
        {
            List<Metadata> items = _csvReader.GetMetadata();
            List<Metadata> sortedList = items.OrderBy(x => x.Language).ToList();
            return sortedList;
        }

        // GET: metadata/5
        [HttpGet("{movieId}")]
        public ActionResult<IEnumerable<Metadata>> Get(long movieId)
        {
            var items = _csvReader.GetMetadata();
            var metadataList = items.FindAll(x => x.MovieId == movieId);
            if (metadataList == null)
            {
                return NotFound();
            }
            List<Metadata> sortedList = metadataList.OrderBy(x => x.Language).ToList();
            return sortedList;
        }

        // POST: metadata
        [HttpPost]
        public ActionResult<Metadata> Post(Metadata metadata)
        {
            var count = _database.Count;
            metadata.Id = count + 1;
            _database.Add(metadata);
            return metadata;
        }
    }
}
