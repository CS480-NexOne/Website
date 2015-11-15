using NexOneVS.Models.Movie;
using System.ComponentModel.DataAnnotations;

namespace NexOneVS.ViewModels
{
    public class SearchViewModel
    {
        public MovieDB Movies { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Query { get; set; }

    }
}