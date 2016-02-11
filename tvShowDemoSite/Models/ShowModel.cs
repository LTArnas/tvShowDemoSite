using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvShowDemoSite.Models
{
    /// <summary>
    /// Holds data for a single TV show.
    /// </summary>
    public class ShowModel
    {
        /// <summary>
        /// Unique identifier for the show. 
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Official title of the show, upon original release.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Original official release date, based on original network.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        
        /// <summary>
        /// Original official network.
        /// </summary>
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
        public int Seasons { get; set; }
        
        /// <summary>
        /// Total number of offical episodes currently released.
        /// Does not include any sort of upcoming episode(s).
        /// </summary>
        public int Episodes { get; set; }
    }
}
