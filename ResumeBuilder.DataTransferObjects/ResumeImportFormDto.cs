using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace ResumeBuilder.DataTransferObjects
{
    public class ResumeImportFormDto
    {
        public IFormFile jsonFile { get; set; }

    }
}