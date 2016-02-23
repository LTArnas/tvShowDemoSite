using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tvShowDemoSite.Models
{
    // TODO: custom validation for lists.

    /// <summary>
    /// Holds data for a single TV show.
    /// </summary>
    [DisplayName("Show")]
    public class ShowModel
    {
        /// <summary>
        /// Unique identifier for the show. 
        /// </summary
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
        [Key]
        [DisplayName("ID")]
        public string Id { get; set; }

        /// <summary>
        /// URL to poster image (external resource).
        /// </summary>
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl)]
        [Url(ErrorMessage = "URL invalid.")]
        public string PosterURL { get; set; }

        /// <summary>
        /// Official title of the show, upon original release.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required.")]
        [DisplayName("Title")]
        [MinLength(1, ErrorMessage = "Must have at least one character.")]
        public string Title { get; set; }

        /// <summary>
        /// Original official release date, based on original network.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is required.")]
        [DisplayName("Date")]
        [DataType(DataType.Date, ErrorMessage = "Must be a valid date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Original official network.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Network is required.")]
        [DisplayName("Network Name")]
        [MinLength(1, ErrorMessage = "Must have at least one character.")]
        public string Network { get; set; }

        /// <summary>
        /// Genre(s). Single genre per value.
        /// </summary>
        public List<string> Genre { get; set; }
        
        /// <summary>
        /// Officially credited creator(s). Single creator per value.
        /// </summary>
        public List<string> CreatedBy { get; set; }
        
        /// <summary>
        /// Original official language(s).
        /// </summary>
        public List<string> Language { get; set; }
        
        /// <summary>
        /// Total number of official seasons currently released.
        /// Does not include any sort of upcoming season(s).
        /// At least one episode must be officially released for a season to qualify.
        /// </summary>
        [Required(ErrorMessage = "Number of seasons is required.")]
        [DisplayName("Seasons")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Value too low (must be at least 1), or too high.")]
        public int Seasons { get; set; }

        /// <summary>
        /// Total number of offical episodes currently released.
        /// Does not include any sort of upcoming episode(s).
        /// </summary>
        [Required(ErrorMessage = "Total number of episodes is required.")]
        [DisplayName("Episodes")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Value too low (must be at least 1), or too high.")]
        public int Episodes { get; set; }
    }
}
