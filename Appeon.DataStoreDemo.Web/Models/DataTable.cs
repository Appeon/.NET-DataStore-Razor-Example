using System.Collections;

namespace Appeon.MvcModelMapperDemo.Models
{
    public class DataTable
    {
        /// <summary>
        /// request flag
        /// </summary>
        public int draw { get; set; }

        /// <summary>
        /// The total records
        /// </summary>
        public int recordsTotal { get; set; }

        /// <summary>
        /// The records of filter 
        /// </summary>
        public int recordsFiltered { get; set; }

        /// <summary>
        /// The index of page
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// The size per page
        /// </summary>
        public int? pageSize { get; set; }

        /// <summary>
        /// The data per page
        /// </summary>
        public IList data { get; set; }
    }
}
