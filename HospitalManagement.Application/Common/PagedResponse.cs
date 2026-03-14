using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Common
{
    public class PagedResponse<T>
    {
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }
        public PagedResponse(int pageNumber, int totalRecords, int pageSize, IEnumerable<T> data)
        {
            PageNumber = pageNumber;
            TotalRecords = totalRecords;
            PageSize = pageSize;
            Data = data;
        }
    }
}
