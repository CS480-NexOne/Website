using NexOneVS.Models.TV;
using System.ComponentModel.DataAnnotations;

namespace NexOneVS.ViewModels
{
    public class TVSearchViewModel
    {
        public TVDB TV { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Query { get; set; }

    }
}