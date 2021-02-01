using rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bo.Models
{
    public class PaginatePicture
    {
        public List<PICTURE> items;
        public int totalCount;
        public int pageSize;
        public int currentPage;
        public int totalPages;
        public string previousPage;
        public string nextPage;

        public PaginatePicture(List<PICTURE> items, int totalCount, int pageSize, int currentPage, int totalPages, string previousPage, string nextPage)
        {
            this.items = items;
            this.totalCount = totalCount;
            this.pageSize = pageSize;
            this.currentPage = currentPage;
            this.totalPages = totalPages;
            this.previousPage = previousPage;
            this.nextPage = nextPage;
        }
    }
}